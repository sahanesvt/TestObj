﻿using System;

namespace TestObjectClass2
{
    public class BotFlange : Rectangle
    {
        public BotFlange(double width, double depth, double F_y)
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


}
