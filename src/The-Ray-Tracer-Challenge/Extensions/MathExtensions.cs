using System;

namespace The_Ray_Tracer_Challenge.Extensions
{
    public static class MathExtensions
    {
        public static double Square(this double x) => Math.Pow(x, 2);

        public static double SquareRoot(this double x) => Math.Sqrt(x);
    }
}
