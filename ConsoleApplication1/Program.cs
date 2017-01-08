using System;

namespace TestObjectClass2
{
    class Program
    {
        static void Main(string[] args)
        {
            BeamParts beamParts = new BeamParts();

            Console.WriteLine("Enter Bottom Flange Width : ");
            double width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Bottom Flange Thickness : ");
            double depth = Convert.ToDouble(Console.ReadLine());
            beamParts.botFlange_ = new BotFlange(width, depth, 50);

            Console.WriteLine("Enter Web Thickness : ");
            width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Web Depth : ");
            depth = Convert.ToDouble(Console.ReadLine());
            beamParts.web_ = new Web(width, depth, 4);

            Console.WriteLine("Enter Top Flange Width : ");
            width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Top Flange Thickness : ");
            depth = Convert.ToDouble(Console.ReadLine());
            beamParts.topFlange_ = new TopFlange(width, depth, 50);

            Console.WriteLine("Enter Bolster Width : ");
            width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Bolster Depth : ");
            depth = Convert.ToDouble(Console.ReadLine());
            beamParts.bolster_ = new Bolster(width, depth, 4);

            Console.WriteLine("Enter Slab Width : ");
            width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Slab Depth : ");
            depth = Convert.ToDouble(Console.ReadLine());
            beamParts.slab_ = new Slab(width, depth, 4);

            CompositeBeam beam = new CompositeBeam(beamParts);

            Console.WriteLine("Beam Area is {0} in^2", Math.Round(beam.Area(8), 4));
            Console.WriteLine("Beam Neutral Axis is {0} in", Math.Round(beam.NA(8), 4));
            Console.WriteLine("Beam Elastic Moment of Inertia is {0} in^4", Math.Round(beam.I_Elastic(8), 4));
            Console.Read();
        }
    }
}
