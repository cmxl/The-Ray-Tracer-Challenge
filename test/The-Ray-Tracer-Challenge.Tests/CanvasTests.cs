using NooBIT.Asserts;
using System.IO;
using The_Ray_Tracer_Challenge.Constants;
using The_Ray_Tracer_Challenge.ImageFormatters;
using Xunit;

namespace The_Ray_Tracer_Challenge.Tests
{
    public class CanvasTests
    {
        [Fact]
        public void Creating_A_Canvas()
        {
            var canvas = new Canvas(10, 20);
            canvas.Width.Should().Equal(10);
            canvas.Height.Should().Equal(20);

            for (var i = 0; i < canvas.Width; i++)
                for (var j = 0; j < canvas.Height; j++)
                    canvas[i, j].Should().Equal(Colors.Black);
        }

        [Fact]
        public void Constructing_PPM_Header()
        {
            var canvas = new Canvas(5, 3);
            var formatter = new PPMImageFormatter();
            var image = (PPMImage)formatter.CreateImage(canvas);
            using (var sr = new StringReader(image.Content))
            {
                sr.ReadLine().Should().Equal("P3");
                sr.ReadLine().Should().Equal("5 3");
                sr.ReadLine().Should().Equal("255");
            }
        }

        [Fact]
        public void Constructing_PPM_Pixel_Data()
        {
            var canvas = new Canvas(5, 3);
            var c1 = new Color(1.5, 0, 0);
            var c2 = new Color(0, 0.5, 0);
            var c3 = new Color(-0.5, 0, 1);

            canvas[0, 0] = c1;
            canvas[2, 1] = c2;
            canvas[4, 2] = c3;

            var formatter = new PPMImageFormatter();
            var image = (PPMImage)formatter.CreateImage(canvas);
            using (var sr = new StringReader(image.Content))
            {
                // omit header
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();

                // real data
                var content1 = sr.ReadLine();
                var content2 = sr.ReadLine();
                var content3 = sr.ReadLine();

                content1.Should().Equal("255 0 0 0 0 0 0 0 0 0 0 0 0 0 0");
                content2.Should().Equal("0 0 0 0 0 0 0 128 0 0 0 0 0 0 0");
                content3.Should().Equal("0 0 0 0 0 0 0 0 0 0 0 0 0 0 255");
            }
        }

        [Fact]
        public void Splitting_Long_Lines_In_PPM_Files()
        {
            var canvas = new Canvas(10, 2);
            var color = new Color(1, 0.8, 0.6);

            for (var i = 0; i < canvas.Width; i++)
                for (var j = 0; j < canvas.Height; j++)
                    canvas[i, j] = color;


            var formatter = new PPMImageFormatter();
            var image = (PPMImage)formatter.CreateImage(canvas);
            using (var sr = new StringReader(image.Content))
            {
                // omit header
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();

                // real data
                var content = sr.ReadToEnd();

                var expected =
                    @"255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204
153 255 204 153 255 204 153 255 204 153 255 204 153
255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204
153 255 204 153 255 204 153 255 204 153 255 204 153
";

                content.Should().Equal(expected);
            }
        }

        [Fact]
        public void PPM_Files_Are_Terminated_By_NewLine_Character()
        {
            var canvas = new Canvas(5, 3);
            var formatter = new PPMImageFormatter();
            var image = (PPMImage)formatter.CreateImage(canvas);
            using (var sr = new StringReader(image.Content))
            {
                var content = sr.ReadToEnd();
                content[content.Length - 1].Should().Equal('\n');
            }
        }
    }
}

