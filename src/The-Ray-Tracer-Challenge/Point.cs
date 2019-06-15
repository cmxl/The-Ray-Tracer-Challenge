using System;
using The_Ray_Tracer_Challenge.Constants;
using The_Ray_Tracer_Challenge.Extensions;

namespace The_Ray_Tracer_Challenge
{
    public struct Point : IEquatable<Point>
    {
        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            W = 1;
        }

        public double X { get; }
        public double Y { get; }
        public double Z { get; }
        public double W { get; }

        public bool Equals(Point other)
            => X.Equals(other.X, MathConstants.DELTA) &&
               Y.Equals(other.Y, MathConstants.DELTA) &&
               Z.Equals(other.Z, MathConstants.DELTA) &&
               W.Equals(other.W, MathConstants.DELTA);

        public override bool Equals(object obj) => Equals((Point)obj);
        public override int GetHashCode() => HashCode.Combine(X, Y, Z, W);
        public static bool operator ==(Point left, Point right) => left.Equals(right);
        public static bool operator !=(Point left, Point right) => !(left == right);
        public static implicit operator Tuple(Point point) => new Tuple(point.X, point.Y, point.Z, point.W);
        public override string ToString() => $"Point({X}, {Y}, {Z})";
    }
}
