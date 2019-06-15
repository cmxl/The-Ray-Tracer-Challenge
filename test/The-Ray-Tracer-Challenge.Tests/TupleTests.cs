using NooBIT.Asserts;
using The_Ray_Tracer_Challenge.Extensions;
using Xunit;

namespace The_Ray_Tracer_Challenge.Tests
{
    public class TupleTests
    {
        [Fact]
        public void A_Tuple_With_W_Equals_One_Is_A_Point()
        {
            var a = new Tuple(4.3, -4.2, 3.1, 1.0);
            Assert.Equal(4.3, a.X);
            Assert.Equal(-4.2, a.Y);
            Assert.Equal(3.1, a.Z);
            Assert.Equal(1.0, a.W);
            Assert.True(a.IsPoint);
            Assert.False(a.IsVector);
        }

        [Fact]
        public void A_Tuple_With_W_Equals_Zero_Is_A_Vector()
        {
            var a = new Tuple(4.3, -4.2, 3.1, 0.0);
            Assert.Equal(4.3, a.X);
            Assert.Equal(-4.2, a.Y);
            Assert.Equal(3.1, a.Z);
            Assert.Equal(0.0, a.W);
            Assert.False(a.IsPoint);
            Assert.True(a.IsVector);
        }

        [Fact]
        public void Tuple_Point_Creates_A_Tuple_With_W_Equals_One()
        {
            var point = new Point(4, -4, 3);
            var expected = new Tuple(4, -4, 3, 1);

            point.X.Should().Be.Equal(4);
            point.Y.Should().Be.Equal(-4);
            point.Z.Should().Be.Equal(3);
            point.W.Should().Be.Equal(1);

            Assert.True(expected.IsPoint);
            Assert.False(expected.IsVector);

            point.Should().Equal(expected);
        }

        [Fact]
        public void Tuple_Vector_Creates_A_Tuple_With_W_Equals_Zero()
        {
            Tuple vector = new Vector(4, -4, 3);
            var expected = new Tuple(4, -4, 3, 0);

            vector.X.Should().Be.Equal(4);
            vector.Y.Should().Be.Equal(-4);
            vector.Z.Should().Be.Equal(3);
            vector.W.Should().Be.Equal(0);

            Assert.False(expected.IsPoint);
            Assert.True(expected.IsVector);

            vector.Should().Equal(expected);
        }

        [Fact]
        [Trait("Category", "Addition")]
        public void Adding_Two_Tuples()
        {
            var a = new Tuple(3, -2, 5, 1);
            var b = new Tuple(-2, 3, 1, 0);

            var c = a + b;
            var expected = new Tuple(1, 1, 6, 1);

            c.Should().Equal(expected);
        }

        [Fact]
        [Trait("Category", "Subtraction")]
        public void Subtracting_Two_Points_Results_In_Vector()
        {
            Tuple pointA = new Point(3, 2, 1);
            Tuple pointB = new Point(5, 6, 7);

            var pointC = pointA - pointB;
            var expected = new Vector(-2, -4, -6);

            pointC.Should().Equal(expected);
        }

        [Fact]
        [Trait("Category", "Subtraction")]
        public void Subtracting_Vector_From_Point_Results_In_Point()
        {
            Tuple p = new Point(3, 2, 1);
            Tuple v = new Vector(5, 6, 7);

            var point = p - v;
            var expected = new Point(-2, -4, -6);

            point.Should().Equal(expected);
        }

        [Fact]
        [Trait("Category", "Subtraction")]
        public void Subtracting_Two_Vectors_Results_In_Vector()
        {
            Tuple v1 = new Vector(3, 2, 1);
            Tuple v2 = new Vector(5, 6, 7);

            var vector = v1 - v2;
            var expected = new Vector(-2, -4, -6);

            vector.Should().Equal(expected);
        }

        [Fact]
        [Trait("Category", "Subtraction")]
        public void Subtracting_A_Vector_From_The_Zero_Vector_Results_In_Negation()
        {
            Tuple zero = new Vector(0, 0, 0);
            Tuple v = new Vector(1, -2, 3);

            var result = zero - v;
            var expected = new Vector(-1, 2, -3);
            var negated = -v;

            result.Should().Equal(expected).And.Equal(negated);
        }

        [Fact]
        [Trait("Category", "Negation")]
        public void Negating_A_Tuple()
        {
            var a = new Tuple(1, -2, 3, -4);

            var result = -a;
            var expected = new Tuple(-1, 2, -3, 4);

            result.Should().Equal(expected);
        }

        [Fact]
        [Trait("Category", "Multiplication")]
        public void Multiplying_A_Tuple_By_A_Scalar()
        {
            var a = new Tuple(1, -2, 3, -4);

            var result = a * 3.5;
            var expected = new Tuple(3.5, -7, 10.5, -14);

            result.Should().Equal(expected);
        }

        [Fact]
        [Trait("Category", "Multiplication")]
        public void Multiplying_A_Tuple_By_A_Fraction()
        {
            var a = new Tuple(1, -2, 3, -4);

            var result = a * 0.5;
            var expected = new Tuple(0.5, -1, 1.5, -2);

            result.Should().Equal(expected);
        }

        [Fact]
        [Trait("Category", "Division")]
        public void Dividing_A_Tuple_By_A_Scalar()
        {
            var a = new Tuple(1, -2, 3, -4);

            var result = a / 2;
            var expected = new Tuple(0.5, -1, 1.5, -2);

            result.Should().Equal(expected);
        }

        [Theory]
        [Trait("Category", "Magnitude")]
        [InlineData(1, 0, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 0, 1)]
        public void Magnitude_Of_Unit_Vectors_Should_Be_One(double x, double y, double z)
        {
            var v = new Vector(x, y, z);
            v.Magnitude.Should().Equal(1);
        }

        [Theory]
        [Trait("Category", "Magnitude")]
        [InlineData(1, 2, 3)]
        [InlineData(-1, -2, -3)]
        public void Computing_The_Magnitude_Of_Vector_1_2_3(double x, double y, double z)
        {
            var v = new Vector(x, y, z);
            v.Magnitude.Should().Equal(14.0d.SquareRoot());
        }

        [Fact]
        [Trait("Category", "Normalization")]
        public void Normalizing_Vector_4_0_0_Gives_1_0_0()
        {
            var v = new Vector(4, 0, 0);
            var expected = new Vector(1, 0, 0);
            v.Normalize().Should().Equal(expected);
        }

        [Fact]
        [Trait("Category", "Normalization")]
        public void Normalizing_Vector_1_2_3()
        {
            var v = new Vector(1, 2, 3);
            var result = v.Normalize();
            result.X.Should().Equal(0.26726, 5);
            result.Y.Should().Equal(0.53452, 5);
            result.Z.Should().Equal(0.80178, 5);
        }

        [Fact]
        [Trait("Category", "ScalarProduct")]
        public void Scalar_Product_Of_Two_Tuples()
        {
            Tuple a = new Vector(1, 2, 3);
            Tuple b = new Vector(2, 3, 4);

            var result = a.ScalarProduct(b);
            result.Should().Equal(20);
        }

        [Fact]
        [Trait("Category", "CrossProduct")]
        public void Cross_Product_Of_Two_Vectors()
        {
            var a = new Vector(1, 2, 3);
            var b = new Vector(2, 3, 4);

            var result = a.CrossProduct(b);
            var expected = new Vector(-1, 2, -1);
            result.Should().Equal(expected);

            var reversedResult = b.CrossProduct(a);
            var reversedExpected = new Vector(1, -2, 1);
            reversedResult.Should().Equal(reversedExpected);
        }
    }
}

