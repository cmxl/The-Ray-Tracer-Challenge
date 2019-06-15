using System;
using The_Ray_Tracer_Challenge.Constants;
using The_Ray_Tracer_Challenge.Extensions;

namespace The_Ray_Tracer_Challenge
{
    public struct Color : IEquatable<Color>
    {
        public Color(double red, double green, double blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public double Red { get; }
        public double Green { get; }
        public double Blue { get; }

        public static implicit operator Tuple(Color color) => new Tuple(color.Red, color.Green, color.Blue, 0);

        public static Color operator *(Color a, Color b)
            => a.MultiplyBy(b);
        public static bool operator ==(Color left, Color right) => left.Equals(right);
        public static bool operator !=(Color left, Color right) => !(left == right);

        public override string ToString() => $"RGB({Red}, {Green}, {Blue})";
        public bool Equals(Color other)
            => Red.Equals(other.Red, MathConstants.DELTA) &&
               Green.Equals(other.Green, MathConstants.DELTA) &&
               Blue.Equals(other.Blue, MathConstants.DELTA);

        public override bool Equals(object obj) => Equals((Color)obj);
        public override int GetHashCode() => HashCode.Combine(Red, Green, Blue);
    }
}
