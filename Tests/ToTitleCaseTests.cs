using Awesome.StringExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class ToTitleCaseTests
    {
        [TestMethod]
        public void ToTitleCase_ShouldThrowArgumentNullException_IfCultureIsNull()
        {
            //Setup
            string text = "Lorem Ipsum";
            Action act = () => text.ToTitleCase(null);

            //Assert
            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("culture");
        }
    }
}