using System;
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

        public override bool Equals(object obj) => Equals((Vector)obj);
        public bool Equals(Vector other) => X == other.X && Y == other.Y && Z == other.Z && W == other.W;
        public override int GetHashCode() => HashCode.Combine(X, Y, Z, W);
        public static bool operator ==(Vector left, Vector right) => left.Equals(right);
        public static bool operator !=(Vector left, Vector right) => !(left == right);

        public static implicit operator Tuple(Vector vector) => new Tuple(vector.X, vector.Y, vector.Z, vector.W);
    }
}
