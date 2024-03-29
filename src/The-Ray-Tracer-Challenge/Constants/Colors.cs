﻿namespace The_Ray_Tracer_Challenge.Constants
{
    public static class Colors
    {
        public static readonly Color Black = new Color(0, 0, 0);
        public static readonly Color Red = new Color(1, 0, 0);
        public static readonly Color Green = new Color(0, 1, 0);
        public static readonly Color Blue = new Color(0, 0, 1);

        public static Color FromRgb(int r, int g, int b) 
            => new Color(ValueRanges.Rgb.Max / r, ValueRanges.Rgb.Max / g, ValueRanges.Rgb.Max / b);
    }
}
