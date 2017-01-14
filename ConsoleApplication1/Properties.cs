using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestObjectClass2
{
    class Properties
    {

        public static double elasticNeutralAxis(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab, double modRatio)
        {
            return (botFlange.Area() * botFlange.CG + web.Area() * web.CG + topFlange.Area() * topFlange.CG + (bolster.Area() * bolster.CG + slab.Area() * slab.CG) / modRatio)
                           / (botFlange.Area() + web.Area() + topFlange.Area() + (bolster.Area() + slab.Area()) / modRatio);
        }


        public static double elasticMomentOfInertia(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab, double modRatio)
        {
            double NA = elasticNeutralAxis(botFlange, web, topFlange, bolster, slab, modRatio);
            return (botFlange.I_x() + botFlange.Area() * Math.Pow(botFlange.CG - NA, 2)
                    + web.I_x() + web.Area() * Math.Pow(web.CG - NA, 2)
                    + topFlange.I_x() + topFlange.Area() * Math.Pow(topFlange.CG - NA, 2)
                    + (bolster.I_x() + bolster.Area() * Math.Pow(bolster.CG - NA, 2)
                    + slab.I_x() + slab.Area() * Math.Pow(slab.CG - NA, 2)) / modRatio);

        }

        public static double[] plasticVariables(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab)
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

        public static double[] plasticTop(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab)
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
        }

        public static double[] plasticBottom(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab)
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

        }

        public static double plasticNeutralAxis(Plate botFlange, Plate web, Plate topFlange, Plate bolster, Plate slab)
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
        }
    }
}
