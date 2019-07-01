using System;
using System.Collections.Generic;
using The_Ray_Tracer_Challenge.Comparisson;
using The_Ray_Tracer_Challenge.Constants;

namespace The_Ray_Tracer_Challenge.Extensions
{
    public static class DoubleExtensions
    {
        public static bool Equals(this double a, double b, IEqualityComparer<double> comparer)
           => comparer.Equals(a, b);
    }
}
