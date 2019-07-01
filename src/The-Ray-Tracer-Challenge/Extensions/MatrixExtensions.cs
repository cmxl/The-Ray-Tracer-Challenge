using System;
using System.Linq;
using The_Ray_Tracer_Challenge.Comparisson;
using The_Ray_Tracer_Challenge.Constants;

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

        public static Matrix Transpose(this Matrix matrix)
        {
            var transposed = new Matrix(matrix.Columns, matrix.Rows);
            for (var row = 0; row < matrix.Rows; row++)
                for (var column = 0; column < matrix.Columns; column++)
                    transposed[column, row] = matrix[row, column];
            return transposed;
        }

        /// <summary>
        /// Calculates the determinant of a matrix. (ad - bc)
        /// </summary>
        /// <param name="matrix">The matrix</param>
        /// <returns>Determinant of the matrix</returns>
        public static double Determinant(this Matrix matrix)
        {
            if (!matrix.IsQuadratic)
                return 0;

            if (matrix.Dimension.x == 2)
            {
                return (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);
            }

            return Enumerable.Range(0, matrix.Columns)
                .Aggregate(0d, (det, column) => det + matrix[0, column] * matrix.Cofactor(0, column));
        }

        /// <summary>
        /// Will effectively remove one dimension from the input matrix.
        /// </summary>
        /// <param name="matrix">The matrix</param>
        /// <param name="row">Row to be removed from matrix</param>
        /// <param name="column">Column to be removed from matrix</param>
        /// <returns>A submatrix of the input matrix.</returns>
        public static Matrix SubMatrix(this Matrix matrix, int row, int column)
        {
            if (row >= matrix.Rows)
                throw new InvalidOperationException($"Matrix does only have {matrix.Rows} rows.");

            if (column >= matrix.Columns)
                throw new InvalidOperationException($"Matrix does only have {matrix.Columns} columns.");

            var submatrix = new Matrix(matrix.Rows - 1, matrix.Columns - 1);

            var rows = Enumerable.Range(0, matrix.Rows).Where(x => x != row).Select((item, index) => (row: item, index));
            var columns = Enumerable.Range(0, matrix.Columns).Where(x => x != column).Select((item, index) => (column: item, index));

            foreach (var r in rows)
                foreach (var c in columns)
                    submatrix[r.index, c.index] = matrix[r.row, c.column];

            return submatrix;
        }

        public static double Minor(this Matrix matrix, int row, int column)
            => matrix.SubMatrix(row, column).Determinant();

        public static double Cofactor(this Matrix matrix, int row, int column) 
            => (row + column) % 2 == 0 ? matrix.Minor(row, column) : -matrix.Minor(row, column);

        public static bool IsInvertible(this Matrix matrix)
            => matrix.Determinant() != 0;

        public static Matrix Invert(this Matrix matrix)
        {
            if (!matrix.IsInvertible())
                throw new InvalidOperationException("Cannot invert the given matrix. Determinant is zero.");

            var inverse = new Matrix(matrix.Rows, matrix.Columns);
            for (var row = 0; row < inverse.Rows; row++)
                for (var column = 0; column < inverse.Columns; column++)
                    inverse[column, row] = matrix.Cofactor(row, column) / matrix.Determinant();

            return inverse;
        }
    }
}
