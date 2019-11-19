using Awesome.StringExtensions.Helpers;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Awesome.StringExtensions
{
    public static partial class Extensions
    {
        #region "ToCamelCase"

        /// <summary>
        /// Capitalizes the first letter of each word and removes all whitespaces.
        /// Also removes all non alphabetical characters.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <returns>Input text with first letter of each word capitalized and without whitespaces.</returns>
        public static string ToCamelCase(this string text)
        {
            //Verify text parameter
            if (string.IsNullOrWhiteSpace(text))
                return text;

            //Handle all words
            var result = Regex.Replace(text, @"\w+", new MatchEvaluator(WordEvaluator), RegexOptions.IgnoreCase);

            //Return result without all non alphanumeric characters and whitespace
            return result.ToAlphanumeric(false);

            //Internal evaluator
            string WordEvaluator(Match word)
            {
                //Evaluate word
                return word.Value.ToSentenceCase();
            }
        }

        #endregion "ToCamelCase"

        #region "ToSentenceCase"

        /// <summary>
        /// Capitalizes the first letter of the first word and all other words are lowercase in each sentence.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <param name="cleanWhitespace">Clean whitespaces boolean, default true. (<see cref="CleanWhitespace(string)"/>)</param>
        /// <returns>Input text with first letter of the first word capitalized and all other words in lowercase in each sentence.</returns>
        public static string ToSentenceCase(this string text, bool cleanWhitespace = true)
        {
            //Verify text parameter
            if (string.IsNullOrWhiteSpace(text))
                return text;

            //Clean whitespace
            if (cleanWhitespace)
                text = text.CleanWhitespace();

            //Return sentence case
            return text.Length > 1 ? text.Substring(0, 1).ToUpper() + text.Substring(1).ToLower() : text.ToUpper();
        }

        #endregion "ToSentenceCase"

        #region "ToSnakeCase"

        /// <summary>
        /// All whitespaces are replaced with underscore character.
        /// Replaces all contiguous sequences of whitespace with a single underscore.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <returns>Input text with all whitespaces replaced with underscore character.</returns>
        public static string ToSnakeCase(this string text)
        {
            //Verify text parameter
            if (string.IsNullOrWhiteSpace(text))
                return text;

            //Remove all non alphanumeric characters, but preserve whitespace
            var result = text.ToAlphanumeric();

            //Return result with replaced whitespace
            return result.ReplaceWhitespace("_");
        }

        #endregion "ToSnakeCase"

        #region "ToTitleCase"

        /// <summary>
        /// Converts string to title case with culture specific handling of articles, conjunctions and prepositions.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <param name="culture">Language culture to retrive and identify words.</param>
        /// <returns>Input text with word casing based on title case rules.</returns>
        /// <remarks>
        /// Rules:
        /// - Capitalize the first word and the last word of the title.
        /// - Capitalize the principal words.
        /// - Capitalize all words of four letters or more.
        /// - Do not capitalize articles, conjunctions, and prepositions of three letters or fewer.
        /// </remarks>
        public static string ToTitleCase(this string text, CultureInfo culture)
        {
            //Verify text parameter
            if (string.IsNullOrWhiteSpace(text))
                return text;

            //Verify culture info data
            if (!CultureInfoData.InitializeCultureData(culture))
                return culture.TextInfo.ToTitleCase(text);
            else
            {
                //Run first pass for base casing
                var result = culture.TextInfo.ToTitleCase(text);

                //Handle all culture Articles, Conjunctions & Prepositions
                return Regex.Replace(result, @"\w+", new MatchEvaluator(WordEvaluator), RegexOptions.IgnoreCase);
            }

            //Internal evaluator
            string WordEvaluator(Match word)
            {
                //Init
                var lower = word.Value.ToLower();

                //Evaluate word
                var lastWord = !word.NextMatch().Success;

                return word.Index > 0 && !lastWord && word.Value.Length <= 3
                    && (CultureInfoData.InfoData.data?.Articles?.Contains(lower) ?? false)
                    || (CultureInfoData.InfoData.data?.Conjunctions?.Contains(lower) ?? false)
                    || (CultureInfoData.InfoData.data?.Prepositions?.Contains(lower) ?? false)
                    ? lower : word.Value;
            }
        }

        /// <summary>
        /// Converts string to title case with current culture specific handling of articles, conjunctions and prepositions.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <returns>Input text with word casing based on title case rules. (<see cref="ToTitleCase(string, CultureInfo)"/>)</returns>
        public static string ToTitleCase(this string text)
        {
            return ToTitleCase(text, CultureInfo.CurrentCulture);
        }

        #endregion "ToTitleCase"
    }
}