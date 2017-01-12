using System;

namespace TestObjectClass2
{
    public class BotFlange : Plate
    {
        public BotFlange() : base() { }

        public BotFlange(double width, double depth, double F_y)
            : base(width, depth, F_y)
        {
            BotLocation = 0;
            CG = 0;
            TopLocation = 0;
        }
    }


}
