using System;
using System.Collections.Generic;
using The_Ray_Tracer_Challenge.Constants;
using The_Ray_Tracer_Challenge.Extensions;

namespace The_Ray_Tracer_Challenge.ImageFormatters
{
    public class PPMImageFormatter : IImageFormatter
    {
        private static readonly string _identifier = "P3";
        private static readonly int _maximumColorValue = ValueRanges.Rgb.Max;
        private static readonly int _maximumCharactersPerLine = 70;
        private static readonly string _newLine = Environment.NewLine;

        public IImage CreateImage(Canvas canvas)
        {
            var header = WriteHeader(canvas.Width, canvas.Height);
            var content = WriteContent(canvas);
            var image = string.Join(_newLine, new[] { header, content }) + _newLine;
            return new PPMImage(image);
        }

        private string WriteHeader(int width, int height)
            => $"{_identifier}{_newLine}{width} {height}{_newLine}{_maximumColorValue}";

        private string WriteContent(Canvas canvas)
        {
            var lines = WriteLines(canvas);
            return string.Join(_newLine, lines);
        }

        private IEnumerable<string> WriteLines(Canvas canvas)
        {
            for (var y = 0; y < canvas.Height; y++)
            {
                yield return WriteLine(canvas, y);
            }
        }

        private string WriteLine(Canvas canvas, int y)
        {
            var colorComponents = new List<int>();
            for (var x = 0; x < canvas.Width; x++)
            {
                var color = canvas[x, y];
                colorComponents.AddRange(ColorToRgbArray(color));
            }

            var line = string.Join(' ', colorComponents);
            if (line.Length <= _maximumCharactersPerLine)
                return line;

            return WrapLine(line, _maximumCharactersPerLine, _maximumColorValue.ToString().Length);
        }

        private string WrapLine(string line, int maxLength, int componentLength)
        {
            var lines = new List<string>();
            while (line.Length > maxLength)
            {
                var spaceIndex = line.IndexOf(' ', maxLength - componentLength);
                var currentLine = line.Substring(0, spaceIndex);
                lines.Add(currentLine);
                line = line.PermissiveSubstring(spaceIndex + 1, line.Length - spaceIndex);
            }
            lines.Add(line);
            return string.Join(_newLine, lines);
        }

        private int[] ColorToRgbArray(Color color)
            => new[] {
                color.Red.Multiply(ValueRanges.Rgb.Max).Round().Clamp(ValueRanges.Rgb.Min, ValueRanges.Rgb.Max),
                color.Green.Multiply(ValueRanges.Rgb.Max).Round().Clamp(ValueRanges.Rgb.Min, ValueRanges.Rgb.Max),
                color.Blue.Multiply(ValueRanges.Rgb.Max).Round().Clamp(ValueRanges.Rgb.Min, ValueRanges.Rgb.Max)
            };
    }
}
