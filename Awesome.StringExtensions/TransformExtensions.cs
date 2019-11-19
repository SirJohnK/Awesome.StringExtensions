using Awesome.StringExtensions.Helpers;
using System;
using System.Globalization;
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
        /// Removes all non alphabetical characters and forms an acronym from all principle words.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <param name="culture">Language culture to retrive and identify words.</param>
        /// <param name="onlyPrincipalWords">Use only principal words boolean, default true. Otherwise include all words.</param>
        /// <returns>An acronym for the input text.</returns>
        /// <remarks>Definition of acronym - an abbreviation formed from the initial letters of other words and pronounced as a word (e.g. ASCII, NASA).</remarks>
        public static string ToAcronym(this string text, CultureInfo culture, bool onlyPrincipalWords = true)
        {
            //Verify text parameter
            if (string.IsNullOrWhiteSpace(text))
                return text;

            //Verify culture parameter
            if (culture == null)
                throw new ArgumentNullException(nameof(culture));

            //Verify culture info data and set principle word handling
            onlyPrincipalWords = onlyPrincipalWords && CultureInfoData.InitializeCultureData(culture);

            //Remove all non alphabetical characters, but preserve whitespace
            var result = text.ToAlphabetic();

            //Handle all words
            result = Regex.Replace(result, @"\w+", new MatchEvaluator(WordEvaluator), RegexOptions.IgnoreCase);

            //Return result without whitespace
            return result.RemoveWhitespace();

            //Internal evaluator
            string WordEvaluator(Match word)
            {
                //Init
                var lower = word.Value.ToLower();

                //Evaluate word
                return string.IsNullOrWhiteSpace(word.Value)
                    || (onlyPrincipalWords && (CultureInfoData.InfoData.data?.Articles?.Contains(lower) ?? false)
                    || (CultureInfoData.InfoData.data?.Conjunctions?.Contains(lower) ?? false)
                    || (CultureInfoData.InfoData.data?.Prepositions?.Contains(lower) ?? false))
                    ? string.Empty : word.Value.Substring(0, 1).ToUpper();
            }
        }

        /// <summary>
        /// Creates a acronym for the specified text and returns result.
        /// Removes all non alphabetical characters and forms an acronym from all principle words.
        /// With current culture specific handling of articles, conjunctions and prepositions.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <returns>An acronym for the input text.</returns>
        public static string ToAcronym(this string text)
        {
            return ToAcronym(text, CultureInfo.CurrentCulture);
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