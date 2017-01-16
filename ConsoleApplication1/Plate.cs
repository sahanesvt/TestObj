using System;

namespace TestObjectClass2
{
    public abstract class Plate
    {
        public double x { get; set; }
        public double y { get; set; }
        public double Strength { get; set; }
        public double ElastMod { get; set; }
        public double BotLocation { get; set; }
        public double CG { get; set; }
        public double TopLocation { get; set; }
        
        public Plate()
        {
            x = 0;
            y = 0;
            Strength = 0;
            ElastMod = 0;
            BotLocation = 0;
            CG = 0;
            TopLocation = 0;
        }

        public Plate(double x, double y, double strength)
        {
            this.x = x;
            this.y = y;
            Strength = strength;
            ElastMod = 0;
            BotLocation = 0;
            CG = 0;
            TopLocation = 0;
        }

        public Plate(double x, double y, double strength, double elastMod)
        {
            this.x = x;
            this.y = y;
            Strength = strength;
            ElastMod = elastMod;
            BotLocation = 0;
            CG = 0;
            TopLocation = 0;
        }



        public virtual double Area()
        {
            return x * y;
        }
        public virtual double Area(double modRatio)
        {
            return x * y / modRatio;
        }
        public virtual double I_x()
        {
            return x * Math.Pow(y, 3) / 12;
        }
        public virtual double I_x(double modRatio)
        {
            return x * Math.Pow(y, 3) / 12 / modRatio;
        }
        public virtual double I_y()
        {
            return y * Math.Pow(x, 3) / 12;
        }
        public virtual double I_y(double modRatio)
        {
            return y * Math.Pow(x, 3) / 12 / modRatio;
        }
        public virtual double Force()
        {
            return Area() * Strength;
        }
        public virtual double Force(double adjust)
        {
            return Area() * Strength * adjust;
        }

    }

}
