using System;
using System.Collections.Generic;
using The_Ray_Tracer_Challenge.Extensions;

namespace The_Ray_Tracer_Challenge.Comparisson
{
    public class DoubleEqualityComparer : IEqualityComparer<double>
    {
        public static readonly double Delta = 0.000001;
        public static readonly int MaxDecimals = 5;

        public static readonly IEqualityComparer<double> Default = new DoubleEqualityComparer(Delta);

        private readonly double _delta;

        public DoubleEqualityComparer(double delta)
        {
            _delta = delta;
        }

        public bool Equals(double x, double y) => Math.Abs(Math.Round(x, MaxDecimals) - Math.Round(y, MaxDecimals)) <= Delta;

        public int GetHashCode(double obj) => HashCode.Combine(obj);
    }
}
