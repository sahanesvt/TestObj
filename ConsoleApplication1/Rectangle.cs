using System;

namespace TestObjectClass2
{
    public abstract class Rectangle
    {
        public double x { get; set; }
        public double y { get; set; }
        public double strength_ { get; set; }
        public double botLocation { get; set; }
        public double CG { get; set; }
        public double topLocation { get; set; }
        
        public Rectangle(double x, double y, double strength)
        {
            this.x = x;
            this.y = y;
            strength_ = strength;
            botLocation = 0;
            CG = 0;
            topLocation = 0;
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
        public virtual double S_top(double modRatio)
        {
            return 0;
        }
        //public virtual double S_CG(double modRatio)
        //{
        //    return 0;
        //}
        //public virtual double S_bot(double modRatio)
        //{
        //    return 0;
        //}

    }

}
