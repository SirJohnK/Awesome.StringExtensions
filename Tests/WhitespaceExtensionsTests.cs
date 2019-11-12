using Awesome.StringExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class WhitespaceExtensionsTests
    {
        #region "CleanWhitespace Tests"

        [TestMethod]
        public void CleanWhitespace_ShouldBeOnlySingleSpaceWhitespaces()
        {
            //Assert
            Common.AlphaNumeric.CleanWhitespace().Should().Be("!A1 #B2 ¤C3 %D4 &E5 /F6 (G7 )H8 =I9 @J0", "because all contiguous sequences of whitespaces should be replaced");
        }

        #endregion "CleanWhitespace Tests"

        #region "RemoveWhitespace Tests"

        [TestMethod]
        public void RemoveWhitespace_ShouldBeWithoutWhitespaces()
        {
            //Assert
            Common.AlphaNumeric.RemoveWhitespace().Should().Be("!A1#B2¤C3%D4&E5/F6(G7)H8=I9@J0", "because all whitespaces should be removed");
        }

        #endregion "RemoveWhitespace Tests"

        #region "RemoveWhitespace Tests"

        [TestMethod]
        public void ReplaceWhitespace_ShouldBeWithAllWhitespacesReplacedBySingleCharacter()
        {
            //Assert
            Common.AlphaNumeric.ReplaceWhitespace("$").Should().Be("!A1$#B2$¤C3$%D4$&E5$/F6$(G7$)H8$=I9$@J0", "because all whitespaces should be replaced with $");
        }

        [TestMethod]
        public void ReplaceWhitespace_ShouldBeWithAllWhitespacesReplaced()
        {
            //Assert
            Common.AlphaNumeric.ReplaceWhitespace("$", false).Should().Be("!A1$$$$#B2$$¤C3$$$%D4$&E5$$$$$$/F6$(G7$$)H8$$$$$$=I9$@J0", "because all whitespaces should be replaced with $");
        }

        #endregion "RemoveWhitespace Tests"
    }
}