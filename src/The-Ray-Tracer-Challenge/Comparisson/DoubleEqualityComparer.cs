using System;
using System.Collections.Generic;

namespace The_Ray_Tracer_Challenge.Comparisson
{
    public class DoubleEqualityComparer : IEqualityComparer<double>
    {
        public static readonly double Delta = 0.000001;
        public static readonly int MaxDecimals = 5;

        public static readonly IEqualityComparer<double> Default = new DoubleEqualityComparer(Delta, MaxDecimals);

        private readonly double _delta;
        private readonly int _decimals;

        public DoubleEqualityComparer(double delta, int decimals)
        {
            _delta = delta;
            _decimals = decimals;
        }

        public bool Equals(double x, double y) => Math.Abs(Math.Round(x, _decimals) - Math.Round(y, _decimals)) <= _delta;

        public int GetHashCode(double obj) => HashCode.Combine(obj);
    }
}
