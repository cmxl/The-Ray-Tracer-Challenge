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
            => new Tuple(a.X + b.X,
                         a.Y + b.Y,
                         a.Z + b.Z,
                         a.W + b.W);

        public static Tuple operator -(Tuple a)
            => new Tuple(-a.X, -a.Y, -a.Z, -a.W);

        public static Tuple operator -(Tuple a, Tuple b)
            => new Tuple(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
    }
}
