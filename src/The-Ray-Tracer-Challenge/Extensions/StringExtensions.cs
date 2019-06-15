namespace The_Ray_Tracer_Challenge.Extensions
{
    public static class StringExtensionsx
    {
        public static string PermissiveSubstring(this string input, int length)
            => input.PermissiveSubstring(0, length);

        public static string PermissiveSubstring(this string input, int startIndex, int length)
            => input.Substring(startIndex, input.Length - startIndex <= length ? input.Length - startIndex : length);
    }
}
