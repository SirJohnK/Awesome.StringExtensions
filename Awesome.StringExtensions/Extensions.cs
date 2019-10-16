using Awesome.StringExtensions.Models;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Awesome.StringExtensions
{
    public static class Extensions
    {
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

        private static string WordEvaluator(Match word)
        {
            //Init
            var lower = word.Value.ToLower();

            //Evaluate word
            return word.Index > 0 && cultureInfoData.data.Articles.Contains(lower) || cultureInfoData.data.Conjunctions.Contains(lower) || cultureInfoData.data.Prepositions.Contains(lower) ? lower : word.Value;
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
        }

        public static string ToTitleCase(this string text)
        {
            return ToTitleCase(text, CultureInfo.CurrentCulture);
        }
    }
}