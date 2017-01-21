using System;
using System.Collections.Generic;

namespace TestObjectClass2
{
    class ElasticProps
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

        public static double BeamArea(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab, double modRatio, bool composite, bool positiveMoment)
        {
            double[] array = CompositeAndPositiveMoment(composite, positiveMoment);
            return botFlange.Area() + web.Area() + topFlange.Area() + (bolster.Area(modRatio) + slab.Area(modRatio)) * array[0] *array[1];


        }

        public static double BeamArea(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab, double modRatio, bool composite, bool positiveMoment, List<Reinforcing> reinforcing)
        {
            double[] array = CompositeAndPositiveMoment(composite, positiveMoment);
            double reinfArea = 0;
            foreach (Reinforcing reinf in reinforcing)
            {
                reinfArea += reinf.Area * (1 - array[1] / modRatio); //remove slab area where reinf exists with (1 - 1/modRatio)
            }
            return botFlange.Area() + web.Area() + topFlange.Area() + (bolster.Area(modRatio) + slab.Area(modRatio)) * array[0] * array[1] + reinfArea * array[0];

        }

        public static double ElasticNeutralAxis(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab, double modRatio, bool composite, bool positiveMoment)
        {
            double[] array = CompositeAndPositiveMoment(composite, positiveMoment);
            return (botFlange.Area() * botFlange.CG + web.Area() * web.CG + topFlange.Area() * topFlange.CG + (bolster.Area(modRatio) * bolster.CG + slab.Area(modRatio) * slab.CG) * array[0] * array[1])
                               / (botFlange.Area() + web.Area() + topFlange.Area() + (bolster.Area(modRatio) + slab.Area(modRatio)) * array[0] * array[1]);

        }

        public static double ElasticNeutralAxis(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab, double modRatio, bool composite, bool positiveMoment, List<Reinforcing> reinforcing)
        {
            double[] array = CompositeAndPositiveMoment(composite, positiveMoment);
            double beamAndSlabNA = ElasticNeutralAxis(botFlange, web, topFlange, bolster, slab, modRatio, composite, positiveMoment);
            double beamAndSlabArea = BeamArea(botFlange, web, topFlange, bolster, slab, modRatio, composite, positiveMoment);
            double reinfAreaTimesLocation = 0;
            double reinfArea = 0;

            foreach(Reinforcing reinf in reinforcing)
            {
                reinfAreaTimesLocation += reinf.Area * (1 - array[1] / modRatio) * reinf.Location; //remove slab area where reinf exists with (1 - 1/modRatio)
                reinfArea += reinf.Area * (1 - array[1] / modRatio); //remove slab area where reinf exists with (1 - 1/modRatio)
            }
            return (beamAndSlabArea * beamAndSlabNA + reinfAreaTimesLocation * array[0]) / (beamAndSlabArea + reinfArea * array[0]);
        }

        public static double ElasticNeutralAxis(Plate plate)
        {
            return plate.y/2;
        }

        public static double ElasticMomentOfInertia(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab, double modRatio, bool composite, bool positiveMoment)
        {
            double[] array = CompositeAndPositiveMoment(composite, positiveMoment);
            double NA = ElasticNeutralAxis(botFlange, web, topFlange, bolster, slab, modRatio, composite, positiveMoment);
            return botFlange.I_x() + botFlange.Area() * Math.Pow(botFlange.CG - NA, 2)
                        + web.I_x() + web.Area() * Math.Pow(web.CG - NA, 2)
                        + topFlange.I_x() + topFlange.Area() * Math.Pow(topFlange.CG - NA, 2)
                        + (bolster.I_x(modRatio) + bolster.Area(modRatio) * Math.Pow(bolster.CG - NA, 2) // need to add modRatio to bolster.I_x()
                        + slab.I_x(modRatio) + slab.Area(modRatio) * Math.Pow(slab.CG - NA, 2))*array[0]*array[1]; // need to add modRatio to slab.I_x()

        }

        public static double ElasticMomentOfInertia(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab, double modRatio, bool composite, bool positiveMoment, List<Reinforcing> reinforcing)
        {
            double[] array = CompositeAndPositiveMoment(composite, positiveMoment);
            double NA = ElasticNeutralAxis(botFlange, web, topFlange, bolster, slab, modRatio, composite, positiveMoment, reinforcing);
            double reinfFirstMoment = 0;
            foreach (Reinforcing reinf in reinforcing)
            {
                reinfFirstMoment += reinf.Area * (1 - array[1] / modRatio) * Math.Pow(reinf.Location - NA, 2);
            }
            return botFlange.I_x() + botFlange.Area() * Math.Pow(botFlange.CG - NA, 2)
                        + web.I_x() + web.Area() * Math.Pow(web.CG - NA, 2)
                        + topFlange.I_x() + topFlange.Area() * Math.Pow(topFlange.CG - NA, 2)
                        + (bolster.I_x(modRatio) + bolster.Area(modRatio) * Math.Pow(bolster.CG - NA, 2) // need to add modRatio to bolster.I_x()
                        + slab.I_x(modRatio) + slab.Area(modRatio) * Math.Pow(slab.CG - NA, 2))*array[0]*array[1] // need to add modRatio to slab.I_x()
                        + reinfFirstMoment*array[0];
        }
        
        //REMOVE PLASTIC PROPERTIES FROM ELASTIC PROPERTIES CLASS!!!
        public static double[] PlasticVariables(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab)
        {
            double[] a = new double[4];
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

        public static double[] PlasticTop(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab)
        {
            // return[force, CG]
            double[] a = PlasticVariables(botFlange, web, topFlange, bolster, slab), b = new double[2];
            double PNA = PlasticNeutralAxis(botFlange, web, topFlange, bolster, slab);
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
        }

        public static double[] PlasticBottom(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab)
        {
            double[] a = PlasticVariables(botFlange, web, topFlange, bolster, slab), b = new double[2];
            double PNA = PlasticNeutralAxis(botFlange, web, topFlange, bolster, slab);
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

        }

        public static double PlasticNeutralAxis(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab)
        {
            double[] a = PlasticVariables(botFlange, web, topFlange, bolster, slab);

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
        }
        //REMOVE PLASTIC PROPERTIES FROM ELASTIC PROPERTIES CLASS!!!

        public static double FirstMoment_Q(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab, double modRatio, bool composite, bool positiveMoment, double location)
        {
            double[] array = CompositeAndPositiveMoment(composite, positiveMoment);
            double NA = ElasticNeutralAxis(botFlange, web, topFlange, bolster, slab, modRatio,composite,positiveMoment);
            // component {area, dist to location}
            double[] slabC = { 0, 0 }, bolstC = { 0, 0 }, tFlangeC = { 0, 0 }, webC = { 0, 0 }, bFlangeC = { 0, 0 };
            double[] tFlangeT = { 0, 0 }, webT = { 0, 0 }, bFlangeT = { 0, 0 };
            if (NA <= location)
            {
                if (location >= slab.BotLocation)
                {
                    slabC[0] = slab.Area(modRatio) * (slab.TopLocation - location) / slab.y*array[0]*array[1];
                    slabC[1] = (slab.TopLocation - location) / 2;
                }
                else if (location >= bolster.BotLocation)
                {
                    slabC[0] = slab.Area(modRatio) * array[0] * array[1];
                    slabC[1] = slab.CG - location;
                    bolstC[0] = bolster.Area(modRatio)*(bolster.TopLocation - location) / bolster.y * array[0] * array[1];
                    bolstC[1] = (bolster.TopLocation - location) / 2;
                }
                else if (location >= topFlange.BotLocation)
                {
                    slabC[0] = slab.Area(modRatio) * array[0] * array[1];
                    slabC[1] = slab.CG - location;
                    bolstC[0] = bolster.Area(modRatio) * array[0] * array[1];
                    bolstC[1] = bolster.CG - location;
                    tFlangeC[0] = topFlange.Area()*(topFlange.TopLocation - location) / topFlange.y;
                    tFlangeC[1] = (topFlange.TopLocation - location) / 2;
                }
                else if (location >= web.BotLocation)
                {
                    slabC[0] = slab.Area(modRatio) * array[0] * array[1];
                    slabC[1] = slab.CG - location;
                    bolstC[0] = bolster.Area(modRatio) * array[0] * array[1];
                    bolstC[1] = bolster.CG - location;
                    tFlangeC[0] = topFlange.Area();
                    tFlangeC[1] = topFlange.CG - location;
                    webC[0] = web.Area()*(web.TopLocation - location) / web.y;
                    webC[1] = (web.TopLocation - location) / 2;
                }
                else
                {
                    slabC[0] = slab.Area(modRatio) * array[0] * array[1];
                    slabC[1] = slab.CG - location;
                    bolstC[0] = bolster.Area(modRatio) * array[0] * array[1];
                    bolstC[1] = bolster.CG - location;
                    tFlangeC[0] = topFlange.Area();
                    tFlangeC[1] = topFlange.CG - location;
                    webC[0] = web.Area();
                    webC[1] = web.CG - location;
                    bFlangeC[0] =  botFlange.Area()*(botFlange.TopLocation - location) / botFlange.y;
                    bFlangeC[1] = (botFlange.TopLocation - location) / 2;
                }
                return slabC[0] * slabC[1] + bolstC[0] * bolstC[1] + tFlangeC[0] * tFlangeC[1] + webC[0] * webC[1] + bFlangeC[0] * bFlangeC[1];
            }
            else
            {
                if (location <= botFlange.TopLocation)
                {
                    bFlangeT[0] = botFlange.Area()*(location - botFlange.BotLocation) / botFlange.y;
                    bFlangeT[1] = (location - botFlange.BotLocation) / 2;
                }
                else if (location <= web.TopLocation)
                {
                    bFlangeT[0] = botFlange.Area();
                    bFlangeT[1] = location - botFlange.CG;
                    webT[0] = web.Area()*(location - web.BotLocation) / web.y;
                    webT[1] = (location - web.BotLocation) / 2;
                }
                else if (location <= topFlange.TopLocation)
                {
                    bFlangeT[0] = botFlange.Area();
                    bFlangeT[1] = location - botFlange.CG;
                    webT[0] = web.Area();
                    webT[1] = location - web.CG;
                    tFlangeT[0] = topFlange.Area()*(location - topFlange.BotLocation) / topFlange.y;
                    tFlangeT[1] = (location - topFlange.BotLocation) / 2;
                }
                else
                {
                    bFlangeT[0] = botFlange.Area();
                    bFlangeT[1] = location - botFlange.CG;
                    webT[0] = web.Area();
                    webT[1] = location - web.CG;
                    tFlangeT[0] = topFlange.Area();
                    tFlangeT[1] = location - topFlange.CG;
                }
                return tFlangeT[0] * tFlangeT[1] + webT[0] * webT[1] + bFlangeT[0] * bFlangeT[1];
            }
        }
    }
}
