namespace The_Ray_Tracer_Challenge.Extensions
{
    public static class ColorExtensions
    {
        private static Color HadamardProduct(Color a, Color b)
            => new Color(a.Red * b.Red,
                         a.Green * b.Green,
                         a.Blue * b.Blue);

        public static Color MultiplyBy(this Color a, Color b)
            => HadamardProduct(a, b);
    }
}
