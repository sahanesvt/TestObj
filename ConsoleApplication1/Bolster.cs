﻿using System;

namespace TestObjectClass2
{
    public class Bolster : Rectangle
    {
        public Bolster(double width, double depth, double f_c)
            : base(width, depth, f_c)
        {
            botLocation = 0;
            CG = 0;
            topLocation = 0;
        }
    }
}
