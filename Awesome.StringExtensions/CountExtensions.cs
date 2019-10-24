using System.Linq;

namespace Awesome.StringExtensions
{
    /// <summary>
    /// Count string extension methods.
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// Count the number of words.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <returns>The numbers of words in the input text.</returns>
        public static int CountWords(this string text)
        {
            //Verify text parameter
            if (string.IsNullOrWhiteSpace(text))
                return -1;

            //Return text word count
            return text.Words()?.Count() ?? -1;
        }

        /// <summary>
        /// Count the number of unique words in specified text.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <returns>The unique words count.</returns>
        public static int CountUniqueWords(this string text)
        {
            //Verify text parameter
            if (string.IsNullOrWhiteSpace(text))
                return -1;

            //Return unique words count
            return text.UniqueWords()?.Count() ?? -1;
        }

        /// <summary>
        /// Count the occurrence of all different word lengths.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <returns>The ordered list of occurrences of all different word lengths.</returns>
        public static IOrderedEnumerable<(int Length, int Count)> CountWordLengths(this string text)
        {
            //Verify text parameter
            if (string.IsNullOrWhiteSpace(text))
                return default;

            //Count word lengths
            var lengths = text.Words()?.GroupBy(word => word.Length);

            //Return ordered count word lengths
            var result = lengths?.Select(lengthGroup => (Length: lengthGroup.Key, Count: lengthGroup.Count())).OrderBy(wordLength => wordLength.Length);

            //Return all ordered word length counts
            return result;
        }

        /// <summary>
        /// Count the number of sentences.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <returns>The number of sentences in the input text.</returns>
        public static int CountSentences(this string text)
        {
            //Verify text parameter
            if (string.IsNullOrWhiteSpace(text))
                return -1;

            //Return number of sentences count
            return text.Sentences()?.Count() ?? -1;
        }
    }
}