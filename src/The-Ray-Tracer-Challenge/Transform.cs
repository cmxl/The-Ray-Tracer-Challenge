using System;

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
        public static Matrix RotateX(double r)
            => new(new double[4, 4]
                {
                    { 1,           0,            0, 0 },
                    { 0, Math.Cos(r), -Math.Sin(r), 0 },
                    { 0, Math.Sin(r),  Math.Cos(r), 0 },
                    { 0,           0,            0, 1 },
                });

        public static Matrix RotateY(double r)
           => new(new double[4, 4]
               {
                    {  Math.Cos(r), 0, Math.Sin(r), 0 },
                    {            0, 1,           0, 0 },
                    { -Math.Sin(r), 0, Math.Cos(r), 0 },
                    {            0, 0,           0, 1 },
               });

        public static Matrix RotateZ(double r)
           => new(new double[4, 4]
               {
                    { Math.Cos(r), -Math.Sin(r), 0, 0 },
                    { Math.Sin(r),  Math.Cos(r), 0, 0 },
                    {           0,            0, 1, 0 },
                    {           0,            0, 0, 1 },
               });

        public static Matrix Shear((double y, double z) x, (double x, double z) y, (double x, double y) z)
            => new(new double[4, 4]
                {
                    {   1, x.y, x.z, 0 },
                    { y.x,   1, y.z, 0 },
                    { z.x, z.y,   1, 0 },
                    {   0,   0,   0, 1 },
                });

        public static Matrix ShearX(double y, double z)
            => new(new double[4, 4]
                {
                    { 1, y, z, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 },
                });

        public static Matrix ShearY(double x, double z)
            => new(new double[4, 4]
                {
                    { 1, 0, 0, 0 },
                    { x, 1, z, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 },
                });

        public static Matrix ShearZ(double x, double y)
            => new(new double[4, 4]
                {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { x, y, 1, 0 },
                    { 0, 0, 0, 1 },
                });

    }
}
