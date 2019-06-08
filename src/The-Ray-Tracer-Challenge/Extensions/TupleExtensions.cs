namespace The_Ray_Tracer_Challenge.Extensions
{
    public static class TupleExtensions
    {
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
    }
}
