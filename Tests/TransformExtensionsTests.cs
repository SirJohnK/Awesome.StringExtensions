using Awesome.StringExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Tests
{
    [TestClass]
    public class TransformExtensionsTests
    {
        #region "ToAcronym Tests"

        [TestMethod]
        public void ToAcronym_ShouldBeNASAAcronym_WithNasaNameInput()
        {
            //Assert
            Common.NASAName.ToAcronym(new CultureInfo("en-US")).Should().Be("NASA", "because all principle words builds the acronym");
        }

        [TestMethod]
        public void ToAcronym_ShouldBeASCIIAcronym_WithASCIINameInput()
        {
            //Assert
            Common.ASCIIName.ToAcronym(new CultureInfo("en-US")).Should().Be("ASCII", "because all principle words builds the acronym");
        }

        [TestMethod]
        public void ToAcronym_ShouldBeLASERAcronym_WithLaserNameInput()
        {
            //Assert
            Common.LASERName.ToAcronym(new CultureInfo("en-US")).Should().Be("LASER", "because all principle words builds the acronym");
        }

        #endregion "ToAcronym Tests"

        #region "ToAlphabetic Tests"

        [TestMethod]
        public void ToAlphabetic_ShouldBeAlphabeticCharactersAndPreserveWhitespace()
        {
            //Assert
            Common.AlphaNumeric.ToAlphabetic().Should().Be("A    B  C   D E      F G  H      I J", "because all non alphabetic charaters should be removed");
        }

        [TestMethod]
        public void ToAlphabetic_ShouldBeOnlyAlphabeticCharacters()
        {
            //Assert
            Common.AlphaNumeric.ToAlphabetic(false).Should().Be("ABCDEFGHIJ", "because all non alphabetic charaters should be removed");
        }

        #endregion "ToAlphabetic Tests"

        #region "ToAlphaNumeric Tests"

        [TestMethod]
        public void ToAlphanumeric_ShouldBeAlphanumericCharactersAndPreserveWhitespace()
        {
            //Assert
            Common.AlphaNumeric.ToAlphanumeric().Should().Be("A1    B2  C3   D4 E5      F6 G7  H8      I9 J0", "because all non alphanumeric charaters should be removed");
        }

        [TestMethod]
        public void ToAlphanumeric_ShouldBeOnlyAlphanumericCharacters()
        {
            //Assert
            Common.AlphaNumeric.ToAlphanumeric(false).Should().Be("A1B2C3D4E5F6G7H8I9J0", "because all non alphanumeric charaters should be removed");
        }

        #endregion "ToAlphaNumeric Tests"
    }
}