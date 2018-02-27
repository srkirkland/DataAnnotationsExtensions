using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DataAnnotationExtensions.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
	[TestClass]
	public class YearAttributeTests
	{
		[TestMethod]
		public void IsValidTests()
		{
			var attribute = new YearAttribute();

			Assert.IsTrue(attribute.IsValid(null));  
			Assert.IsTrue(attribute.IsValid("2011"));
			Assert.IsTrue(attribute.IsValid("9999"));
			Assert.IsTrue(attribute.IsValid(1234));
			Assert.IsTrue(attribute.IsValid(1111));
			Assert.IsTrue(attribute.IsValid(0123));
			Assert.IsTrue(attribute.IsValid("0123"));
			
			Assert.IsFalse(attribute.IsValid("one"));
			Assert.IsFalse(attribute.IsValid(""));
			Assert.IsFalse(attribute.IsValid(" "));
            Assert.IsFalse(attribute.IsValid("-100"));
            Assert.IsFalse(attribute.IsValid("20000"));
			Assert.IsFalse(attribute.IsValid(0));
		}

        [TestMethod]
        public void ErrorResourcesTest()
        {
            var attribute = new YearAttribute();
            attribute.ErrorMessageResourceName = "ErrorMessage";
            attribute.ErrorMessageResourceType = typeof (ErrorResources);

            const int invalidValue = 0;

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual("error message", result.ErrorMessage);
        }

        [TestMethod]
        public void GlobalizedErrorResourcesTest()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-MX");

            var attribute = new YearAttribute();
            attribute.ErrorMessageResourceName = "ErrorMessage";
            attribute.ErrorMessageResourceType = typeof(ErrorResources);

            const int invalidValue = 0;

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual("mensaje de error", result.ErrorMessage);
        }

        [TestMethod]
        public void ErrorMessageTest()
        {
            var attribute = new YearAttribute();
            attribute.ErrorMessage = "SampleErrorMessage";
            
            const int invalidValue = 0;

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual("SampleErrorMessage", result.ErrorMessage);
        }
	}
}