using NooBIT.Asserts;
using Xunit;

namespace The_Ray_Tracer_Challenge.Tests
{
    public class ColorTests
    {
        [Fact]
        public void Colors_Are_Red_Green_Blue_Tuples()
        {
            var color = new Color(-0.5, 0.4, 1.7);
            color.Red.Should().Equal(-0.5);
            color.Green.Should().Equal(0.4);
            color.Blue.Should().Equal(1.7);

            Tuple tuple = color;
            color.Red.Should().Equal(tuple.X);
            color.Green.Should().Equal(tuple.Y);
            color.Blue.Should().Equal(tuple.Z);
        }

        [Fact]
        public void Adding_Colors()
        {
            Tuple c1 = new Color(0.9, 0.6, 0.75);
            Tuple c2 = new Color(0.7, 0.1, 0.25);
            Color result = c1 + c2;
            var expected = new Color(1.6, 0.7, 1.0);

            result.Should().Equal(expected);
        }

        [Fact]
        public void Subtracting_Colors()
        {
            Tuple c1 = new Color(0.9, 0.6, 0.75);
            Tuple c2 = new Color(0.7, 0.1, 0.25);
            Color result = c1 - c2;
            var expected = new Color(0.9 - 0.7, 0.5, 0.5); // cheat the system due to inprecise double values

            result.Should().Equal(expected);
        }
    }
}
