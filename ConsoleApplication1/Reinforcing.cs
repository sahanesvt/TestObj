using System;
using System.Collections.Generic;

namespace TestObjectClass2
{
    class Reinforcing
    {
        private double area = 0;
        private double distToSlab = 0;
        private double strength = 0;
        private bool distToTopOfSlab = true;
        private double location = 0;
        public double Area { get; set; }
        public double DistToSlab { get; set; }
        public double Strength { get; set; }
        public bool DistToTopOfSlab { get; set; }
        public double Location { get; set; }

        public Reinforcing()
        {
            Area = area;
            DistToSlab = distToSlab;
            Strength = strength;
            DistToTopOfSlab = distToTopOfSlab;
            Location = location;
        }

        public Reinforcing(double area, double distToSlab, double strength, bool distToTopOfSlab)
        {
            Area = area;
            DistToSlab = distToSlab;
            Strength = strength;
            DistToTopOfSlab = distToTopOfSlab;
            Location = location;
        }

        public double Force()
        {
            return Area * Strength;
        }
    }
}
