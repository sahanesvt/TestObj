namespace TestObjectClass2
{
    public abstract class Rectangle
    {
        public double x { get; set; }
        public double y { get; set; }
        public double strength { get; set; }
        public double BotLocation { get; set; }
        public double CG { get; set; }
        public double TopLocation { get; set; }

        public Rectangle(double x, double y, double strength)
        {
            this.x = x;
            this.y = y;
            this.strength = strength;
            this.BotLocation = 0;
            this.CG = 0;
            this.TopLocation = 0;
        }

        public abstract double Area();
        public abstract double I_x();
        public abstract double I_y();

    }

}
