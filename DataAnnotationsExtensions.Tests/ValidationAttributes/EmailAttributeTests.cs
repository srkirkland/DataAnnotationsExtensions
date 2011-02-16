using Microsoft.VisualStudio.TestTools.UnitTesting;

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
}
