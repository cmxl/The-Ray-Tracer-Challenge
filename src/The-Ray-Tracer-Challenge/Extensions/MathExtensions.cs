using System;

namespace The_Ray_Tracer_Challenge.Extensions
{
    public static class MathExtensions
    {
        public static double Square(this double x) => Math.Pow(x, 2);

        public static double SquareRoot(this double x) => Math.Sqrt(x);

        public static int Clamp(this double value, int minValue = 0, int maxValue = 255)
        {
            var rgb = (int)Math.Ceiling(maxValue * value);

            if (rgb > maxValue)
                return maxValue;

            if (rgb < minValue)
                return minValue;

            return rgb;
        }
    }
}
