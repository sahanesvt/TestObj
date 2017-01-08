using System;

namespace TestObjectClass2
{
    public class TopFlange : Rectangle
    {
        public TopFlange(double width, double depth, double F_y)
            : base(width, depth, F_y)
        {
            botLocation = 0;
            CG = 0;
            topLocation = 0;
        }
    }
}
