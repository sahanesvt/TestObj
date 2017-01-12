﻿using System;

namespace TestObjectClass2
{
    class Program
    {
        static void Main(string[] args)
        {
            BeamParts beamParts = new BeamParts();
            //CompositeBeam beam = new CompositeBeam();

            Console.WriteLine("Enter Bottom Flange Width : ");
            double width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Bottom Flange Thickness : ");
            double depth = Convert.ToDouble(Console.ReadLine());
            beamParts.BotFlange = new BotFlange(width, depth, 50);

            Console.WriteLine("Enter Web Thickness : ");
            width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Web Depth : ");
            depth = Convert.ToDouble(Console.ReadLine());
            beamParts.Web = new Web(depth, width, 50);

            Console.WriteLine("Enter Top Flange Width : ");
            width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Top Flange Thickness : ");
            depth = Convert.ToDouble(Console.ReadLine());
            beamParts.TopFlange = new TopFlange(width, depth, 50);

            Console.WriteLine("Enter Bolster Width : ");
            width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Bolster Depth : ");
            depth = Convert.ToDouble(Console.ReadLine());
            beamParts.Bolster = new Bolster(width, depth, 4);

            Console.WriteLine("Enter Slab Width : ");
            width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Slab Depth : ");
            depth = Convert.ToDouble(Console.ReadLine());
            beamParts.Slab = new Slab(width, depth, 4);

            CompositeBeam beam = new CompositeBeam(beamParts);

            Console.WriteLine("Beam Area is {0} in^2", Math.Round(beam.Area(8), 4));
            Console.WriteLine("Beam Neutral Axis is {0} in", Math.Round(beam.NA_Elastc(8), 4));
            Console.WriteLine("Beam Elastic Moment of Inertia is {0} in^4", Math.Round(beam.I_Elastic(8), 4));
            Console.WriteLine("Beam Top Flange Elastic Section Modulus is {0} in^3", Math.Round(beam.S_Elastic(8, beam.TopFlange.TopLocation),4));
            Console.WriteLine("Beam Bottom Flange Elastic Section Modulus is {0} in^3", Math.Round(beam.S_Elastic(8, beam.BotFlange.BotLocation),4));
            Console.WriteLine("Beam Neutral Axis is {0} in", Math.Round(beam.NA_Plastic(), 4));
            Console.WriteLine("Beam Plastic Moment is {0} kip-ft", Math.Round(beam.Mp(), 4));
            Console.Read();
        }
    }
}
