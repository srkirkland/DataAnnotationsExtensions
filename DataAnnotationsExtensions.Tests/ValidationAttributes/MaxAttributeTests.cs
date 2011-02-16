using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
    [TestClass]
    public class MaxAttributeTests
    {
        [TestMethod]
        public void IsValidIntegerTests()
        {
            const int max = 42;
            var attribute = new MaxAttribute(max);

            Assert.IsTrue(attribute.IsValid(null));  // Optional values are always valid
            Assert.IsTrue(attribute.IsValid("41"));
            Assert.IsTrue(attribute.IsValid("10"));
            Assert.IsTrue(attribute.IsValid(0));
            Assert.IsTrue(attribute.IsValid("-1"));
            Assert.IsTrue(attribute.IsValid(-50));
            Assert.IsTrue(attribute.IsValid("42"));
            Assert.IsFalse(attribute.IsValid(42.5));
            Assert.IsFalse(attribute.IsValid(43));
            Assert.IsFalse(attribute.IsValid("50"));
            Assert.IsFalse(attribute.IsValid(100));
            Assert.IsFalse(attribute.IsValid("10000000000"));
            Assert.IsFalse(attribute.IsValid("fifty"));
            
        }

        [TestMethod]
        public void IsValidDoubleTests()
        {
            const double max = 3.50f;

            var attribute = new MaxAttribute(max);

            Assert.IsTrue(attribute.IsValid(null));  // Optional values are always valid
            Assert.IsTrue(attribute.IsValid(3));
            Assert.IsTrue(attribute.IsValid("3.498"));
            Assert.IsTrue(attribute.IsValid("-5"));
            Assert.IsFalse(attribute.IsValid(3.51));
            Assert.IsFalse(attribute.IsValid("4"));
            Assert.IsFalse(attribute.IsValid("4.5"));
            Assert.IsFalse(attribute.IsValid(100));
            Assert.IsFalse(attribute.IsValid("100.42"));
            Assert.IsFalse(attribute.IsValid("INVALID STRING"));
            
        }
    }
}