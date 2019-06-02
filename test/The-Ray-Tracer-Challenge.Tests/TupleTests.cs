using NooBIT.Asserts;
using The_Ray_Tracer_Challenge.Helpers;
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
            Assert.True(TupleHelper.IsPoint(a));
            Assert.False(TupleHelper.IsVector(a));
        }

        [Fact]
        public void A_Tuple_With_W_Equals_Zero_Is_A_Vector()
        {
            var a = new Tuple(4.3, -4.2, 3.1, 0.0);
            Assert.Equal(4.3, a.X);
            Assert.Equal(-4.2, a.Y);
            Assert.Equal(3.1, a.Z);
            Assert.Equal(0.0, a.W);
            Assert.False(TupleHelper.IsPoint(a));
            Assert.True(TupleHelper.IsVector(a));
        }

        [Fact]
        public void Tuple_Point_Creates_A_Tuple_With_W_Equals_One()
        {
            var point = Tuple.Point(4, -4, 3);
            var expected = new Tuple(4, -4, 3, 1);

            point.X.Should().Be.Equal(4);
            point.Y.Should().Be.Equal(-4);
            point.Z.Should().Be.Equal(3);
            point.W.Should().Be.Equal(1);

            Assert.True(TupleHelper.IsPoint(point));
            Assert.False(TupleHelper.IsVector(point));

            point.Should().Equal(expected);
        }

        [Fact]
        public void Tuple_Vector_Creates_A_Tuple_With_W_Equals_Zero()
        {
            var vector = Tuple.Vector(4, -4, 3);
            var expected = new Tuple(4, -4, 3, 0);

            vector.X.Should().Be.Equal(4);
            vector.Y.Should().Be.Equal(-4);
            vector.Z.Should().Be.Equal(3);
            vector.W.Should().Be.Equal(0);

            Assert.False(TupleHelper.IsPoint(vector));
            Assert.True(TupleHelper.IsVector(vector));

            vector.Should().Equal(expected);
        }
    }
}

