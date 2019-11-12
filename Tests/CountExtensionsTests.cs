using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Awesome.StringExtensions;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class CountExtensionsTests
    {
        #region "CountWords Tests"
        [TestMethod]
        public void CountWords_ShouldBeCorrectCount()
        {
            //Assert
            Common.BaseSentence.CountWords().Should().Be(17, "because all words should be counted");
        }
        #endregion

        #region "CountUniqueWords Tests"
        [TestMethod]
        public void CountUniqueWords_ShouldBeCorrectCount()
        {
            //Assert
            Common.DuplicateWordSentence.CountUniqueWords().Should().Be(22, "because all unique words should be counted");
        }
        #endregion

        #region "CountWordLengths Tests"
        [TestMethod]
        public void CountWordLengths_ShouldNotBeEmptyAndHaveCorrectCountAndCorrectLengths()
        {
            //Assert
            Common.BaseSentence.CountWordLengths().Should()
                .NotBeEmpty("because input text is not empty")
                .And.HaveCount(7, "because all different word lengths should be counted")
                .And.Equal(new List<(int Length, int Count)> { (1, 3), (2, 3), (3, 2), (4, 3), (5, 1), (6, 3), (8, 2) });
        }
        #endregion

        #region "CountSentences Tests"
        [TestMethod]
        public void CountSentences_ShouldBeCorrectCount()
        {
            //Assert
            Common.DuplicateWordSentence.CountSentences().Should().Be(2, "because all sentences should be counted");
        }
        #endregion
    }
}