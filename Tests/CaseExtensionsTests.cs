using Awesome.StringExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace Tests
{
    [TestClass]
    public class CaseExtensionsTests
    {
        #region "ToCamelCase Tests"
        [TestMethod]
        public void ToCamelCase_ShouldBeCorrectCamelCase()
        {
            //Assert
            Common.BaseSentence.ToCamelCase().Should().Be("MrSherlockHolmesAndDrJohnWatsonWereBetterThanTheFBIAtCrimeFighting", "because it should have correct camel casing");
        }
        #endregion

        #region "ToSentenceCase Tests"
        [TestMethod]
        public void ToSentenceCase_ShouldBeCorrectSentenceCase()
        {
            //Assert
            Common.BaseSentence.ToSentenceCase().Should().Be("Mr sherlock holmes and dr john watson were better than the f.b.i. at crime fighting!", "because it should have correct sentence casing");
        }
        #endregion

        #region "ToSnakeCase Tests"
        [TestMethod]
        public void ToSnakeCase_ShouldBeCorrectSnakeCase()
        {
            //Assert
            Common.BaseSentence.ToSnakeCase().Should().Be("Mr_Sherlock_Holmes_and_Dr_John_Watson_were_better_than_the_FBI_at_crime_fighting", "because it should have correct snake casing");
        }
        #endregion

        #region "ToTitleCase Tests"
        [TestMethod]
        public void ToTitleCase_ShouldThrowArgumentNullException_IfCultureIsNull()
        {
            //Setup
            Action ToTitleCase = () => Common.BaseText.ToTitleCase(null);

            //Assert
            ToTitleCase.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("culture");
        }

        [TestMethod]
        public void ToTitleCase_ShouldBeCorrectTitleCase()
        {
            //Assert
            Common.BaseSentence.ToTitleCase(new CultureInfo("en-US")).Should().Be("Mr Sherlock Holmes and Dr John Watson Were Better than the F.B.I. at Crime Fighting!", "because it should have correct title casing");
        }
        #endregion
    }
}