using NooBIT.Asserts;
using Xunit;

namespace The_Ray_Tracer_Challenge.Tests
{
    public class TupleOperationTests
    {
        [Fact]
        public void Adding_Two_Tuples()
        {
            var a = new Tuple(3, -2, 5, 1);
            var b = new Tuple(-2, 3, 1, 0);

            var c = a + b;
            var expected = new Tuple(1, 1, 6, 1);

            c.Should().Equal(expected);
        }

        [Fact]
        public void Subtracting_Two_Points_Results_In_Vector()
        {
            var pointA = Tuple.Point(3, 2, 1);
            var pointB = Tuple.Point(5, 6, 7);

            var pointC = pointA - pointB;
            var expected = Tuple.Vector(-2, -4, -6);

            pointC.Should().Equal(expected);
        }

        [Fact]
        public void Subtracting_Vector_From_Point_Results_In_Point()
        {
            var p = Tuple.Point(3, 2, 1);
            var v = Tuple.Vector(5, 6, 7);

            var point = p - v;
            var expected = Tuple.Point(-2, -4, -6);

            point.Should().Equal(expected);
        }

        [Fact]
        public void Subtracting_Two_Vectors_Results_In_Vector()
        {
            var v1 = Tuple.Vector(3, 2, 1);
            var v2 = Tuple.Vector(5, 6, 7);

            var vector = v1 - v2;
            var expected = Tuple.Vector(-2, -4, -6);

            vector.Should().Equal(expected);
        }

        [Fact]
        public void Subtracting_A_Vector_From_The_Zero_Vector_Results_In_Negation()
        {
            var zero = Tuple.Vector(0, 0, 0);
            var v = Tuple.Vector(1, -2, 3);

            var result = zero - v;
            var expected = Tuple.Vector(-1, 2, -3);
            var negated = -v;

            result.Should().Equal(expected).And.Equal(negated);
        }

        [Fact]
        public void Negating_A_Tuple()
        {
            var a = new Tuple(1, -2, 3, -4);

            var result = -a;
            var expected = new Tuple(-1, 2, -3, 4);

            result.Should().Equal(expected);
        }
    }
}
