using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestObjectClass2
{
    class PlasticProps
    {
        private static double[] CompositeAndPositiveMoment(bool composite, bool positiveMoment)
        {
            double comp;
            double posM;
            double[] array = new double[2];
            if (composite)
            {
                comp = 1;
                if (positiveMoment)
                {
                    posM = 1;
                }
                else
                {
                    posM = 0;
                }
            }
            else
            {
                posM = 0;
                comp = 0;
            }
            array[0] = comp;
            array[1] = posM;
            return array;
        }

        private static double PlasticForce (double P_bfC, double P_bfT, double P_wC, double P_wT, double P_tfC, double P_tfT, double P_bolstC, double P_bolstT, 
                                    double P_sC, double P_sT, double[][] P_rebar)
        {
            return P_bfC + P_bfT + P_wC + P_wT + P_tfC + P_tfT + P_bolstC + P_bolstT + P_sC + P_sT + P_rebar[0].Sum()+P_rebar[1].Sum();
        }

        private static double PlasticForce(double P_bfC, double P_bfT, double P_wC, double P_wT, double P_tfC, double P_tfT, double P_bolstC, double P_bolstT,
                                   double P_sC, double P_sT)
        {
            double[][] p_rebar = new double[0][];
            return PlasticForce(P_bfC, P_bfT, P_wC, P_wT, P_tfC, P_tfT, P_bolstC, P_bolstT, P_sC, P_sT, p_rebar);
        }

        private static double[] PlasticTerms(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab, List<Reinforcing> reinforcing, bool composite, 
                                    bool positiveMoment)
        {
            //List<Reinforcing> sortedReinf = reinforcing.OrderByDescending(x => x.Location).ToList();
            double[] array = CompositeAndPositiveMoment(composite, positiveMoment);
            double[][] reinfForce = new double[2] []; //reinfForce[0][] = compression,  reinfForce[1][] = tension
            double PNA = web.TopLocation, increment = 12, force = -1, M_p = 0;//, totalReinfForce = reinforcing.Sum(x => x.Force);
            double P_bfC = botFlange.Force(), P_bfT = 0, P_wC = web.Force(), P_wT = 0, P_tfC = topFlange.Force(), P_tfT = 0, P_bolstC = bolster.Force(), P_bolstT = 0, P_sC = slab.Force(), P_sT = 0;
            double plasticForce = -1;
            double[] reinf_C = new double[reinforcing.Count()], reinf_T = new double[reinforcing.Count()], terms = new double[2];
            int loopCount = 0;

            while (plasticForce != 0)
            {
                M_p = 0;
                int reinfLayer = 0;
                foreach (Reinforcing reinf in reinforcing)
                {
                    if (reinf.Location == PNA)
                    {
                        reinf_C[reinfLayer] = 0;
                        reinf_T[reinfLayer] = 0;
                    }
                    else if (reinf.Location - 0.25 >= PNA)  //arbitrarily assign reinforcing 0.5 inch depth through which PNA can exist 
                    {
                        reinf_C[reinfLayer] = -1 * reinf.Force*(1-(reinf.Strength -slab.Strength*array[1])/reinf.Strength) * array[0];
                        reinf_T[reinfLayer] = 0;
                        M_p += Math.Abs(reinf_C[reinfLayer] * (PNA - reinf.Location) / 12);
                    }
                    else if(reinf.Location + 0.25 <= PNA)
                    {
                        reinf_C[reinfLayer] = 0;
                        reinf_T[reinfLayer] = reinf.Force * array[0];
                        M_p += Math.Abs(reinf_T[reinfLayer] * (PNA - reinf.Location) / 12);
                    }
                    else 
                    {
                        reinf_C[reinfLayer] = -1 * reinf.Force * (reinf.Location + 0.25 - PNA) / 0.5 * (1 - (reinf.Strength - slab.Strength * array[1]) / reinf.Strength) * array[0];
                        M_p += Math.Abs(reinf_C[reinfLayer] * (reinf.Location + 0.25-PNA) / 24);
                        reinf_T[reinfLayer] = reinf.Force * (PNA - reinf.Location + 0.25) / 0.5;
                        M_p += Math.Abs(reinf_T[reinfLayer] * (PNA - reinf.Location + 0.25) / 24);
                    }

                    reinfLayer++;
                }
                reinfForce[0] = reinf_C;
                reinfForce[1] = reinf_T;
                if (botFlange.TopLocation <= PNA)
                {
                    P_bfC = 0;
                    P_bfT = botFlange.Force();
                    M_p += Math.Abs(P_bfT * (PNA - botFlange.CG) / 12);
                }
                else
                {
                    P_bfC = -1 * botFlange.Force() * (botFlange.TopLocation - PNA) / botFlange.y;
                    M_p += Math.Abs(P_bfC * (botFlange.TopLocation - PNA) / 24);
                    P_bfT = botFlange.Force() * (PNA - botFlange.BotLocation) / botFlange.y;
                    M_p += Math.Abs(P_bfT * (PNA - botFlange.BotLocation) / 24);
                }
                if (web.TopLocation <= PNA)
                {
                    P_wC = 0;
                    P_wT = web.Force();
                    M_p += Math.Abs(P_wT * (PNA - web.CG) / 12);
                }
                else if (web.BotLocation >= PNA)
                {
                    P_wC = -1 * web.Force();
                    M_p += Math.Abs(P_wC * (web.CG - PNA) / 12);
                    P_wT = 0;
                }
                else
                {
                    P_wC = -1 * web.Force() * (web.TopLocation - PNA) / web.y;
                    M_p += Math.Abs(P_wC *(web.TopLocation - PNA) / 24);
                    P_wT = web.Force() * (PNA - web.BotLocation) / web.y;
                    M_p += Math.Abs(P_wT * (PNA - web.BotLocation) / 24);
                }
                if (topFlange.TopLocation <= PNA)
                {
                    P_tfC = 0;
                    P_tfT = topFlange.Force();
                    M_p += Math.Abs(P_tfT * (PNA - topFlange.CG) / 12);
                }
                else if (topFlange.BotLocation >= PNA)
                {
                    P_tfC = -1 * topFlange.Force();
                    M_p += Math.Abs(P_tfC * (topFlange.CG - PNA) / 12);
                    P_tfT = 0;
                }
                else
                {
                    P_tfC = -1 * topFlange.Force() * (topFlange.TopLocation - PNA) / topFlange.y;
                    M_p += Math.Abs(P_tfC * (topFlange.TopLocation - PNA) / 24);
                    P_tfT = topFlange.Force() * (PNA - topFlange.BotLocation) / topFlange.y;
                    M_p += Math.Abs(P_tfT * (PNA - topFlange.BotLocation) / 24);
                }
                if (bolster.TopLocation <= PNA)
                {
                    P_bolstC = 0;
                    P_bolstT = 0;
                }
                else if (bolster.BotLocation >= PNA)
                {
                    P_bolstC = -1 * bolster.Force(0.85) * array[0] * array[1];
                    M_p += Math.Abs(P_bolstC * (bolster.CG - PNA) / 12);
                    P_bolstT = 0;
                }
                else
                {
                    P_bolstC = -1 * bolster.Force(0.85) * (bolster.TopLocation - PNA) / bolster.y * array[0] * array[1];
                    M_p += Math.Abs(P_bolstC * (bolster.TopLocation - PNA) / 24);
                    P_bolstT = 0;
                }
                if (slab.TopLocation <= PNA)
                {
                    P_sC = 0;
                    P_sT = 0;
                }
                else if (slab.BotLocation >= PNA)
                {
                    P_sC = -1 * slab.Force(0.85) * array[0] * array[1];
                    M_p += Math.Abs(P_sC * (slab.CG - PNA) / 12);
                    P_sT = 0;
                }
                else
                {
                    P_sC = -1 * slab.Force(0.85) * (slab.TopLocation - PNA) / slab.y * array[0] * array[1];
                    M_p += Math.Abs(P_sC * (slab.TopLocation - PNA) / 24);
                    P_sT = 0;
                }
                force = Math.Round(PlasticForce(P_bfC, P_bfT, P_wC, P_wT, P_tfC, P_tfT, P_bolstC, P_bolstT, P_sC, P_sT, reinfForce), 6);
                if(force == 0) { break; }
                if (force/plasticForce < 0)
                {
                    increment *= -0.5;
                    PNA += increment;
                }
                else
                {
                    PNA += increment;
                }
                plasticForce = force;
                loopCount++;
            }

            terms[0] = PNA;
            terms[1] = M_p;
            return terms;
        }

        private static double[] PlasticTerms(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab, bool composite, bool positiveMoment)
        {
            List<Reinforcing> reinforcing = new List<Reinforcing>();
            return PlasticTerms(botFlange, web, topFlange, bolster, slab, reinforcing, composite, positiveMoment);
        }

        private static double[] PlasticTerms(CompositeBeam compositeBeam, bool composite,
                                    bool positiveMoment)
        {
            return PlasticTerms(compositeBeam.BotFlange, compositeBeam.Web, compositeBeam.TopFlange, compositeBeam.Bolster, compositeBeam.Slab, compositeBeam.Reinforcing, composite, positiveMoment);
        }

        public static double PlasticNeutralAxis(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab, List<Reinforcing> reinforcing, bool composite, bool positiveMoment)
        {
            return PlasticTerms(botFlange, web, topFlange, bolster, slab, reinforcing, composite, positiveMoment)[0];
        }

        public static double PlasticNeutralAxis(CompositeBeam compositeBeam, bool composite, bool positiveMoment)
        {
            return PlasticTerms(compositeBeam, composite, positiveMoment)[0];
        }

        public static double PlasticMoment(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab, List<Reinforcing> reinforcing, bool composite, bool positiveMoment)
        {
            return PlasticTerms(botFlange, web, topFlange, bolster, slab, reinforcing, composite, positiveMoment)[1];
        }

        public static double PlasticMoment(CompositeBeam compositeBeam, bool composite, bool positiveMoment)
        {
            return PlasticTerms(compositeBeam, composite, positiveMoment)[1];
        }

    }
}
