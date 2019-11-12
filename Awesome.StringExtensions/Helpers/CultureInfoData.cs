using Awesome.StringExtensions.Models;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Awesome.StringExtensions.Helpers
{
    internal static class CultureInfoData
    {
        /// <summary>
        /// Stores culture support data./>)
        /// </summary>
        internal static (CultureInfo info, CultureData data) InfoData;

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
        internal static bool InitializeCultureData(CultureInfo culture)
        {
            //Verify culture parameter
            if (culture == null)
                throw new ArgumentNullException(nameof(culture));

            //Exit if specified culture already inilialized
            if (CultureInfo.Equals(InfoData.info, culture))
                return true;

            //Init
            var succeeded = false;

            try
            {
                //Get assembly information
                var assembly = Assembly.GetExecutingAssembly();
                var names = assembly.GetManifestResourceNames();

                //Clear culture info data
                InfoData.info = default;
                InfoData.data = default;

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
                        InfoData.info = culture;
                        InfoData.data = data;
                        succeeded = true;
                    }
                }
            }
            catch (Exception)
            {
                //Clear
                InfoData.info = default;
                InfoData.data = default;
                succeeded = false;
            }

            //Return status if culture resource was found
            return succeeded;
        }
    }
}