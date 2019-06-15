using System;

namespace The_Ray_Tracer_Challenge.Extensions
{
    public static class MathExtensions
    {
        public static double Square(this double x) => Math.Pow(x, 2);

        public static double SquareRoot(this double x) => Math.Sqrt(x);

        public static double Multiply(this double x, double factor)
            => x * factor;

        public static int Round(this double x)
            => (int)Math.Round(x);


        public static int Clamp(this double value, int minValue, int maxValue)
            => Clamp(value, minValue, maxValue);

        public static int Clamp(this int value, int minValue, int maxValue)
        {
            if (value > maxValue)
                return maxValue;

            if (value < minValue)
                return minValue;

            return value;
        }
    }
}
