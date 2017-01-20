using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestObjectClass2
{
    class PlasticProps
    {
        //known variables
        //static double P_t, b_t, t_t, P_w, D, t_w, P_c, b_c, t_c, P_b, b_b, t_b, P_s, b_s, t_s, Y_bar;
        //unknown variables
        //static double d_t, d_w, d_c, d_b, d_s, PNA;

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

        private static double PlasticForce (double P_bfC, double P_bfT, double P_wC, double P_wT, double P_tfC, double P_tfT, double P_bolstC, double P_bolstT, double P_sC, double P_sT, double[] P_rebar)
        {
            return P_bfC + P_bfT + P_wC + P_wT + P_tfC + P_tfT + P_bolstC + P_bolstT + P_sC + P_sT + P_rebar.Sum();
        }

        public static double plasticNeutralAxis(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab, bool composite, bool positiveMoment, List<Reinforcing> reinforcing)
        {
            List<Reinforcing> sortedReinf = reinforcing.OrderByDescending(x => x.Location).ToList();
            double[] reinfForce = new double[reinforcing.Count];
            double PNA = 0, increment = 12, force = -1, totalReinfForce = reinforcing.Sum(x => x.Force);
            double P_bfC = botFlange.Force(), P_bfT = 0, P_wC = web.Force(), P_wT = 0, P_tfC = topFlange.Force(), P_tfT = 0, P_bolstC = bolster.Force(), P_bolstT = 0, P_sC = slab.Force(), P_sT = 0;
            double plasticForce = -1;// Math.Round(PlasticForce(P_bfC, P_bfT , P_wC , P_wT , P_tfC , P_tfT , P_bolstC , P_bolstT , P_sC , P_sT),6);

            while (plasticForce != 0)
            {
                int count = 0;
                foreach (Reinforcing reinf in sortedReinf)
                {
                    if (reinf.Location == PNA)
                    {
                        reinfForce[count] = 0;
                    }
                    else if (reinf.Location > PNA)
                    {
                        reinfForce[count] = -1 * reinf.Force;
                    }
                    else
                    {
                        reinfForce[count] = reinf.Force;
                    }
                    count++;
                }
                if (botFlange.TopLocation <= PNA)
                {
                    P_bfC = 0;
                    P_bfT = botFlange.Force();
                }
                else
                {
                    P_bfC = -1 * botFlange.Force() * (botFlange.TopLocation - PNA) / botFlange.y;
                    P_bfT = botFlange.Force() * (PNA - botFlange.BotLocation) / botFlange.y;
                }
                if (web.TopLocation <= PNA)
                {
                    P_wC = 0;
                    P_wT = web.Force();
                }
                else if (web.BotLocation >= PNA)
                {
                    P_wC = -1 * web.Force();
                    P_wT = 0;
                }
                else
                {
                    P_wC = -1 * web.Force() * (web.TopLocation - PNA) / web.y;
                    P_wT = web.Force() * (PNA - web.BotLocation) / web.y;
                }
                if (topFlange.TopLocation <= PNA)
                {
                    P_tfC = 0;
                    P_tfT = topFlange.Force();
                }
                else if (topFlange.BotLocation >= PNA)
                {
                    P_tfC = -1 * topFlange.Force();
                    P_tfT = 0;
                }
                else
                {
                    P_tfC = -1 * topFlange.Force() * (topFlange.TopLocation - PNA) / topFlange.y;
                    P_tfT = topFlange.Force() * (PNA - topFlange.BotLocation) / topFlange.y;
                }
                if (bolster.TopLocation <= PNA)
                {
                    P_bolstC = 0;
                    P_bolstT = 0;
                }
                else if (bolster.BotLocation >= PNA)
                {
                    P_bolstC = -1 * bolster.Force(1 / 0.85);
                    P_bolstT = 0;
                }
                else
                {
                    P_bolstC = -1 * bolster.Force(1 / 0.85) * (bolster.TopLocation - PNA) / bolster.y;
                    P_bolstT = 0;
                }
                if (slab.TopLocation <= PNA)
                {
                    P_sC = 0;
                    P_sT = 0;
                }
                else if (slab.BotLocation >= PNA)
                {
                    P_sC = -1 * slab.Force(1 / 0.85);
                    P_sT = 0;
                }
                else
                {
                    P_sC = -1 * slab.Force(1 / 0.85) * (slab.TopLocation - PNA) / slab.y;
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
            }
            return PNA;
        }

        // define know variables
        /*private static void defineVariables(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab, bool composite, bool positiveMoment, List<Reinforcing> reinforcing)
        {
            double[] array = compositeAndPositiveMoment(composite, positiveMoment);

            if (positiveMoment)
            {
                P_t = botFlange.Force(); b_t = botFlange.x; t_t = botFlange.y; P_w = web.Force(); D = web.y; t_w = web.x; P_c = topFlange.Force(); b_c = topFlange.x; t_c = topFlange.y;
                P_b = bolster.Force(1 / 0.85) * array[0]; b_b = bolster.x * array[0]; t_b = bolster.y * array[0]; P_s = slab.Force(1 / 0.85) * array[0]; b_s = slab.x * array[0]; t_s = slab.y * array[0];
            }
            else
            {
                P_t = topFlange.Force(); b_t = topFlange.x; t_t = topFlange.y; P_w = web.Force(); D = web.y; t_w = web.x; P_c = botFlange.Force(); b_c = botFlange.x; t_c = botFlange.y;
            }

        }*/

        /*public static double plasticNeutralAxis(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab, bool composite, bool positiveMoment, List<Reinforcing> reinforcing)
        {
            defineVariables(botFlange, web, topFlange, bolster, slab, composite, positiveMoment, reinforcing);
            List<Reinforcing> sortedReinf = reinforcing.OrderByDescending(x => x.Location).ToList();
            double totalReinfForce = reinforcing.Sum(y => y.Force);
            double increment = 1, PNA = 0, plasticForce = 999999;

            while(plasticForce != 0)
            {

            }


        }*/

        public static double[] plasticVariables(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab, bool composite, bool positiveMoment, List<Reinforcing> reinforcing)
        {
            List<Reinforcing> sortedReinf = reinforcing.OrderByDescending(x => x.Location).ToList();
            double[] a = new double[4];
            int i = 0;
            double totalReinfForce = reinforcing.Sum(y => y.Force);

            foreach (Reinforcing reinf in sortedReinf)
            {
                // dist to PNA from top of slab if located above given layer of reinforcement
                //a[i] = 
            }

            // dist to PNA from top of slab if located in slab
            a[0] = (botFlange.Force() + web.Force() + topFlange.Force()) / (0.85 * slab.x * slab.Strength);
            // dist to PNA from top of haunch if located in bolster
            a[1] = (botFlange.Force() + web.Force() + topFlange.Force() - 0.85 * slab.Force()) / (0.85 * bolster.x * bolster.Strength);
            // dist to PNA from top of top flange if located in top flange
            a[2] = (botFlange.Force() + web.Force() + topFlange.Force() - 0.85 * slab.Force() - 0.85 * bolster.Force()) / (2 * topFlange.x * topFlange.Strength);
            // dist to PNA from top of web if located in web
            a[3] = (botFlange.Force() - web.Force() - topFlange.Force() - 0.85 * slab.Force() - 0.85 * bolster.Force()) / (2 * web.x * web.Strength);

            return a;
        }

        /*public static double[] plasticTop(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab)
        {
            // return[force, CG]
            double[] a = plasticVariables(botFlange, web, topFlange, bolster, slab), b = new double[2];
            double PNA = plasticNeutralAxis(botFlange, web, topFlange, bolster, slab);
            // component {force, dist to PNA}
            double[] slabC = { 0, 0 }, bolstC = { 0, 0 }, tFlangeC = { 0, 0 }, webC = { 0, 0 };
            if (a[0] <= slab.y)
            {
                slabC[0] = a[0] * 0.85 * slab.x * slab.Strength;
                slabC[1] = slab.TopLocation - a[0] / 2 - PNA;
            }
            else if (a[1] <= bolster.y)
            {
                slabC[0] = 0.85 * slab.Force();
                slabC[1] = slab.CG - PNA;
                bolstC[0] = a[1] * 0.85 * bolster.x * bolster.Strength;
                bolstC[1] = bolster.TopLocation - a[1] / 2 - PNA;
            }
            else if (a[2] <= topFlange.y)
            {
                slabC[0] = 0.85 * slab.Force();
                slabC[1] = slab.CG - PNA;
                bolstC[0] = 0.85 * bolster.Force();
                bolstC[1] = bolster.CG - PNA;
                tFlangeC[0] = a[2] * topFlange.x * topFlange.Strength;
                tFlangeC[1] = topFlange.TopLocation - a[2] / 2 - PNA;
            }
            else
            {
                slabC[0] = 0.85 * slab.Force();
                slabC[1] = slab.CG - PNA;
                bolstC[0] = 0.85 * bolster.Force();
                bolstC[1] = bolster.CG - PNA;
                tFlangeC[0] = topFlange.Force();
                tFlangeC[1] = topFlange.CG - PNA;
                webC[0] = a[3] * web.x * web.Strength;
                webC[1] = web.TopLocation - a[3] / 2 - PNA;
            }

            b[0] = slabC[0] + bolstC[0] + tFlangeC[0] + webC[0];
            b[1] = (slabC[0] * slabC[1] + bolstC[0] * bolstC[1] + tFlangeC[0] * tFlangeC[1] + webC[0] * webC[1]) / b[0];

            return b;
        }*/

        /*public static double[] plasticBottom(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab)
        {
            double[] a = plasticVariables(botFlange, web, topFlange, bolster, slab), b = new double[2];
            double PNA = plasticNeutralAxis(botFlange, web, topFlange, bolster, slab);
            // component {force, dist to PNA}
            double[] slabT = { 0, 0 }, bolstT = { 0, 0 }, tFlangeT = { 0, 0 }, webT = { 0, 0 }, bFlangeT = { 0, 0 };
            if (a[0] <= slab.y | a[1] <= bolster.y)
            {
                tFlangeT[0] = topFlange.Force();
                tFlangeT[1] = PNA - topFlange.CG;
                webT[0] = web.Force();
                webT[1] = PNA - web.CG;
                bFlangeT[0] = botFlange.Force();
                bFlangeT[1] = PNA - botFlange.CG;

            }
            else if (a[2] <= topFlange.y)
            {
                tFlangeT[0] = (topFlange.y - a[2]) * topFlange.x * topFlange.Strength;
                tFlangeT[1] = (topFlange.y - a[2]) / 2;
                webT[0] = web.Force();
                webT[1] = PNA - web.CG;
                bFlangeT[0] = botFlange.Force();
                bFlangeT[1] = PNA - botFlange.CG;
            }
            else
            {
                webT[0] = (web.y - a[3]) * web.x * web.Strength;
                webT[1] = (web.y - a[3]) / 2;
                bFlangeT[0] = botFlange.Force();
                bFlangeT[1] = PNA - botFlange.CG;
            }

            b[0] = slabT[0] + bolstT[0] + tFlangeT[0] + webT[0] + bFlangeT[0];
            b[1] = (slabT[0] * slabT[1] + bolstT[0] * bolstT[1] + tFlangeT[0] * tFlangeT[1] + webT[0] * webT[1] + bFlangeT[0] * bFlangeT[1]) / b[0];

            return b;

        }*/

        /*public static double plasticNeutralAxis(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab)
        {
            double[] a = plasticVariables(botFlange, web, topFlange, bolster, slab);

            if (a[0] <= slab.y)
            {
                return botFlange.y + web.y + topFlange.y + bolster.y + slab.y - a[0];
            }
            else if (a[1] <= bolster.y)
            {
                return botFlange.y + web.y + topFlange.y + bolster.y - a[1];
            }
            else if (a[2] <= topFlange.y)
            {
                return botFlange.y + web.y + topFlange.y - a[2];
            }
            else
            {
                return botFlange.y + web.y - a[3];
            }
        }*/


    }
}
