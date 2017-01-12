using System;

namespace TestObjectClass2
{
    public class Bolster : Plate
    {
        public Bolster() : base() { }

        public Bolster(double width, double depth, double f_c)
            : base(width, depth, f_c)
        {
            BotLocation = 0;
            CG = 0;
            TopLocation = 0;
        }
    }
}
