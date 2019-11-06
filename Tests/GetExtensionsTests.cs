using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Awesome.StringExtensions;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class GetExtensionsTests
    {
        private const string BaseSentence = "Mr Sherlock Holmes and Dr John Watson were better than the F.B.I. at crime fighting!";
        private const string DuplicateWordSentence = BaseSentence + " That is the truth and nothing but the truth!";

        #region "Words Tests"
        [TestMethod]
        public void Words_ShouldNotBeEmptyAndHaveCorrectCountAndCorrectWords()
        {
            //Assert
            BaseSentence.Words().Should()
                .NotBeEmpty("because input text is not empty")
                .And.HaveCount(17, "because all words should be counted")
                .And.Equal(new List<string> { "Mr", "Sherlock", "Holmes", "and", "Dr", "John", "Watson", "were", "better", "than", "the", "F", "B", "I", "at", "crime", "fighting" });
        }
        #endregion

        #region "UniqueWords Tests"
        [TestMethod]
        public void UniqueWords_ShouldNotBeEmptyAndHaveCorrectCountAndCorrectWords()
        {
            //Assert
            DuplicateWordSentence.UniqueWords().Should()
                .NotBeEmpty("because input text is not empty")
                .And.HaveCount(22, "because all unique words should be counted")
                .And.Equal(new List<string> { "Mr", "Sherlock", "Holmes", "and", "Dr", "John", "Watson", "were", "better", "than", "the", "F", "B", "I", "at", "crime", "fighting", "That", "is", "truth", "nothing", "but" });
        }
        #endregion

        #region "Sentences Tests"
        [TestMethod]
        public void Sentences_ShouldNotBeEmptyAndHaveCorrectCountAndCorrectWords()
        {
            //Assert
            DuplicateWordSentence.Sentences().Should()
                .NotBeEmpty("because input text is not empty")
                .And.HaveCount(2, "because all sentences should be counted")
                .And.Equal(new List<string> { "Mr Sherlock Holmes and Dr John Watson were better than the F.B.I. at crime fighting!", "That is the truth and nothing but the truth!" });
        }
        #endregion
    }
}