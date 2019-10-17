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
        /// <param name="text">Input text</param>
        /// <returns>
        /// <paramref name="text"/> with no leading, trailing or contiguous sequences of whitespace.
        /// </returns>
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

        public static string RemoveWhitespace(this string text)
        {
            //Return text without whitespace
            return text.ReplaceWhitespace();
        }

        #endregion "RemoveWhitespace"

        #region "ReplaceWhitespace"

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
        /// Stores culture support data.
        /// </summary>
        private static (CultureInfo info, CultureData data) cultureInfoData;

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

            return succeeded;
        }

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

        public static string ToTitleCase(this string text)
        {
            return ToTitleCase(text, CultureInfo.CurrentCulture);
        }

        #endregion "ToTitleCase"
    }
}