namespace The_Ray_Tracer_Challenge
{
    public struct Color
    {
        public Color(double red, double green, double blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public double Red { get; }
        public double Green { get; }
        public double Blue { get; }

        public static implicit operator Tuple(Color color) => new Tuple(color.Red, color.Green, color.Blue, 0);

        public override string ToString() => $"RGB({Red}, {Green}, {Blue})";
    }
}
