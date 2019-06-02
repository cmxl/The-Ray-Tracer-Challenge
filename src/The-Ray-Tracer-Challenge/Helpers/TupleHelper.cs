namespace The_Ray_Tracer_Challenge.Helpers
{
    public static class TupleHelper
    {
        public static bool IsPoint(Tuple tuple) => tuple.W.Equals(1.0);
        public static bool IsVector(Tuple tuple) => tuple.W.Equals(0.0);
    }
}
