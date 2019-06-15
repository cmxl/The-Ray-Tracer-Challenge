using NooBIT.Asserts;
using System.Collections;
using Xunit;

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
    }
}
