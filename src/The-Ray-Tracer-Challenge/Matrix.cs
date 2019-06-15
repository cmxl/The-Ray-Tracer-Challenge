﻿using System;
using System.Collections;
using System.Linq;
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

        public double this[int x, int y]
        {
            get => _matrix[x, y];
            set => _matrix[x, y] = value;
        }

        public override bool Equals(object obj)
            => obj is Matrix matrix && Equals(matrix);

        public bool Equals(Matrix other)
        {
            var matrix = _matrix;
            return matrix.Rank == other._matrix.Rank &&
                 Enumerable.Range(0, matrix.Rank).All(dimension => matrix.GetLength(dimension) == other._matrix.GetLength(dimension)) &&
                 matrix.Cast<double>().SequenceEqual(other._matrix.Cast<double>());
        }

        public override int GetHashCode()
            => HashCode.Combine(_matrix);
        public IEnumerator GetEnumerator() => _matrix.GetEnumerator();

        public static bool operator ==(Matrix a, Matrix b)
            => a.Equals(b);

        public static bool operator !=(Matrix a, Matrix b)
            => !a.Equals(b);

        public static Matrix operator *(Matrix a, Matrix b)
            => a.MultiplyBy(b);

        public static implicit operator Tuple(Matrix matrix)
        {
            if (matrix.Columns == 1 && matrix.Rows == 4)
                return new Tuple(
                     matrix[0, 0],
                     matrix[1, 0],
                     matrix[2, 0],
                     matrix[3, 0]
                );
            throw new NotSupportedException();
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