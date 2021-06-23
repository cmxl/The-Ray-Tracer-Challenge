namespace The_Ray_Tracer_Challenge
{
    public static class Transform
    {
        public static Matrix Translate(double x, double y, double z)
            => new(new double[4, 4]
                {
                    { 1, 0, 0, x },
                    { 0, 1, 0, y },
                    { 0, 0, 1, z },
                    { 0, 0, 0, 1 },
                });

        public static Matrix Scale(double x, double y, double z)
            => new(new double[4, 4]
                {
                    { x, 0, 0, 0 },
                    { 0, y, 0, 0 },
                    { 0, 0, z, 0 },
                    { 0, 0, 0, 1 },
                });
    }
}
