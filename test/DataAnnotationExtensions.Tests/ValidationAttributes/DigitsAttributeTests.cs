using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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
            Assert.IsTrue(attribute.IsValid("6708025174"));
            //really big number
            Assert.IsTrue(attribute.IsValid("23748962347868791263748163874628397458217396478192354987253468127354782163478623894761239874523"));
            Assert.IsTrue(attribute.IsValid(1000000000000000000)); //big number
            Assert.IsFalse(attribute.IsValid(14.50));
            Assert.IsFalse(attribute.IsValid(-10)); //Does not allow negative numbers
            Assert.IsFalse(attribute.IsValid("-50"));
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
            var attribute = new DigitsAttribute();
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

            var attribute = new DigitsAttribute();
            attribute.ErrorMessageResourceName = "ErrorMessage";
            attribute.ErrorMessageResourceType = typeof(ErrorResources);

            const string invalidValue = "a";

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual("mensaje de error", result.ErrorMessage);
        }

        [TestMethod]
        public void ErrorMessageTest()
        {
            var attribute = new DigitsAttribute();
            attribute.ErrorMessage = "SampleErrorMessage";

            const string invalidValue = "a";

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual("SampleErrorMessage", result.ErrorMessage);
        }
    }
}