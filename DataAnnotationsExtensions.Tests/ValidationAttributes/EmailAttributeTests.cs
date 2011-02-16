using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
    [TestClass]
    public class EmailAttributeTests
    {
        [TestMethod]
        public void IsValidTests()
        {
            var attribute = new EmailAttribute();

            Assert.IsTrue(attribute.IsValid(null)); // Don't check for required
            Assert.IsTrue(attribute.IsValid("foo@bar.com"));
            Assert.IsTrue(attribute.IsValid("foo.bar@baz.com"));
            Assert.IsTrue(attribute.IsValid("foo%bar@baz.com"));
            Assert.IsFalse(attribute.IsValid("foo"));
            Assert.IsFalse(attribute.IsValid("foo@"));
            Assert.IsFalse(attribute.IsValid("foo@bar"));
        }
    }

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
