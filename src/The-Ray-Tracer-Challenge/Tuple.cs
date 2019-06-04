using The_Ray_Tracer_Challenge.Extensions;

namespace The_Ray_Tracer_Challenge
{
    public struct Tuple
    {
        public Tuple(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double W { get; set; }

        public double Magnitude => this.Magnitude();

        public static Tuple Point(double x, double y, double z)
            => new Tuple(x, y, z, 1.0);

        public static Tuple Vector(double x, double y, double z)
            => new Tuple(x, y, z, 0.0);

        public bool Equals(Tuple other)
            => X == other.X
                && Y == other.Y
                && Z == other.Z
                && W == other.W;

        public override bool Equals(object obj)
            => Equals((Tuple)obj);

        public override int GetHashCode() => base.GetHashCode();

        public static bool operator ==(Tuple a, Tuple b)
            => a.Equals(b);

        public static bool operator !=(Tuple a, Tuple b)
            => !a.Equals(b);

        public static Tuple operator +(Tuple a, Tuple b)
            => a.Add(b);

        public static Tuple operator -(Tuple a)
            => a.Negate();

        public static Tuple operator -(Tuple a, Tuple b)
            => a.Subtract(b);

        public static Tuple operator *(Tuple a, double b)
            => a.MultiplyBy(b);

        public static Tuple operator /(Tuple a, double b)
            => a.DivideBy(b);
    }
}
