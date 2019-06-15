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

        public double X { get; }
        public double Y { get; }
        public double Z { get; }
        public double W { get; }

        public bool IsPoint => W == 1;
        public bool IsVector => W == 0;

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

        public static implicit operator Point(Tuple tuple)
        {
            if (tuple.IsPoint)
            {
                return new Point(tuple.X, tuple.Y, tuple.Z);
            }
            throw new System.NotSupportedException();
        }

        public static implicit operator Vector(Tuple tuple)
        {
            if (tuple.IsVector)
            {
                return new Vector(tuple.X, tuple.Y, tuple.Z);
            }
            throw new System.NotSupportedException();
        }

        public static implicit operator Color(Tuple tuple) => new Color(tuple.X, tuple.Y, tuple.Z);

        public static implicit operator Matrix(Tuple tuple) => new Matrix(new double[4, 1] {
            { tuple.X },
            { tuple.Y },
            { tuple.Z },
            { tuple.W }
        });

        public override string ToString() => $"Tuple({X},{Y},{Z},{W})";
    }
}
