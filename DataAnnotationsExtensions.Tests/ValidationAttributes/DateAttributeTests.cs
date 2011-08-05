using System;
using System.ComponentModel.DataAnnotations;
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
            
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-us");

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

        [TestMethod]
        public void ErrorResourcesTest()
        {
            var attribute = new DateAttribute();
            attribute.ErrorMessageResourceName = "ErrorMessage";
            attribute.ErrorMessageResourceType = typeof(ErrorResources);

            const int invalidValue = 0;

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual(ErrorResources.ErrorMessage, result.ErrorMessage);
        }

        [TestMethod]
        public void ErrorMessageTest()
        {
            var attribute = new DateAttribute();
            attribute.ErrorMessage = "SampleErrorMessage";

            const int invalidValue = 0;

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual("SampleErrorMessage", result.ErrorMessage);
        }
    }
}
