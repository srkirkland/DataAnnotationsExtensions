using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
    [TestClass]
    public class DateAttributeTests
    {
        [TestMethod]
        public void IsValidTests()
        {
            var attribute = new DateAttribute();

            Assert.IsTrue(attribute.IsValid(null)); // Don't check for required
            Assert.IsTrue(attribute.IsValid(DateTime.Now));
            Assert.IsTrue(attribute.IsValid(DateTime.Now.ToShortDateString()));
            Assert.IsTrue(attribute.IsValid("12/31/2010"));
            Assert.IsFalse(attribute.IsValid(12));
            Assert.IsFalse(attribute.IsValid("12.90"));
            Assert.IsFalse(attribute.IsValid("February 24th"));
            Assert.IsFalse(attribute.IsValid("yesterday"));
            Assert.IsFalse(attribute.IsValid("80/80/2011"));
        }
    }
}
