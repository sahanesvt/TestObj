using System;

namespace TestObjectClass2
{
    public class Web : Plate
    {
        public Web() : base()
        {
            ElastMod = 29000;
        }

        public Web(double depth, double thickness, double F_y)
            : base(thickness, depth, F_y)
        {
            BotLocation = 0;
            CG = 0;
            TopLocation = 0;
            ElastMod = 29000;
        }
    }
}
