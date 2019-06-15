using System;

namespace The_Ray_Tracer_Challenge.Extensions
{
    public static class DoubleExtensions
    {
        public static bool Equals(this double a, double b, double tolerance)
            => Math.Abs(a - b) <= tolerance;
    }
}
