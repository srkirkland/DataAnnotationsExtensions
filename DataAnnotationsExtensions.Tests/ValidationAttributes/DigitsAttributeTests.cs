using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
    [TestClass]
    public class DigitsAttributeTests
    {
        [TestMethod]
        public void IsValidTests()
        {
            var attribute = new DigitsAttribute();

            Assert.IsTrue(attribute.IsValid(null)); // Don't check for required
            Assert.IsTrue(attribute.IsValid("1234"));
            Assert.IsTrue(attribute.IsValid("12345"));
            Assert.IsTrue(attribute.IsValid(14));
            Assert.IsFalse(attribute.IsValid(14.50));
            Assert.IsFalse(attribute.IsValid("12.90"));
            Assert.IsFalse(attribute.IsValid("1234.5"));
            Assert.IsFalse(attribute.IsValid("$3.50"));
            Assert.IsFalse(attribute.IsValid("12abc"));
            Assert.IsFalse(attribute.IsValid(DateTime.Now));
            Assert.IsFalse(attribute.IsValid("fourteen"));
        }
    }
}