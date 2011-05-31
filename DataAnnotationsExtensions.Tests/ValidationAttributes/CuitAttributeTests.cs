using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
	[TestClass]
	public class CuitAttributeTests
	{
		[TestMethod]
		public void IsValidTests()
		{
			var attribute = new CuitAttribute();

			Assert.IsTrue(attribute.IsValid(null));  
			Assert.IsTrue(attribute.IsValid("20245597151"));
			Assert.IsTrue(attribute.IsValid("20-24559715-1"));
			Assert.IsTrue(attribute.IsValid("27-23840320-6"));
			Assert.IsTrue(attribute.IsValid("27238403206"));
			
			Assert.IsFalse(attribute.IsValid("20 24559715 1"));
            Assert.IsFalse(attribute.IsValid("")); 
            Assert.IsFalse(attribute.IsValid("99-99999999-9"));
			Assert.IsFalse(attribute.IsValid("99999999999"));
			Assert.IsFalse(attribute.IsValid("4408 0412 3456 7890"));
			Assert.IsFalse(attribute.IsValid(0));
            Assert.IsFalse(attribute.IsValid(20245597151));
		}

        [TestMethod]
        public void ErrorResourcesTest()
        {
            var attribute = new CuitAttribute();
            attribute.ErrorMessageResourceName = "ErrorMessage";
            attribute.ErrorMessageResourceType = typeof (ErrorResources);

            const int invalidValue = 0;

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual(ErrorResources.ErrorMessage, result.ErrorMessage);
        }

        [TestMethod]
        public void ErrorMessageTest()
        {
            var attribute = new CuitAttribute();
            attribute.ErrorMessage = "SampleErrorMessage";
            
            const int invalidValue = 0;

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual("SampleErrorMessage", result.ErrorMessage);
        }
	}
}