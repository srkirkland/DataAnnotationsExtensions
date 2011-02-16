using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
    [TestClass]
    public class NumericAttributeTests
    {
        [TestMethod]
        public void IsValidTests()
        {
            var attribute = new NumericAttribute();

            Assert.IsTrue(attribute.IsValid(null)); // Don't check for required
            Assert.IsTrue(attribute.IsValid("1234"));
            Assert.IsTrue(attribute.IsValid("1234.2342"));
            Assert.IsTrue(attribute.IsValid("12e5"));
            Assert.IsTrue(attribute.IsValid("12.90"));
            Assert.IsTrue(attribute.IsValid(14));
            Assert.IsTrue(attribute.IsValid(14.50));
            Assert.IsFalse(attribute.IsValid("$3.50"));
            Assert.IsFalse(attribute.IsValid("12abc"));
            Assert.IsFalse(attribute.IsValid(DateTime.Now));
            Assert.IsFalse(attribute.IsValid("fourteen"));
        }
    }
}