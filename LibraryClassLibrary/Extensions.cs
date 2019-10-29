namespace LibraryClassLibrary
{
    public static class Extensions
    {
        public static string FormatStringLength(this string text, int width)
        {
            // If string is longer then width, return substring with length(width), else return the string unmodified.
            string output = text.Length > width ? text.Substring(0, width) : text;
            return output;
        }
    }
}