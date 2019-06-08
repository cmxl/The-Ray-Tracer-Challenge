namespace The_Ray_Tracer_Challenge.Extensions
{
    public static class VectorExtensions
    {
        public static double Magnitude(this Vector vector) => (
                                                       vector.X.Square() +
                                                       vector.Y.Square() +
                                                       vector.Z.Square() +
                                                       vector.W.Square()
                                                       ).SquareRoot();

        public static Vector Normalize(this Vector vector)
        {
            var magnitude = vector.Magnitude;
            return new Vector(vector.X / magnitude,
                             vector.Y / magnitude,
                             vector.Z / magnitude);
        }

        /// <summary>
        /// e.g.: (1, 2, 3) x (2, 3, 4)
        /// </summary>
        /// <param name="a">Vector a</param>
        /// <param name="b">Vector b</param>
        /// <returns>Cross product of Vector a and b</returns>
        public static Vector CrossProduct(this Vector a, Vector b)
            => new Vector(a.Y * b.Z - a.Z * b.Y,
                            a.Z * b.X - a.X * b.Z,
                            a.X * b.Y - a.Y * b.X);
    }
}
