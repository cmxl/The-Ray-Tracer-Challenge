using System;
using The_Ray_Tracer_Challenge.Comparisson;
using The_Ray_Tracer_Challenge.Constants;
using The_Ray_Tracer_Challenge.Extensions;

namespace The_Ray_Tracer_Challenge
{
    public struct Vector : IEquatable<Vector>
    {
        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            W = 0;
        }

        public double X { get; }
        public double Y { get; }
        public double Z { get; }
        public double W { get; }

        public double Magnitude => this.Magnitude();

        public bool Equals(Vector other)
            => DoubleEqualityComparer.Default.Equals(X, other.X) &&
               DoubleEqualityComparer.Default.Equals(Y, other.Y) &&
               DoubleEqualityComparer.Default.Equals(Z, other.Z) &&
               DoubleEqualityComparer.Default.Equals(W, other.W);

        public override bool Equals(object obj) => Equals((Vector)obj);
        public override int GetHashCode() => HashCode.Combine(X, Y, Z, W);
        public static bool operator ==(Vector left, Vector right) => left.Equals(right);
        public static bool operator !=(Vector left, Vector right) => !(left == right);
        public static implicit operator Tuple(Vector vector) => new Tuple(vector.X, vector.Y, vector.Z, vector.W);
        public override string ToString() => $"Vector({X}, {Y}, {Z})";

        
    }
}
