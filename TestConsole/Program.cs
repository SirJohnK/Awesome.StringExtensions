using Awesome.StringExtensions;
using System;
using System.Globalization;

namespace TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Test Data
            var BaseSentence = "Mr Sherlock Holmes and Dr John Watson were better than the F.B.I. at crime fighting!";
            var DuplicateWordSentence = BaseSentence + " That is the truth and nothing but the truth!";
            var NASAName = "national aeronautics and space administration";
            var ASCIIName = "American Standard Code for Information Interchange";
            var LASERName = "Light Amplification by Stimulated Emission of Radiation";
            var CharsAndNumbers = "!A1    #B2  ¤C3   %D4 &E5      /F6 (G7  )H8      =I9 @J0";

            //Case Extensions
            Console.WriteLine(BaseSentence.ToCamelCase());
            Console.WriteLine(BaseSentence.ToSentenceCase());
            Console.WriteLine(BaseSentence.ToSnakeCase());
            Console.WriteLine(BaseSentence.ToTitleCase());
            Console.WriteLine(BaseSentence.ToTitleCase(new CultureInfo("en-US")));

            //Count Extensions
            Console.WriteLine($"DuplicateWordSentence contains {DuplicateWordSentence.CountWords()} words.");
            Console.WriteLine($"DuplicateWordSentence contains {DuplicateWordSentence.CountUniqueWords()} unique words.");
            foreach (var wordlength in BaseSentence.CountWordLengths())
            {
                Console.WriteLine($"BaseSentence contains {wordlength.Count} word{(wordlength.Count > 1 ? "s" : string.Empty)} that has {wordlength.Length} character{(wordlength.Length > 1 ? "s" : string.Empty)}.");
            }
            Console.WriteLine($"DuplicateWordSentence contains {DuplicateWordSentence.CountSentences()} sentences.");

            //Get Extensions
            Console.WriteLine($"DuplicateWordSentence contains the following words:");
            foreach (var word in DuplicateWordSentence.Words())
            {
                Console.WriteLine(word);
            }
            Console.WriteLine($"DuplicateWordSentence contains the following unique words:");
            foreach (var word in DuplicateWordSentence.UniqueWords())
            {
                Console.WriteLine(word);
            }
            Console.WriteLine($"DuplicateWordSentence contains the following sentences:");
            foreach (var sentence in DuplicateWordSentence.Sentences())
            {
                Console.WriteLine(sentence);
            }

            //Transform Extensions
            Console.WriteLine($"The acronym for '{NASAName}' is {NASAName.ToAcronym()}.");
            Console.WriteLine($"The acronym for '{NASAName}' is {NASAName.ToAcronym(new CultureInfo("en-US"))}.");
            Console.WriteLine($"The acronym for '{ASCIIName}' is {ASCIIName.ToAcronym()}.");
            Console.WriteLine($"The acronym for '{ASCIIName}' is {ASCIIName.ToAcronym(new CultureInfo("en-US"))}.");
            Console.WriteLine($"The acronym for '{LASERName}' is {LASERName.ToAcronym()}.");
            Console.WriteLine($"The acronym for '{LASERName}' is {LASERName.ToAcronym(new CultureInfo("en-US"))}.");
            Console.WriteLine($"The alphabetic characters in the CharsAndNumbers text is: {CharsAndNumbers.ToAlphabetic()}");
            Console.WriteLine($"The alphabetic characters in the CharsAndNumbers text is: {CharsAndNumbers.ToAlphabetic(false)}");
            Console.WriteLine($"The alphanumeric characters in the CharsAndNumbers text is: {CharsAndNumbers.ToAlphanumeric()}");
            Console.WriteLine($"The alphanumeric characters in the CharsAndNumbers text is: {CharsAndNumbers.ToAlphanumeric(false)}");

            //Whitespace Extensions
            Console.WriteLine($"CharsAndNumbers text after cleaning whitespace is: {CharsAndNumbers.CleanWhitespace()}");
            Console.WriteLine($"CharsAndNumbers text after removing whitespace is: {CharsAndNumbers.RemoveWhitespace()}");
            Console.WriteLine($"CharsAndNumbers text after replacing whitespace with '$' is: {CharsAndNumbers.ReplaceWhitespace("$")}");
        }
    }
}