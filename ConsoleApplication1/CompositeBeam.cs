using System;

namespace TestObjectClass2
{
     public class CompositeBeam
    {
        public static BotFlange botFlange_ { get; set; }
        public static Web web_ { get; set; }
        public static TopFlange topFlange_ { get; set; }
        public static Bolster bolster_ { get; set; }
        public static Slab slab_ { get; set; }

        public CompositeBeam()
        {
            botFlange_ = new BotFlange(0, 0, 0);
            web_ = new Web(0, 0, 0);
            topFlange_ = new TopFlange(0, 0, 0);
            bolster_ = new Bolster(0, 0, 0);
            slab_ = new Slab(0, 0, 0);

            botFlange_.botLocation = 0;
            botFlange_.CG = botFlange_.y / 2;
            botFlange_.topLocation = botFlange_.y;
            web_.botLocation = botFlange_.y;
            web_.CG = botFlange_.y + web_.y / 2;
            web_.topLocation = botFlange_.y + web_.y;
            topFlange_.botLocation = botFlange_.y + web_.y;
            topFlange_.CG = botFlange_.y + web_.y + topFlange_.y / 2;
            topFlange_.topLocation = botFlange_.y + web_.y + topFlange_.y;
            bolster_.botLocation = botFlange_.y + web_.y + topFlange_.y;
            bolster_.CG = botFlange_.y + web_.y + topFlange_.y + bolster_.y / 2;
            bolster_.topLocation = botFlange_.y + web_.y + topFlange_.y + bolster_.y;
            slab_.botLocation = botFlange_.y + web_.y + topFlange_.y + bolster_.y;
            slab_.CG = botFlange_.y + web_.y + topFlange_.y + bolster_.y + slab_.y / 2;
            slab_.topLocation = botFlange_.y + web_.y + topFlange_.y + bolster_.y + slab_.y;
        }

        public CompositeBeam(BeamParts beamParts)
        {
            botFlange_ = beamParts.botFlange_;
            web_ = beamParts.web_;
            topFlange_ = beamParts.topFlange_;
            bolster_ = beamParts.bolster_;
            slab_ = beamParts.slab_;

            beamParts.botFlange_.botLocation = 0;
            beamParts.botFlange_.CG = beamParts.botFlange_.y / 2;
            beamParts.botFlange_.topLocation = beamParts.botFlange_.y;
            beamParts.web_.botLocation = beamParts.botFlange_.y;
            beamParts.web_.CG = beamParts.botFlange_.y + beamParts.web_.y / 2;
            beamParts.web_.topLocation = beamParts.botFlange_.y + beamParts.web_.y;
            beamParts.topFlange_.botLocation = beamParts.botFlange_.y + beamParts.web_.y;
            beamParts.topFlange_.CG = beamParts.botFlange_.y + beamParts.web_.y + beamParts.topFlange_.y / 2;
            beamParts.topFlange_.topLocation = beamParts.botFlange_.y + beamParts.web_.y + beamParts.topFlange_.y;
            beamParts.bolster_.botLocation = beamParts.botFlange_.y + beamParts.web_.y + beamParts.topFlange_.y;
            beamParts.bolster_.CG = beamParts.botFlange_.y + beamParts.web_.y + beamParts.topFlange_.y + beamParts.bolster_.y / 2;
            beamParts.bolster_.topLocation = beamParts.botFlange_.y + beamParts.web_.y + beamParts.topFlange_.y + beamParts.bolster_.y;
            beamParts.slab_.botLocation = beamParts.botFlange_.y + beamParts.web_.y + beamParts.topFlange_.y + beamParts.bolster_.y;
            beamParts.slab_.CG = beamParts.botFlange_.y + beamParts.web_.y + beamParts.topFlange_.y + beamParts.bolster_.y + beamParts.slab_.y / 2;
            beamParts.slab_.topLocation = beamParts.botFlange_.y + beamParts.web_.y + beamParts.topFlange_.y + beamParts.bolster_.y + beamParts.slab_.y;
        }

        public double Area(double modRatio)
        {
            return botFlange_.Area() + web_.Area() + topFlange_.Area() + (bolster_.Area() + slab_.Area()) / modRatio;
        }

        private static double neutralAxis(Rectangle botFlange, Rectangle web, Rectangle topFlange, Rectangle bolster, Rectangle slab, double modRatio)
        {
            return (botFlange.Area() * botFlange.CG + web.Area() * web.CG + topFlange.Area() * topFlange.CG + (bolster.Area() * bolster.CG + slab.Area() * slab.CG) / modRatio)
                           / (botFlange.Area() + web.Area() + topFlange.Area() + (bolster.Area() + slab.Area()) / modRatio);
        }

        private static double momentOfInertia(Rectangle botFlange, Rectangle web, Rectangle topFlange, Rectangle bolster, Rectangle slab, double modRatio)
        {
            double NA = neutralAxis(botFlange_, web_, topFlange_, bolster_, slab_, modRatio);
            return (botFlange.I_x() + botFlange.Area() * Math.Pow(botFlange.CG - NA, 2)
                    + web.I_x() + web.Area() * Math.Pow(web.CG - NA, 2)
                    + topFlange.I_x() + topFlange.Area() * Math.Pow(topFlange.CG - NA, 2)
                    + (bolster.I_x() + bolster.Area() * Math.Pow(bolster.CG - NA, 2)
                    + slab.I_x() + slab.Area() * Math.Pow(slab.CG - NA, 2)) / modRatio);

        }
        
        public double NA(double modRatio)
        {
            return neutralAxis(botFlange_, web_, topFlange_, bolster_, slab_, modRatio);
        }


        public double I_Elastic(double modRatio)
        {
            return momentOfInertia(botFlange_, web_, topFlange_, bolster_, slab_, modRatio);
        }
   

        /*public abstract class CompositeRectangle:Rectangle
        {

            CompositeRectangle(Rectangle rectangle)
                : base(rectangle.x, rectangle.y, rectangle.strength_) { }

            public virtual double S_top(double modRatio)
            {
                double NA = neutralAxis(botFlange_, web_, topFlange_, bolster_, slab_, modRatio);
                double i_elastic = momentOfInertia(botFlange_, web_, topFlange_, bolster_, slab_, modRatio);
                return i_elastic / (topLocation);
            }

            public virtual double S_CG(double modRatio)
            {
                double NA = neutralAxis(botFlange_, web_, topFlange_, bolster_, slab_, modRatio);
                double i_elastic = momentOfInertia(botFlange_, web_, topFlange_, bolster_, slab_, modRatio);
                return i_elastic / (CG);
            }
            public virtual double S_bot(double modRatio)
            {
                double NA = neutralAxis(botFlange_, web_, topFlange_, bolster_, slab_, modRatio);
                double i_elastic = momentOfInertia(botFlange_, web_, topFlange_, bolster_, slab_, modRatio);
                return i_elastic / (botLocation);
            }
        }
        public class CompositeTopFlange : CompositeRectangle
        {
            public CompositeTopFlange(TopFlange topFlange) { }
        }*/

    }
}
