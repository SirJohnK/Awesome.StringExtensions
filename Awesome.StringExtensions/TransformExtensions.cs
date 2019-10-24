using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Awesome.StringExtensions
{
    public static partial class Extensions
    {
        #region "ToAcronym"

        /// <summary>
        /// Creates a acronym for the specified text and returns result.
        /// Removes all non alphabetical characters and forms an acronym from the remaining words.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <returns>An acronym for the input text.</returns>
        /// <remarks>Definition of acronym - an abbreviation formed from the initial letters of other words and pronounced as a word (e.g. ASCII, NASA).</remarks>
        public static string ToAcronym(this string text)
        {
            //Verify text parameter
            if (string.IsNullOrWhiteSpace(text))
                return text;

            //Remove all non alphabetical characters, but preserve whitespace
            var result = text.ToAlphabetic();

            //Handle all words
            result = Regex.Replace(result, @"\w+", new MatchEvaluator(WordEvaluator), RegexOptions.IgnoreCase);

            //Return result without whitespace
            return result.RemoveWhitespace();

            //Internal evaluator
            string WordEvaluator(Match word)
            {
                //Evaluate word
                return string.IsNullOrWhiteSpace(word.Value) ? string.Empty : word.Value.Substring(0, 1).ToUpper();
            }
        }

        #endregion "ToAcronym"

        #region "ToAlphabetic"

        /// <summary>
        /// Removes all non alphabetical characters and returns result.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <param name="preserveWhitespace">Preserve whitespaces boolean, default true. Otherwise removes all whitespaces.</param>
        /// <returns>Input text without any non alphabetical characters.</returns>
        public static string ToAlphabetic(this string text, bool preserveWhitespace = true)
        {
            //Verify text parameter
            if (string.IsNullOrWhiteSpace(text))
                return text;

            //Remove all non alphabetical characters
            var sb = new StringBuilder();
            text.Where(c => char.IsLetter(c) || (char.IsWhiteSpace(c) && preserveWhitespace)).ToList().ForEach(c => sb.Append(c));

            //Return result
            return sb.ToString();
        }

        #endregion "ToAlphabetic"

        #region "ToAlphanumeric"

        /// <summary>
        /// Removes all non alphanumerical characters and returns result.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <param name="preserveWhitespace">Preserve whitespaces boolean, default true. Otherwise removes all whitespaces.</param>
        /// <returns>Input text without any non alphanumerical characters.</returns>
        public static string ToAlphanumeric(this string text, bool preserveWhitespace = true)
        {
            //Verify text parameter
            if (string.IsNullOrWhiteSpace(text))
                return text;

            //Remove all non alphanumerical characters
            var sb = new StringBuilder();
            text.Where(c => char.IsLetterOrDigit(c) || (char.IsWhiteSpace(c) && preserveWhitespace)).ToList().ForEach(c => sb.Append(c));

            //Return result
            return sb.ToString();
        }

        #endregion "ToAlphanumeric"
    }
}