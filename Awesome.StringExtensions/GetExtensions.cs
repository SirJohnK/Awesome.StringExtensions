using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Awesome.StringExtensions
{
    /// <summary>
    /// Retrieval string extension methods.
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// Get all words in specified text.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <returns>All found and not empty words from input text.</returns>
        /// <remarks>All empty and only whitespace words are excluded.</remarks>
        public static IEnumerable<string> Words(this string text)
        {
            //Verify text parameter
            if (string.IsNullOrWhiteSpace(text))
                return default;

            //Get all words
            var matches = Regex.Matches(text, @"\w+") as IEnumerable<Match>;

            //Return found and not empty words
            return matches.Where(match => match.Success && !string.IsNullOrWhiteSpace(match.Value)).Select(match => match.Value);
        }

        /// <summary>
        /// Get all unique words in specified text.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <returns>All unique words from input text.</returns>
        public static IEnumerable<string> UniqueWords(this string text)
        {
            //Verify text parameter
            if (string.IsNullOrWhiteSpace(text))
                return default;

            //Group all unique words
            var result = text.Words()?.GroupBy(word => word).Select(wordGroup => wordGroup.Key);

            //Return all unique words
            return result;
        }

        /// <summary>
        /// Get all sentences in specified text.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <param name="cleanNewLine">Clean new lines boolean, default true.</param>
        /// <param name="cleanWhitepace">Clean whitespaces boolean, default true. Otherwise preserve all whitespaces.</param>
        /// <returns>All found and not empty sentences from input text.</returns>
        public static IEnumerable<string> Sentences(this string text, bool cleanNewLine = true, bool cleanWhitepace = true)
        {
            //Verify text parameter
            if (string.IsNullOrWhiteSpace(text))
                return default;

            //Get all scentences
            var matches = Regex.Matches(text, @"((\s[^\.\!\?]\.)+|([^\.\!\?]\.)+|[^\.\!\?]+)+[\.\!\?]+(\s|$)") as IEnumerable<Match>;
            var result = matches.Where(match => match.Success && !string.IsNullOrWhiteSpace(match.Value)).Select(match => match.Value);

            //Clean NewLine
            if (cleanNewLine)
                result = result.Select(sentence => sentence.Replace(Environment.NewLine, string.Empty));

            //Clean Whitespace
            if (cleanWhitepace)
                result = result.Select(sentence => sentence.CleanWhitespace());

            //Return found sentences
            return result;
        }
    }
}