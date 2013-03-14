using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
    [TestClass]
    public class UrlAttributeTests : TestBase
    {
        [TestMethod]
        public void IsValidTests()
        {
            var attribute = new UrlAttribute();
            
            Assert.IsTrue(attribute.IsValid(null));  // Optional values are always valid
            Assert.IsTrue(attribute.IsValid("http://foo.bar"));
            Assert.IsTrue(attribute.IsValid("https://foo.bar"));
            Assert.IsTrue(attribute.IsValid("ftp://foo.bar"));
            Assert.IsTrue(attribute.IsValid("http://foo.bar:12345"));
            Assert.IsTrue(attribute.IsValid("http://localhost"));
            Assert.IsTrue(attribute.IsValid("http://local-host"));
            Assert.IsTrue(attribute.IsValid("http://localhost:67890"));
            Assert.IsTrue(attribute.IsValid("http://localhost:99999/foo.png"));
            Assert.IsFalse(attribute.IsValid("file:///foo.bar"));
            Assert.IsFalse(attribute.IsValid("http://user%password@foo.bar/"));
            Assert.IsFalse(attribute.IsValid("foo.png"));
        }

        [TestMethod]
        public void IsValidWithoutRequiringProtocol() {

            var attribute = new UrlAttribute(UrlOptions.OptionalProtocol);

            Assert.IsTrue(attribute.IsValid(null));  // Optional values are always valid
            Assert.IsTrue(attribute.IsValid("foo.bar"));
            Assert.IsTrue(attribute.IsValid("www.foo.bar"));
            Assert.IsTrue(attribute.IsValid("http://foo.bar"));
            Assert.IsTrue(attribute.IsValid("http://localhost"));
            Assert.IsTrue(attribute.IsValid("localhost"));
            Assert.IsTrue(attribute.IsValid("localhost:12345"));
            Assert.IsFalse(attribute.IsValid("htp://foo.bar"));
            Assert.IsFalse(attribute.IsValid("-localhost"));
            Assert.IsFalse(attribute.IsValid(".localhost"));
            Assert.IsFalse(attribute.IsValid("1localhost"));
        }

        [TestMethod]
        public void IsValidDisallowProtocol()
        {
            var attribute = new UrlAttribute(UrlOptions.DisallowProtocol);

            Assert.IsTrue(attribute.IsValid(null));  // Optional values are always valid
            Assert.IsTrue(attribute.IsValid("foo.bar"));
            Assert.IsTrue(attribute.IsValid("www.foo.bar"));
            Assert.IsTrue(attribute.IsValid("localhost"));
            Assert.IsFalse(attribute.IsValid("https://localhost"));
            Assert.IsFalse(attribute.IsValid("http://foo.bar"));
            Assert.IsFalse(attribute.IsValid("htp://foo.bar"));

        }

        [TestMethod]
        public void IsValidWithUppercaseLetters()
        {

            var attribute = new UrlAttribute();
            
            Assert.IsTrue(attribute.IsValid("http://FOO.bar"));
            Assert.IsTrue(attribute.IsValid("https://foo.BAR"));
            Assert.IsTrue(attribute.IsValid("ftp://FOO.BAR"));
            Assert.IsFalse(attribute.IsValid("file:///Foo.Bar"));
        }

        [TestMethod]
        public void IsValidWithUri()
        {
            var attribute = new UrlAttribute();

            Assert.IsTrue(attribute.IsValid(new Uri("http://foo.bar")));
            Assert.IsTrue(attribute.IsValid(new Uri("http://FOO.bar")));
            Assert.IsTrue(attribute.IsValid(new Uri("https://foo.BAR")));
            Assert.IsTrue(attribute.IsValid(new Uri("ftp://FOO.BAR")));

            Assert.IsFalse(attribute.IsValid(new Uri("file:///foo.bar")));
        }

        [TestMethod]
        public void ErrorResourcesTest()
        {
            var attribute = new UrlAttribute();
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
            
            var attribute = new UrlAttribute();
            attribute.ErrorMessageResourceName = "ErrorMessage";
            attribute.ErrorMessageResourceType = typeof(ErrorResources);

            const string invalidValue = "a";

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual("mensaje de error", result.ErrorMessage);
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