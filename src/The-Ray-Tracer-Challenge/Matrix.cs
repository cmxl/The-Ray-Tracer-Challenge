using System;
using System.Collections;
using System.Linq;
using The_Ray_Tracer_Challenge.Comparisson;
using The_Ray_Tracer_Challenge.Extensions;

namespace The_Ray_Tracer_Challenge
{
    public struct Matrix : IEquatable<Matrix>, IEnumerable
    {
        private readonly double[,] _matrix;

        public Matrix(double[,] matrix)
        {
            _matrix = matrix;
        }

        public Matrix(int rows, int columns)
        {
            _matrix = new double[rows, columns];
        }

        public int Rows => _matrix.GetLength(0);
        public int Columns => _matrix.GetLength(1);
        public (int x, int y) Dimension => (x: Rows, y: Columns);
        public bool IsQuadratic => Rows == Columns;

        public double this[int x, int y]
        {
            get => _matrix[x, y];
            set => _matrix[x, y] = value;
        }

        public bool Equals(Matrix other)
        {
            var matrix = _matrix;

            var sameRank = matrix.Rank == other._matrix.Rank;
            var sameDimension = Enumerable.Range(0, matrix.Rank).All(dimension => matrix.GetLength(dimension) == other._matrix.GetLength(dimension));

            var sequence = matrix.Cast<double>();
            var otherSequence = other.Cast<double>();
            var sequenceEqual = sequence.SequenceEqual(otherSequence, DoubleEqualityComparer.Default);

            return sameRank && sameDimension && sequenceEqual;
        }

        public override bool Equals(object obj) => obj is Matrix matrix && Equals(matrix);
        public override int GetHashCode() => HashCode.Combine(_matrix);
        public IEnumerator GetEnumerator() => _matrix.GetEnumerator();
        public static bool operator ==(Matrix a, Matrix b) => a.Equals(b);
        public static bool operator !=(Matrix a, Matrix b) => !a.Equals(b);
        public static Matrix operator *(Matrix a, Matrix b) => a.MultiplyBy(b);

        public static Matrix operator *(Matrix a, double factor)
        {
            var result = a;
            for (var row = 0; row < result.Rows; row++)
                for (var column = 0; column < result.Columns; column++)
                    result[row, column] *= factor;

            return result;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            var result = a;
            for (var row = 0; row < result.Rows; row++)
                for (var column = 0; column < result.Columns; column++)
                    result[row, column] += b[row, column];

            return result;
        }



        public static Matrix operator /(Matrix a, double quotient)
            => a * (1 / quotient);

        public static implicit operator Tuple(Matrix matrix)
        {
            if (matrix.Columns == 1 && matrix.Rows == 4)
                return new Tuple(
                     matrix[0, 0],
                     matrix[1, 0],
                     matrix[2, 0],
                     matrix[3, 0]
                );
            throw new NotSupportedException($"A matrix with dimensions [{matrix.Rows},{matrix.Columns}] is not a Tuple!");
        }

        public static Matrix IdentityMatrix(int dimension)
        {
            var matrix = new Matrix(dimension, dimension);
            for (var i = 0; i < dimension; i++)
                matrix[i, i] = 1;
            return matrix;
        }
    }
}
