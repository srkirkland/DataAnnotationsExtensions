using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
    [TestClass]
    public class NotNullOrZeroAttributeTests : TestBase
    {
        [TestMethod]
        public void IsValidIntegerTests()
        {
            var attribute = new NotNullOrZeroAttribute();

            Assert.IsFalse(attribute.IsValid(null));  // Null values are invalid
            Assert.IsTrue(attribute.IsValid("42"));
            Assert.IsTrue(attribute.IsValid(42.5));
            Assert.IsTrue(attribute.IsValid("50"));
            Assert.IsTrue(attribute.IsValid(100));
            Assert.IsTrue(attribute.IsValid("10000000000"));
            Assert.IsFalse(attribute.IsValid(0));
            Assert.IsFalse(attribute.IsValid("0"));
            Assert.IsTrue(attribute.IsValid(-50));
            Assert.IsFalse(attribute.IsValid("fifty"));
        }

        [TestMethod]
        public void IsValidDoubleTests()
        {
            var attribute = new NotNullOrZeroAttribute();

            Assert.IsFalse(attribute.IsValid(null));  // Null values are invalid
            Assert.IsTrue(attribute.IsValid("4"));
            Assert.IsTrue(attribute.IsValid("4.5"));
            Assert.IsTrue(attribute.IsValid(100));
            Assert.IsTrue(attribute.IsValid("100.42"));
            Assert.IsFalse(attribute.IsValid(0));
            Assert.IsFalse(attribute.IsValid("0"));
            Assert.IsFalse(attribute.IsValid("INVALID STRING"));
        }

        [TestMethod]
        public void ErrorResourcesTest()
        {
            var attribute = new NotNullOrZeroAttribute();
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

            var attribute = new NotNullOrZeroAttribute();
            attribute.ErrorMessageResourceName = "ErrorMessage";
            attribute.ErrorMessageResourceType = typeof(ErrorResources);

            const string invalidValue = "a";

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual("mensaje de error", result.ErrorMessage);
        }

        [TestMethod]
        public void ErrorMessageTest()
        {
            var attribute = new NotNullOrZeroAttribute();
            attribute.ErrorMessage = "SampleErrorMessage";

            const string invalidValue = "a";

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual("SampleErrorMessage", result.ErrorMessage);
        }
    }
}
