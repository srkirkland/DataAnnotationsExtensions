using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DataAnnotationExtensions.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
    [TestClass]
    public class MaxAttributeTests : TestBase
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

        [TestMethod]
        public void ErrorResourcesTest()
        {
            var attribute = new MaxAttribute(1);
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

            var attribute = new MaxAttribute(1);
            attribute.ErrorMessageResourceName = "ErrorMessage";
            attribute.ErrorMessageResourceType = typeof(ErrorResources);

            const string invalidValue = "a";

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual("mensaje de error", result.ErrorMessage);
        }

        [TestMethod]
        public void ErrorMessageTest()
        {
            var attribute = new MaxAttribute(1);
            attribute.ErrorMessage = "SampleErrorMessage";

            const string invalidValue = "a";

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual("SampleErrorMessage", result.ErrorMessage);
        }
    }
}