using Awesome.StringExtensions.Models;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Awesome.StringExtensions
{
    public static class Extensions
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

        #region "ToAcronym"

        /// <summary>
        /// Creates a acronym for the specified text and returns result.
        /// Remove all non alphabetical characters and forms an acronym from the remaining words.
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

            //Remove all non alphanumeric characters, but preserve whitespace
            var result = text.ToAlphanumeric();

            //Handle all words
            result = Regex.Replace(result, @"\w+", new MatchEvaluator(WordEvaluator), RegexOptions.IgnoreCase);

            //Return result without whitespace
            return result.RemoveWhitespace();

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
        /// Stores culture support data for ToTitleCase method. (<see cref="ToTitleCase(string, CultureInfo)"/>)
        /// </summary>
        private static (CultureInfo info, CultureData data) cultureInfoData;

        /// <summary>
        /// Retrieves culture support data from embedded resource json files, based on specified culture.
        /// </summary>
        /// <param name="culture">Culture to identify culture support data file.</param>
        /// <returns>Status boolean, indicating if support data was found for specified culture.</returns>
        /// <remarks>
        /// If culture data is not found for specified culture, attempt is made to find another support data with same base language.
        /// e.g. If culture en-GB is not found, a search is made based on culture TwoLetterISOLanguageName (en).
        /// Any culture with same base language will be used as a replacement. (en-US could replace en-GB)
        /// </remarks>
        private static bool InitializeCultureData(CultureInfo culture)
        {
            //Init
            var succeeded = false;

            try
            {
                //Get assembly information
                var assembly = Assembly.GetExecutingAssembly();
                var names = assembly.GetManifestResourceNames();

                //Clear culture info data
                cultureInfoData.info = default;
                cultureInfoData.data = default;

                //Find culture resource
                var resourceName = names.FirstOrDefault(name => name.Contains($".{culture.Name}.json"));
                if (resourceName == null)
                {
                    //Attempt to find substitute culture resource
                    resourceName = names.FirstOrDefault(name => name.Contains($".{culture.TwoLetterISOLanguageName}-"));
                }

                //Found culture resource?
                if (!string.IsNullOrEmpty(resourceName))
                {
                    //Get resource text
                    var result = string.Empty;
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        result = reader.ReadToEnd();
                    }

                    //Attempt to deserialize json
                    var data = JsonConvert.DeserializeObject<CultureData>(result);
                    if (data != null)
                    {
                        cultureInfoData.info = culture;
                        cultureInfoData.data = data;
                        succeeded = true;
                    }
                }
            }
            catch (Exception)
            {
                //Clear
                cultureInfoData.info = default;
                cultureInfoData.data = default;
                succeeded = false;
            }

            //Return status if culture resource was found
            return succeeded;
        }

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

            //Verify culture parameter
            if (culture == null)
                throw new ArgumentNullException(nameof(culture));

            //Verify culture info data
            if (!CultureInfo.Equals(cultureInfoData.info, culture) && !InitializeCultureData(culture))
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
                return word.Index > 0 && cultureInfoData.data.Articles.Contains(lower) || cultureInfoData.data.Conjunctions.Contains(lower) || cultureInfoData.data.Prepositions.Contains(lower) ? lower : word.Value;
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