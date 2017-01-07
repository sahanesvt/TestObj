using System;

namespace TestObjectClass2
{
    public class Web : Rectangle
    {
        public Web(double depth, double thickness, double F_y)
            : base(depth, thickness, F_y)
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
