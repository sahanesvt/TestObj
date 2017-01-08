using System;

namespace TestObjectClass2
{
     public class CompositeBeam
    {
        public BotFlange botFlange { get; set; }
        public Web web { get; set; }
        public TopFlange topFlange { get; set; }
        public Bolster bolster { get; set; }
        public Slab slab { get; set; }

        public CompositeBeam()
        {
            botFlange = new BotFlange(0, 0, 0);
            web = new Web(0, 0, 0);
            topFlange = new TopFlange(0, 0, 0);
            bolster = new Bolster(0, 0, 0);
            slab = new Slab(0, 0, 0);
        }

        public CompositeBeam(BeamParts beamParts)
        {
            botFlange = beamParts.botFlange_;
            web = beamParts.web_;
            topFlange = beamParts.topFlange_;
            bolster = beamParts.bolster_;
            slab = beamParts.slab_;



            beamParts.botFlange_.BotLocation = 0;
            beamParts.botFlange_.CG = beamParts.botFlange_.y / 2;
            beamParts.botFlange_.TopLocation = beamParts.botFlange_.y;
            beamParts.web_.BotLocation = beamParts.botFlange_.y;
            beamParts.web_.CG = beamParts.botFlange_.y + beamParts.web_.y / 2;
            beamParts.web_.TopLocation = beamParts.botFlange_.y + beamParts.web_.y;
            beamParts.topFlange_.BotLocation = beamParts.botFlange_.y + beamParts.web_.y;
            beamParts.topFlange_.CG = beamParts.botFlange_.y + beamParts.web_.y + beamParts.topFlange_.y / 2;
            beamParts.topFlange_.TopLocation = beamParts.botFlange_.y + beamParts.web_.y + beamParts.topFlange_.y;
            beamParts.bolster_.BotLocation = beamParts.botFlange_.y + beamParts.web_.y + beamParts.topFlange_.y;
            beamParts.bolster_.CG = beamParts.botFlange_.y + beamParts.web_.y + beamParts.topFlange_.y + beamParts.bolster_.y / 2;
            beamParts.bolster_.TopLocation = beamParts.botFlange_.y + beamParts.web_.y + beamParts.topFlange_.y + beamParts.bolster_.y;
            beamParts.slab_.BotLocation = beamParts.botFlange_.y + beamParts.web_.y + beamParts.topFlange_.y + beamParts.bolster_.y;
            beamParts.slab_.CG = beamParts.botFlange_.y + beamParts.web_.y + beamParts.topFlange_.y + beamParts.bolster_.y + beamParts.slab_.y / 2;
            beamParts.slab_.TopLocation = beamParts.botFlange_.y + beamParts.web_.y + beamParts.topFlange_.y + beamParts.bolster_.y + beamParts.slab_.y;
        }

        public double Area(double modRatio)
        {
            return botFlange.Area() + web.Area() + topFlange.Area() + (bolster.Area() + slab.Area()) / modRatio;
        }
        public double NA(double modRatio)
        {
            return (botFlange.Area() * botFlange.CG + web.Area() * web.CG + topFlange.Area() * topFlange.CG + (bolster.Area() * bolster.CG + slab.Area() * slab.CG) / modRatio)
                            / (botFlange.Area() + web.Area() + topFlange.Area() + (bolster.Area() + slab.Area()) / modRatio);

        }
        public double I_Elastic(double modRatio)
        {
            double NA = this.NA(modRatio);
            return (botFlange.I_x() + botFlange.Area() * Math.Pow(botFlange.CG - NA, 2)
                    + web.I_x() + web.Area() * Math.Pow(web.CG - NA, 2)
                    + topFlange.I_x() + topFlange.Area() * Math.Pow(topFlange.CG - NA, 2)
                    + (bolster.I_x() + bolster.Area() * Math.Pow(bolster.CG - NA, 2)
                    + slab.I_x() + slab.Area() * Math.Pow(slab.CG - NA, 2)) / modRatio);
        }
    }
}
