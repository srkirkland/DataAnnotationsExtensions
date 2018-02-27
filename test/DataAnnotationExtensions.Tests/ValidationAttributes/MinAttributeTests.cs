using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
    [TestClass]
    public class MinAttributeTests : TestBase
    {
        [TestMethod]
        public void IsValidIntegerTests()
        {
            const int min = 42;
            var attribute = new MinAttribute(min);

            Assert.IsTrue(attribute.IsValid(null));  // Optional values are always valid
            Assert.IsTrue(attribute.IsValid("42"));
            Assert.IsTrue(attribute.IsValid(42.5));
            Assert.IsTrue(attribute.IsValid("50"));
            Assert.IsTrue(attribute.IsValid(100));
            Assert.IsTrue(attribute.IsValid("10000000000"));
            Assert.IsFalse(attribute.IsValid("41"));
            Assert.IsFalse(attribute.IsValid("10"));
            Assert.IsFalse(attribute.IsValid(0));
            Assert.IsFalse(attribute.IsValid("-1"));
            Assert.IsFalse(attribute.IsValid(-50));
            Assert.IsFalse(attribute.IsValid("fifty"));
        }

        [TestMethod]
        public void IsValidDoubleTests()
        {
            const double min = 3.50f;

            var attribute = new MinAttribute(min);

            Assert.IsTrue(attribute.IsValid(null));  // Optional values are always valid
            Assert.IsTrue(attribute.IsValid("4"));
            Assert.IsTrue(attribute.IsValid("4.5"));
            Assert.IsTrue(attribute.IsValid(100));
            Assert.IsTrue(attribute.IsValid("100.42"));
            Assert.IsFalse(attribute.IsValid(3));
            Assert.IsFalse(attribute.IsValid("3.498"));
            Assert.IsFalse(attribute.IsValid("-5"));
            Assert.IsFalse(attribute.IsValid("INVALID STRING"));
        }

        [TestMethod]
        public void ErrorResourcesTest()
        {
            var attribute = new MinAttribute(1);
            attribute.ErrorMessageResourceName = "ErrorMessage";
            attribute.ErrorMessageResourceType = typeof(ErrorResources);

            const string invalidValue = "a";

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual("error message", result.ErrorMessage);
        }

        [TestMethod]
        public void GlobalizedErrorResourcesTest()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-MX");

            var attribute = new MinAttribute(1);
            attribute.ErrorMessageResourceName = "ErrorMessage";
            attribute.ErrorMessageResourceType = typeof(ErrorResources);

            const string invalidValue = "a";

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual("mensaje de error", result.ErrorMessage);
        }

        [TestMethod]
        public void ErrorMessageTest()
        {
            var attribute = new MinAttribute(1);
            attribute.ErrorMessage = "SampleErrorMessage";

            const string invalidValue = "a";

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual("SampleErrorMessage", result.ErrorMessage);
        }
    }
}
