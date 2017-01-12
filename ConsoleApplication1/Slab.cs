using System;

namespace TestObjectClass2
{
    public class Slab : Plate
    {
        public Slab() : base() { }

        public Slab(double width, double depth, double f_c)
            : base(width, depth, f_c)
        {
            BotLocation = 0;
            CG = 0;
            TopLocation = 0;
        }
    }
}
