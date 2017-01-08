using System;

namespace TestObjectClass2
{
    public class Web : Rectangle
    {
        public Web(double depth, double thickness, double F_y)
            : base(thickness, depth, F_y)
        {
            botLocation = 0;
            CG = 0;
            topLocation = 0;
        }
    }
}
