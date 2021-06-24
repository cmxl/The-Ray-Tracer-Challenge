using NooBIT.Asserts;
using System;
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

        [Fact]
        public void Rotating_Point_Around_X_Axis()
        {
            var halfQuarter = Transform.RotateX(Math.PI / 4);
            var fullQuarter = Transform.RotateX(Math.PI / 2);
            Tuple p = new Point(0, 1, 0);
            Tuple p1 = halfQuarter * p;
            Tuple p2 = fullQuarter * p;

            p1.Should().Equal(new Point(0, Math.Sqrt(2) / 2, Math.Sqrt(2) / 2));
            p2.Should().Equal(new Point(0, 0, 1));
        }

        [Fact]
        public void Rotating_Point_Around_Inverse_X_Axis()
        {
            var halfQuarter = Transform.RotateX(Math.PI / 4).Invert();
            Tuple p = new Point(0, 1, 0);
            Tuple p1 = halfQuarter * p;

            p1.Should().Equal(new Point(0, Math.Sqrt(2) / 2, -Math.Sqrt(2) / 2));
        }

        [Fact]
        public void Rotating_Point_Around_Y_Axis()
        {
            var halfQuarter = Transform.RotateY(Math.PI / 4);
            var fullQuarter = Transform.RotateY(Math.PI / 2);
            Tuple p = new Point(0, 0, 1);
            Tuple p1 = halfQuarter * p;
            Tuple p2 = fullQuarter * p;

            p1.Should().Equal(new Point(Math.Sqrt(2) / 2, 0, Math.Sqrt(2) / 2));
            p2.Should().Equal(new Point(1, 0, 0));
        }

        [Fact]
        public void Rotating_Point_Around_Z_Axis()
        {
            var halfQuarter = Transform.RotateZ(Math.PI / 4);
            var fullQuarter = Transform.RotateZ(Math.PI / 2);
            Tuple p = new Point(0, 1, 0);
            Tuple p1 = halfQuarter * p;
            Tuple p2 = fullQuarter * p;

            p1.Should().Equal(new Point(-Math.Sqrt(2) / 2, Math.Sqrt(2) / 2, 0));
            p2.Should().Equal(new Point(-1, 0, 0));
        }

        [Fact]
        public void Shearing_moves_x_in_proportion_to_y()
        {
            var shearing = Transform.Shear((1, 0), (0, 0), (0, 0));
            var shearingX = Transform.ShearX(1, 0);
            Tuple p = new Point(2, 3, 4);
            Tuple p1 = shearing * p;
            Tuple p2 = shearingX * p;

            p1.Should().Equal(new Point(5, 3, 4));
            p2.Should().Equal(p1);
        }

        [Fact]
        public void Shearing_moves_x_in_proportion_to_z()
        {
            var shearing = Transform.Shear((0, 1), (0, 0), (0, 0));
            var shearingX = Transform.ShearX(0, 1);
            Tuple p = new Point(2, 3, 4);
            Tuple p1 = shearing * p;
            Tuple p2 = shearingX * p;

            p1.Should().Equal(new Point(6, 3, 4));
            p2.Should().Equal(p1);
        }

        [Fact]
        public void Shearing_moves_y_in_proportion_to_x()
        {
            var shearing = Transform.Shear((0, 0), (1, 0), (0, 0));
            var shearingX = Transform.ShearY(1, 0);
            Tuple p = new Point(2, 3, 4);
            Tuple p1 = shearing * p;
            Tuple p2 = shearingX * p;

            p1.Should().Equal(new Point(2, 5, 4));
            p2.Should().Equal(p1);
        }

        [Fact]
        public void Shearing_moves_y_in_proportion_to_z()
        {
            var shearing = Transform.Shear((0, 0), (0, 1), (0, 0));
            var shearingX = Transform.ShearY(0, 1);
            Tuple p = new Point(2, 3, 4);
            Tuple p1 = shearing * p;
            Tuple p2 = shearingX * p;

            p1.Should().Equal(new Point(2, 7, 4));
            p2.Should().Equal(p1);
        }

        [Fact]
        public void Shearing_moves_z_in_proportion_to_x()
        {
            var shearing = Transform.Shear((0, 0), (0, 0), (1, 0));
            var shearingX = Transform.ShearZ(1, 0);
            Tuple p = new Point(2, 3, 4);
            Tuple p1 = shearing * p;
            Tuple p2 = shearingX * p;

            p1.Should().Equal(new Point(2, 3, 6));
            p2.Should().Equal(p1);
        }

        [Fact]
        public void Shearing_moves_z_in_proportion_to_y()
        {
            var shearing = Transform.Shear((0, 0), (0, 0), (0, 1));
            var shearingX = Transform.ShearZ(0, 1);
            Tuple p = new Point(2, 3, 4);
            Tuple p1 = shearing * p;
            Tuple p2 = shearingX * p;

            p1.Should().Equal(new Point(2, 3, 7));
            p2.Should().Equal(p1);
        }

        [Fact]
        public void Individual_Transforms_Are_Applied_In_Sequence()
        {
            Tuple p = new Point(1, 0, 1);
            var a = Transform.RotateX(Math.PI / 2);
            var b = Transform.Scale(5, 5, 5);
            var c = Transform.Translate(10, 5, 7);

            Tuple p2 = a * p;
            p2.Should().Equal(new Point(1, -1, 0));

            Tuple p3 = b * p2;
            p3.Should().Equal(new Point(5, -5, 0));

            Tuple p4 = c * p3;
            p4.Should().Equal(new Point(15, 0, 7));
        }

        [Fact]
        public void Chained_Transforms_Must_Be_Applied_In_Reverse_Order()
        {
            Tuple p = new Point(1, 0, 1);
            var a = Transform.RotateX(Math.PI / 2);
            var b = Transform.Scale(5, 5, 5);
            var c = Transform.Translate(10, 5, 7);

            var t = c * b * a;
            Tuple p2 = t * p;
            p2.Should().Equal(new Point(15, 0, 7));
        }
    }
}
