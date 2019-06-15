namespace The_Ray_Tracer_Challenge.Constants
{
    public class ValueRanges
    {
        public static readonly ValueRange<int> Rgb = new ValueRange<int>(0, 255);
    }

    public class ValueRange<T>
    {
        internal ValueRange(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public T Min { get; }
        public T Max { get; }
    }

}
