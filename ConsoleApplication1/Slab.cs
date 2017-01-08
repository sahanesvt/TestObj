using System;

namespace TestObjectClass2
{
    public class Slab : Rectangle
    {
        public Slab(double width, double depth, double f_c)
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
}
