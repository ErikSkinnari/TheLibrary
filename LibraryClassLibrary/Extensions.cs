namespace LibraryClassLibrary
{
    public static class Extensions
    {
        /// <summary>
        /// If string is longer then width, return substring with length(width - 3) 
        /// and 3 added dots at the end, else return the string unmodified.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static string FormatStringLength(this string text, int width)
        {
            string output = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
            return output;
        }
    }
}