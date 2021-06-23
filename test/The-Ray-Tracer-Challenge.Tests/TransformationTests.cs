using NooBIT.Asserts;
using The_Ray_Tracer_Challenge.Extensions;
using Xunit;

namespace The_Ray_Tracer_Challenge.Tests
{
    public class TransformationTests
    {
        [Fact]
        public void Multiply_by_TranslationMatrix()
        {
            var transform = Transform.Translate(5, -3, 2);
            Tuple p = new Point(-3, 4, 5);
            Tuple result = transform * p;

            result.Should().Equal(new Point(2, 1, 7));
        }

        [Fact]
        public void Multiply_by_Inverse_of_TranslationMatrix()
        {
            var transform = Transform.Translate(5, -3, 2).Invert();
            Tuple p = new Point(-3, 4, 5);
            Tuple result = transform * p;

            result.Should().Equal(new Point(-8, 7, 3));
        }

        [Fact]
        public void Translation_does_not_affect_Vectors()
        {
            var transform = Transform.Translate(5, -3, 2);
            Tuple v = new Vector(-3, 4, 5);
            Tuple result = transform * v;

            result.Should().Equal(v);
        }

        [Fact]
        public void Scaling_Matrix_applied_to_Point()
        {
            var transform = Transform.Scale(2, 3, 4);
            Tuple point = new Point(-4, 6, 8);
            Tuple scaled = transform * point;

            scaled.Should().Equal(new Point(-8, 18, 32));
        }

        [Fact]
        public void Scaling_Matrix_applied_to_Vector()
        {
            var transform = Transform.Scale(2, 3, 4);
            Tuple point = new Vector(-4, 6, 8);
            Tuple scaled = transform * point;

            scaled.Should().Equal(new Vector(-8, 18, 32));
        }

        [Fact]
        public void Multiply_by_Inverse_of_Scaling_Matrix()
        {
            var transform = Transform.Scale(2, 3, 4).Invert();
            Tuple point = new Vector(-4, 6, 8);
            Tuple scaled = transform * point;

            scaled.Should().Equal(new Vector(-2, 2, 2));
        }

        [Fact]
        public void Reflection_is_scaling_by_negative_value()
        {
            var transform = Transform.Scale(-1, 1, 1);
            Tuple point = new Point(2, 3, 4);
            Tuple scaled = transform * point;

            scaled.Should().Equal(new Point(-2, 3, 4));
        }
    }
}
