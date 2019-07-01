using NooBIT.Asserts;
using The_Ray_Tracer_Challenge.Extensions;
using The_Ray_Tracer_Challenge.Comparisson;
using Xunit;
using The_Ray_Tracer_Challenge.Constants;
using System.Linq;
using System;

namespace The_Ray_Tracer_Challenge.Tests
{
    public class MatrixTests
    {
        [Fact]
        public void Constructing_And_Inspecting_A_4x4_Matrix()
        {
            var matrix = new Matrix(new double[4, 4]
            {
                {    1,     2,     3,      4 },
                {  5.5,   6.5,   7.5,    8.5 },
                {    9,    10,    11,     12 },
                { 13.5,  14.5,  15.5,   16.5 }
            });

            matrix[0, 0].Should().Equal(1);
            matrix[0, 3].Should().Equal(4);
            matrix[1, 0].Should().Equal(5.5);
            matrix[1, 2].Should().Equal(7.5);
            matrix[2, 2].Should().Equal(11);
            matrix[3, 0].Should().Equal(13.5);
            matrix[3, 2].Should().Equal(15.5);
        }

        [Fact]
        public void Constructing_And_Inspecting_A_2x2_Matrix()
        {
            var matrix = new Matrix(new double[2, 2]
            {
                { -3,  5 },
                {  1, -2 }
            });

            matrix[0, 0].Should().Equal(-3);
            matrix[0, 1].Should().Equal(5);
            matrix[1, 0].Should().Equal(1);
            matrix[1, 1].Should().Equal(-2);
        }

        [Fact]
        public void Constructing_And_Inspecting_A_3x3_Matrix()
        {
            var matrix = new Matrix(new double[3, 3]
            {
                { -3,  5,  0 },
                {  1, -2, -7 },
                {  0,  1,  1 }
            });

            matrix[0, 0].Should().Equal(-3);
            matrix[1, 1].Should().Equal(-2);
            matrix[2, 2].Should().Equal(1);
        }

        [Fact]
        public void Matrix_Equality_With_Identical_Matrices()
        {
            var a = new Matrix(new double[4, 4]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 8, 7, 6 },
                { 5, 4, 3, 2 }
            });

            var b = new Matrix(new double[4, 4]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 8, 7, 6 },
                { 5, 4, 3, 2 }
            });
            a.Should().Equal(b);
        }

        [Fact]
        public void Matrix_Equality_With_Different_Matrices()
        {
            var a = new Matrix(new double[4, 4]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 8, 7, 6 },
                { 5, 4, 3, 2 }
            });

            var b = new Matrix(new double[4, 4]
            {
                { 2, 3, 4, 5 },
                { 6, 7, 8, 9 },
                { 8, 7, 6, 5 },
                { 4, 3, 2, 1 }
            });
            a.Should().Not.Equal(b);
        }

        [Fact]
        public void Multiplying_Two_Matrices()
        {
            var a = new Matrix(new double[4, 4]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 8, 7, 6 },
                { 5, 4, 3, 2 }
            });

            var b = new Matrix(new double[4, 4]
            {
                { -2, 1, 2,  3 },
                {  3, 2, 1, -1 },
                {  4, 3, 6,  5 },
                {  1, 2, 7,  8 }
            });

            var result = a * b;

            var expected = new Matrix(new double[4, 4]
            {
                { 20, 22,  50,  48 },
                { 44, 54, 114, 108 },
                { 40, 58, 110, 102 },
                { 16, 26,  46,  42 }
            });

            result.Should().Equal(expected);
        }

        [Fact]
        public void Multiplying_Matrix_By_Tuple()
        {
            var a = new Matrix(new double[4, 4]
            {
                { 1, 2, 3, 4 },
                { 2, 4, 4, 2 },
                { 8, 6, 4, 1 },
                { 0, 0, 0, 1 }
            });

            var b = new Tuple(1, 2, 3, 1);

            var result = a * b;
            var expected = new Tuple(18, 24, 33, 1);

            result.Should().Equal(expected);
        }

        [Fact]
        public void Multiplying_Matrix_By_IdentityMatrix()
        {
            var a = new Matrix(new double[4, 4]
            {
                { 0, 1,  2,  4 },
                { 1, 2,  4,  8 },
                { 2, 4,  8, 16 },
                { 4, 8, 16, 32 }
            });

            var result = a * Matrix.IdentityMatrix(4);
            result.Should().Equal(a);
        }

        [Fact]
        public void Multiplying_Vector_By_IdentityMatrix()
        {
            var a = new Tuple(1, 2, 3, 4);
            var result = Matrix.IdentityMatrix(4) * a;
            result.Should().Equal(a);
        }

        [Fact]
        public void Transposing_A_Matrix()
        {
            var a = new Matrix(new double[4, 4]
            {
                { 0, 9, 3, 0 },
                { 9, 8, 0, 8 },
                { 1, 8, 5, 3 },
                { 0, 0, 5, 8 }
            });

            var expected = new Matrix(new double[4, 4]
            {
                { 0, 9, 1, 0 },
                { 9, 8, 8, 0 },
                { 3, 0, 5, 5 },
                { 0, 8, 3, 8 }
            });

            var result = a.Transpose();
            result.Should().Equal(expected);
        }

        [Fact]
        public void Transposing_The_IdentityMatrix()
        {
            var identity = Matrix.IdentityMatrix(4);
            identity.Transpose().Should().Equal(identity);
        }

        [Fact]
        public void Calculating_Determinant_Of_2x2_Matrix()
        {
            var a = new Matrix(new double[2, 2]
            {
                {  1, 5 },
                { -3, 2 }
            });

            var determinant = a.Determinant();
            determinant.Should().Equal(17);
        }

        [Fact]
        public void Submatrix_Of_3x3_Matrix_Is_2x2_Matrix()
        {
            var matrix = new Matrix(new double[3, 3]
            {
                {  1, 5,  0 },
                { -3, 2,  7 },
                {  0, 6, -3 }
            });

            var submatrix = matrix.SubMatrix(0, 2);

            var expected = new Matrix(new double[2, 2]
            {
                { -3, 2 },
                {  0, 6 }
            });

            submatrix.Should().Equal(expected);
        }

        [Fact]
        public void Submatrix_Of_4x4_Matrix_Is_3x3_Matrix()
        {
            var matrix = new Matrix(new double[4, 4]
            {
                { -6, 1,  1, 6 },
                { -8, 5,  8, 6 },
                { -1, 0,  8, 2 },
                { -7, 1, -1, 1 }
            });

            var submatrix = matrix.SubMatrix(2, 1);

            var expected = new Matrix(new double[3, 3]
            {
                { -6,  1, 6 },
                { -8,  8, 6 },
                { -7, -1, 1 }
            });

            submatrix.Should().Equal(expected);
        }

        [Fact]
        public void Caclulating_A_Minor_Of_3x3_Matrix()
        {
            var matrix = new Matrix(new double[3, 3]
            {
                { 3,  5,  0 },
                { 2, -1, -7 },
                { 6, -1,  5 }
            });

            var submatrix = matrix.SubMatrix(1, 0);
            var determinant = submatrix.Determinant();
            var minor = matrix.Minor(1, 0);

            determinant.Should().Equal(minor);
            determinant.Should().Equal(25);
        }

        [Fact]
        public void Caclulating_A_Cofactor_Of_3x3_Matrix()
        {
            var matrix = new Matrix(new double[3, 3]
            {
                { 3,  5,  0 },
                { 2, -1, -7 },
                { 6, -1,  5 }
            });

            matrix.Minor(0, 0).Should().Equal(matrix.Cofactor(0, 0)).And.Equal(-12);
            matrix.Minor(1, 0).Should().Equal(-matrix.Cofactor(1, 0)).And.Equal(25);
        }

        [Fact]
        public void Caclulating_The_Determinant_Of_3x3_Matrix()
        {
            var matrix = new Matrix(new double[3, 3]
            {
                {  1, 2,  6 },
                { -5, 8, -4 },
                {  2, 6,  4 }
            });

            matrix.Cofactor(0, 0).Should().Equal(56);
            matrix.Cofactor(0, 1).Should().Equal(12);
            matrix.Cofactor(0, 2).Should().Equal(-46);
            matrix.Determinant().Should().Equal(-196);
        }

        [Fact]
        public void Caclulating_The_Determinant_Of_4x4_Matrix()
        {
            var matrix = new Matrix(new double[4, 4]
            {
                { -2, -8,  3,  5 },
                { -3,  1,  7,  3 },
                {  1,  2, -9,  6 },
                { -6,  7,  7, -9 }
            });

            matrix.Cofactor(0, 0).Should().Equal(690);
            matrix.Cofactor(0, 1).Should().Equal(447);
            matrix.Cofactor(0, 2).Should().Equal(210);
            matrix.Cofactor(0, 3).Should().Equal(51);
            matrix.Determinant().Should().Equal(-4071);
        }

        [Fact]
        public void Is_Matrix_Invertible()
        {
            var matrix = new Matrix(new double[4, 4]
            {
                { 6,  4, 4,  4 },
                { 5,  5, 7,  6 },
                { 4, -9, 3, -7 },
                { 9,  1, 7, -6 }
            });

            matrix.Determinant().Should().Equal(-2120);
            matrix.IsInvertible().Should().Equal(true);
        }

        [Fact]
        public void Is_Matrix_Not_Invertible()
        {
            var matrix = new Matrix(new double[4, 4]
            {
                { -4,  2, -2, -3 },
                {  9,  6,  2,  6 },
                {  0, -5,  1, -5 },
                {  0,  0,  0,  0 }
            });

            matrix.Determinant().Should().Equal(0);
            matrix.IsInvertible().Should().Equal(false);
        }

        [Fact]
        public void Calculating_Inverse_Of_Matrix()
        {
            var matrix = new Matrix(new double[4, 4]
            {
                { -5,  2,  6, -8 },
                {  1, -5,  1,  8 },
                {  7,  7, -6, -7 },
                {  1, -3,  7,  4 }
            });

            var inverse = new Matrix(new double[4, 4]
            {
                {  0.21805,  0.45113,  0.24060, -0.04511 },
                { -0.80827, -1.45677, -0.44361,  0.52068 },
                { -0.07895, -0.22368, -0.05263,  0.19737 },
                { -0.52256, -0.81391, -0.30075,  0.30639 }
            });

            matrix.Determinant().Should().Equal(532);
            matrix.Cofactor(2, 3).Should().Equal(-160);
            matrix.Cofactor(3, 2).Should().Equal(105);

            var b = matrix.Invert();

            DoubleEqualityComparer.Default.Equals(b[3, 2], -160d / 532d).Should().Be.True();
            DoubleEqualityComparer.Default.Equals(b[2, 3], 105d / 532d).Should().Be.True();

            b.Should().Equal(inverse);
        }
    }
}


