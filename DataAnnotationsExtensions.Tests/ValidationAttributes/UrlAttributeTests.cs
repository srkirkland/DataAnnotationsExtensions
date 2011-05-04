using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
    [TestClass]
    public class UrlAttributeTests
    {
        [TestMethod]
        public void IsValidTests()
        {
            var attribute = new UrlAttribute();
            
            Assert.IsTrue(attribute.IsValid(null));  // Optional values are always valid
            Assert.IsTrue(attribute.IsValid("http://foo.bar"));
            Assert.IsTrue(attribute.IsValid("https://foo.bar"));
            Assert.IsTrue(attribute.IsValid("ftp://foo.bar"));
            Assert.IsFalse(attribute.IsValid("file:///foo.bar"));
            Assert.IsFalse(attribute.IsValid("http://user%password@foo.bar/"));
            Assert.IsFalse(attribute.IsValid("foo.png"));
        }

        [TestMethod]
        public void IsValidWithoutRequiringProtocol() {

            var attribute = new UrlAttribute(RequireProtocol: false);

            Assert.IsTrue(attribute.IsValid("foo.com"));
            
        }

        [TestMethod]
        public void ErrorResourcesTest()
        {
            var attribute = new UrlAttribute();
            attribute.ErrorMessageResourceName = "ErrorMessage";
            attribute.ErrorMessageResourceType = typeof(ErrorResources);

            const string invalidValue = "a";

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual(ErrorResources.ErrorMessage, result.ErrorMessage);
        }

        [TestMethod]
        public void ErrorMessageTest()
        {
            var attribute = new UrlAttribute();
            attribute.ErrorMessage = "SampleErrorMessage";

            const string invalidValue = "a";

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual("SampleErrorMessage", result.ErrorMessage);
        }
    }
}