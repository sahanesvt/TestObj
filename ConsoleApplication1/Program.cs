using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestObjectClass2
{
 

    

    public class TopFlange_ : Rectangle
    {
        public TopFlange_(double width, double depth, double F_y)
            : base(width, depth, F_y)
        {
            this.BotLocation = 0;
            this.CG = 0;
            this.TopLocation = 0;
        }

        public override double Area()
        {
            return x * y;
        }
        public override double I_x()
        {
            return x * Math.Pow(y, 3) / 12;
        }
        public override double I_y()
        {
            return y * Math.Pow(x, 3) / 12;
        }
    }

    public class Bolster_ : Rectangle
    {

        public Bolster_(double width, double depth, double f_c)
            : base(width, depth, f_c)
        {
            this.BotLocation = 0;
            this.CG = 0;
            this.TopLocation = 0;
        }

        public override double Area()
        {
            return x * y;
        }
        public override double I_x()
        {
            return x * Math.Pow(y, 3) / 12;
        }
        public override double I_y()
        {
            return y * Math.Pow(x, 3) / 12;
        }
    }

    public class Slab_ : Rectangle
    {
        public Slab_(double width, double depth, double f_c)
            : base(width, depth, f_c)
        {
            this.BotLocation = 0;
            this.CG = 0;
            this.TopLocation = 0;
        }

        public override double Area()
        {
            return x * y;
        }
        public override double I_x()
        {
            return x * Math.Pow(y, 3) / 12;
        }
        public override double I_y()
        {
            return y * Math.Pow(x, 3) / 12;
        }
    }

    public class BeamParts
    {
        public BotFlange BotFlange { get; set; }
        public Web web { get; set; }
        public TopFlange_ TopFlange { get; set; }
        public Bolster_ Bolster { get; set; }
        public Slab_ Slab { get; set; }

        public BeamParts() { }

        public BeamParts(BotFlange botFlange, Web web, TopFlange_ topFlange, Bolster_ bolster, Slab_ slab)
        {
            BotFlange = botFlange;
            this.web = web;
            TopFlange = topFlange;
            Bolster = bolster;
            Slab = slab;
        }

    }


    public class Beam
    {
        public BotFlange botFlange { get; set; }
        public Web Web { get; set; }
        public TopFlange_ TopFlange { get; set; }
        public Bolster_ Bolster { get; set; }
        public Slab_ Slab { get; set; }

        public Beam()
        {
            botFlange = new BotFlange(0, 0, 0);
            Web = new Web(0, 0, 0);
            TopFlange = new TopFlange_(0, 0, 0);
            Bolster = new Bolster_(0, 0, 0);
            Slab = new Slab_(0, 0, 0);
        }

        public Beam(BeamParts beamParts)
        {
            botFlange = beamParts.BotFlange;
            Web = beamParts.web;
            TopFlange = beamParts.TopFlange;
            Bolster = beamParts.Bolster;
            Slab = beamParts.Slab;
            
            

            beamParts.BotFlange.BotLocation = 0;
            beamParts.BotFlange.CG = beamParts.BotFlange.y / 2;
            beamParts.BotFlange.TopLocation = beamParts.BotFlange.y;
            beamParts.web.BotLocation = beamParts.BotFlange.y;
            beamParts.web.CG = beamParts.BotFlange.y + beamParts.web.y / 2;
            beamParts.web.TopLocation = beamParts.BotFlange.y + beamParts.web.y;
            beamParts.TopFlange.BotLocation = beamParts.BotFlange.y + beamParts.web.y;
            beamParts.TopFlange.CG = beamParts.BotFlange.y + beamParts.web.y + beamParts.TopFlange.y / 2;
            beamParts.TopFlange.TopLocation = beamParts.BotFlange.y + beamParts.web.y + beamParts.TopFlange.y;
            beamParts.Bolster.BotLocation = beamParts.BotFlange.y + beamParts.web.y + beamParts.TopFlange.y;
            beamParts.Bolster.CG = beamParts.BotFlange.y + beamParts.web.y + beamParts.TopFlange.y + beamParts.Bolster.y / 2;
            beamParts.Bolster.TopLocation = beamParts.BotFlange.y + beamParts.web.y + beamParts.TopFlange.y + beamParts.Bolster.y;
            beamParts.Slab.BotLocation = beamParts.BotFlange.y + beamParts.web.y + beamParts.TopFlange.y + beamParts.Bolster.y;
            beamParts.Slab.CG = beamParts.BotFlange.y + beamParts.web.y + beamParts.TopFlange.y + beamParts.Bolster.y + beamParts.Slab.y / 2;
            beamParts.Slab.TopLocation = beamParts.BotFlange.y + beamParts.web.y + beamParts.TopFlange.y + beamParts.Bolster.y + beamParts.Slab.y;
        }

        public double Area(double modRatio)
        {
            return botFlange.Area() + Web.Area() + TopFlange.Area() + (Bolster.Area() + Slab.Area()) / modRatio;
        }
        public double NA(double modRatio)
        {
            return (botFlange.Area() * botFlange.CG + Web.Area() * Web.CG + TopFlange.Area() * TopFlange.CG + (Bolster.Area() * Bolster.CG + Slab.Area() * Slab.CG) / modRatio)
                            / (botFlange.Area() + Web.Area() + TopFlange.Area() + (Bolster.Area() + Slab.Area()) / modRatio);

        }
        public double I_Elastic(double modRatio)
        {
            double NA = this.NA(modRatio);
            return (botFlange.I_x() + botFlange.Area() * Math.Pow(botFlange.CG - NA, 2)
                    + Web.I_x() + Web.Area() * Math.Pow(Web.CG - NA, 2)
                    + TopFlange.I_x() + TopFlange.Area() * Math.Pow(TopFlange.CG - NA, 2)
                    + (Bolster.I_x() + Bolster.Area() * Math.Pow(Bolster.CG - NA, 2)
                    + Slab.I_x() + Slab.Area() * Math.Pow(Slab.CG - NA, 2)) / modRatio);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BeamParts beamParts = new BeamParts();

            Console.WriteLine("Enter Bottom Flange Width : ");
            double width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Bottom Flange Thickness : ");
            double depth = Convert.ToDouble(Console.ReadLine());
            beamParts.BotFlange = new BotFlange(width, depth, 50);

            Console.WriteLine("Enter Web Thickness : ");
            width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Web Depth : ");
            depth = Convert.ToDouble(Console.ReadLine());
            beamParts.web = new Web(width, depth, 4);

            Console.WriteLine("Enter Top Flange Width : ");
            width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Top Flange Thickness : ");
            depth = Convert.ToDouble(Console.ReadLine());
            beamParts.TopFlange = new TopFlange_(width, depth, 50);

            Console.WriteLine("Enter Bolster Width : ");
            width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Bolster Depth : ");
            depth = Convert.ToDouble(Console.ReadLine());
            beamParts.Bolster = new Bolster_(width, depth, 4);

            Console.WriteLine("Enter Slab Width : ");
            width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Slab Depth : ");
            depth = Convert.ToDouble(Console.ReadLine());
            beamParts.Slab = new Slab_(width, depth, 4);

            Beam beam = new Beam(beamParts);

            Console.WriteLine("Beam Area is {0} in^2", Math.Round(beam.Area(8), 4));
            Console.WriteLine("Beam Neutral Axis is {0} in", Math.Round(beam.NA(8), 4));
            Console.WriteLine("Beam Elastic Moment of Inertia is {0} in^4", Math.Round(beam.I_Elastic(8), 4));
            Console.Read();
        }
    }
}
