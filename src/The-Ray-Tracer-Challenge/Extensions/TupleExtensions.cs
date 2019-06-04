namespace The_Ray_Tracer_Challenge.Extensions
{
    public static class TupleExtensions
    {
        public static bool IsPoint(this Tuple tuple) => tuple.W.Equals(1.0);

        public static bool IsVector(this Tuple tuple) => tuple.W.Equals(0.0);

        public static Tuple Normalize(this Tuple tuple)
        {
            var magnitude = tuple.Magnitude;
            return new Tuple(tuple.X / magnitude,
                             tuple.Y / magnitude,
                             tuple.Z / magnitude,
                             tuple.W / magnitude);
        }

        public static double Magnitude(this Tuple tuple) => (
                                                       tuple.X.Square() +
                                                       tuple.Y.Square() +
                                                       tuple.Z.Square() +
                                                       tuple.W.Square()
                                                       ).SquareRoot();

        public static Tuple Add(this Tuple a, Tuple b) => new Tuple(a.X + b.X,
                         a.Y + b.Y,
                         a.Z + b.Z,
                         a.W + b.W);

        public static Tuple Negate(this Tuple a)
            => new Tuple(-a.X, -a.Y, -a.Z, -a.W);

        public static Tuple Subtract(this Tuple a, Tuple b)
            => new Tuple(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);

        public static Tuple MultiplyBy(this Tuple a, double b)
            => new Tuple(a.X * b, a.Y * b, a.Z * b, a.W * b);

        public static Tuple DivideBy(this Tuple a, double b)
            => new Tuple(a.X / b, a.Y / b, a.Z / b, a.W / b);

        /// <summary>
        /// e.g.: (1, 2, 3) * (2, 3, 4)
        /// </summary>
        /// <param name="a">Tuple a</param>
        /// <param name="b">Tuple b</param>
        /// <returns>Scalar product of Tuple a and b</returns>
        public static double ScalarProduct(this Tuple a, Tuple b)
            => a.X * b.X +
               a.Y * b.Y +
               a.Z * b.Z +
               a.W * b.W;

        /// <summary>
        /// e.g.: (1, 2, 3) x (2, 3, 4)
        /// </summary>
        /// <param name="a">Vector a</param>
        /// <param name="b">Vector b</param>
        /// <returns>Cross product of Vector a and b</returns>
        public static Tuple CrossProduct(this Tuple a, Tuple b)
            => Tuple.Vector(a.Y * b.Z - a.Z * b.Y,
                            a.Z * b.X - a.X * b.Z,
                            a.X * b.Y - a.Y * b.X);
    }
}
