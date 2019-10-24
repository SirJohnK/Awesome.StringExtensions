using System.Text.RegularExpressions;

namespace Awesome.StringExtensions
{
    /// <summary>
    /// All whitespace string extension methods
    /// </summary>
    public static partial class Extensions
    {
        #region "CleanWhitespace"

        /// <summary>
        /// Replaces contiguous sequences of whitespace with a single space.
        /// Also Removes all leading and trailing whitespaces.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <returns>Input text with no leading, trailing or contiguous sequences of whitespace.</returns>
        public static string CleanWhitespace(this string text)
        {
            //Verify text parameter
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            //Return result with replaced whitespace
            return text.Trim().ReplaceWhitespace(" ");
        }

        #endregion "CleanWhitespace"

        #region "RemoveWhitespace"

        /// <summary>
        /// Removes all whitespaces and returns result.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <returns>Input text with no whitespaces.</returns>
        public static string RemoveWhitespace(this string text)
        {
            //Return text without whitespace
            return text.ReplaceWhitespace();
        }

        #endregion "RemoveWhitespace"

        #region "ReplaceWhitespace"

        /// <summary>
        /// Replaces all whitespaces with specified replacement string and returns result.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <param name="replacement">Replacement string, default empty string.</param>
        /// <param name="groupreplace">Replace contiguous sequences of whitespace with single replacement string boolean, default true.</param>
        /// <returns>Input text with all whitespaces replaced with the replacement string.</returns>
        public static string ReplaceWhitespace(this string text, string replacement = "", bool groupreplace = true)
        {
            //Verify text parameter
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            //Return text with whitespace replaced
            return Regex.Replace(text, groupreplace ? @"[\s]+" : @"\s", replacement);
        }

        #endregion "ReplaceWhitespace"
    }
}