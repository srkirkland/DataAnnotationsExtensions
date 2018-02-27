using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DataAnnotationExtensions.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
    [TestClass]
    public class IntegerAttributeTests : TestBase
    {
        [TestMethod]
        public void IsValidTests()
        {
            var attribute = new IntegerAttribute();

            Assert.IsTrue(attribute.IsValid(null)); // Don't check for required
            Assert.IsTrue(attribute.IsValid("1234"));
            Assert.IsTrue(attribute.IsValid("12345"));
            Assert.IsTrue(attribute.IsValid(14));
            Assert.IsTrue(attribute.IsValid(-10)); //Allows negative numbers
            Assert.IsTrue(attribute.IsValid("-50"));
            Assert.IsFalse(attribute.IsValid(14.50));
            Assert.IsFalse(attribute.IsValid("12.90"));
            Assert.IsFalse(attribute.IsValid("1234.5"));
            Assert.IsFalse(attribute.IsValid("$3.50"));
            Assert.IsFalse(attribute.IsValid("12abc"));
            Assert.IsFalse(attribute.IsValid(DateTime.Now));
            Assert.IsFalse(attribute.IsValid("fourteen"));
        }

        [TestMethod]
        public void ErrorResourcesTest()
        {
            var attribute = new IntegerAttribute();
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

            var attribute = new IntegerAttribute();
            attribute.ErrorMessageResourceName = "ErrorMessage";
            attribute.ErrorMessageResourceType = typeof(ErrorResources);

            const string invalidValue = "a";

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual("mensaje de error", result.ErrorMessage);
        }

        [TestMethod]
        public void ErrorMessageTest()
        {
            var attribute = new IntegerAttribute();
            attribute.ErrorMessage = "SampleErrorMessage";

            const string invalidValue = "a";

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual("SampleErrorMessage", result.ErrorMessage);
        }
    }
}