using System;
using System.Collections.Generic;

namespace TestObjectClass2
{
    public class Reinforcing
    {
        private double area = 0;
        private double strength = 0;
        private double distToSlab = 0;
        private bool distToTopOfSlab = true;
        private double location = 0;
        public double Area { get; set; }
        public double Strength { get; set; }
        public double DistToSlab { get; set; }
        public bool DistToTopOfSlab { get; set; }
        public double Location { get; set; }
        public double Force { get; set; }

        public Reinforcing()
        {
            Area = area;
            Strength = strength;
            DistToSlab = distToSlab;
            DistToTopOfSlab = distToTopOfSlab;
            Location = location;
            Force = area * strength;
        }

        public Reinforcing(double area, double strength, double distToSlab, bool distToTopOfSlab)
        {
            Area = area;
            Strength = strength;
            DistToSlab = distToSlab;
            DistToTopOfSlab = distToTopOfSlab;
            Location = location;
            Force = area * strength;
        }

        /*public Reinforcing(double area, double strength, double distToSlab, Slab slab, bool distToTopOfSlab)
        {
            Area = area;
            Strength = strength;
            DistToTopOfSlab = distToTopOfSlab;
            if (distToTopOfSlab)
            {
                Location = slab.TopLocation - distToSlab;
            }
            else
            {
                Location = slab.BotLocation + distToSlab;
            }
        }

        public double Force()
        {
            return Area * Strength;
        }

        public void Add(double area, double distToSlab, Slab slab, bool distToTopOfSlab)
        {
            if (distToTopOfSlab)
            {
                Location = (Area * Location + area * (slab.TopLocation - distToSlab)) / (Area + area);
            }
            else
            {
                Location = (Area * Location + area * (slab.BotLocation + distToSlab)) / (Area + area);
            }
            Area += area;
        }*/
    }
}
