using System;

namespace The_Ray_Tracer_Challenge.Extensions
{
    public static class MatrixExtensions
    {
        public static Matrix MultiplyBy(this Matrix a, Matrix b)
        {
            if (a.Columns != b.Rows)
                throw new InvalidOperationException($"Cannot multiply matrices with dimensions: [{a.Rows}, {a.Columns}] and [{b.Rows}, {b.Columns}]");

            var result = new Matrix(b.Rows, b.Columns);
            for (var row = 0; row < a.Rows; row++)
                for (var column = 0; column < b.Columns; column++)
                {
                    double value = 0;
                    for (var dim = 0; dim < b.Rows; dim++)
                        value += a[row, dim] * b[dim, column];
                    
                    result[row, column] = value;
                }
            return result;
        }
    }
}
