using System;

namespace TestObjectClass2
{
    public abstract class Plate
    {
        public double x { get; set; }
        public double y { get; set; }
        public double Strength { get; set; }
        public double BotLocation { get; set; }
        public double CG { get; set; }
        public double TopLocation { get; set; }
        
        public Plate()
        {
            x = 0;
            y = 0;
            Strength = 0;
            BotLocation = 0;
            CG = 0;
            TopLocation = 0;
        }

        public Plate(double x, double y, double strength)
        {
            this.x = x;
            this.y = y;
            Strength = strength;
            BotLocation = 0;
            CG = 0;
            TopLocation = 0;
        }

        public virtual double Area()
        {
            return x * y;
        }
        public virtual double I_x()
        {
            return x * Math.Pow(y, 3) / 12;
        }
        public virtual double I_y()
        {
            return y * Math.Pow(x, 3) / 12;
        }
        public virtual double Force()
        {
            return Area() * Strength;
        }

    }

}
