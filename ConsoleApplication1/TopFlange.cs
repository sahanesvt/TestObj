using System;

namespace TestObjectClass2
{
    public class TopFlange : Plate
    {
        public TopFlange() : base() { }

        public TopFlange(double width, double depth, double F_y)
            : base(width, depth, F_y)
        {
            BotLocation = 0;
            CG = 0;
            TopLocation = 0;
        }
    }
}
