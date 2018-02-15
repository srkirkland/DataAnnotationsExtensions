using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAnnotationsExtensions.Tests.Doubles;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
    [TestClass]
    public class FileExtensionsAttributeTest : TestBase
    {
        [TestMethod]
        public void DefaultExtensions()
        {
            Assert.AreEqual("png,jpg,jpeg,gif", new FileExtensionsAttribute().Extensions);
        }

        [TestMethod]
        public void IsValidWithNoArgumentTests()
        {
            var attribute = new FileExtensionsAttribute();

            Assert.IsTrue(attribute.IsValid(null));  // Optional values are always valid
            Assert.IsTrue(attribute.IsValid("foo.png"));
            Assert.IsTrue(attribute.IsValid("foo.jpeg"));
            Assert.IsTrue(attribute.IsValid("foo.jpg"));
            Assert.IsTrue(attribute.IsValid("foo.gif"));
            Assert.IsTrue(attribute.IsValid(new HttpPostedFileBaseStub("foo.gif")));
            Assert.IsTrue(attribute.IsValid(@"C:\Foo\bar.png"));
            Assert.IsFalse(attribute.IsValid("foo"));
            Assert.IsFalse(attribute.IsValid("foo.doc"));
            Assert.IsFalse(attribute.IsValid("foo.txt"));
            Assert.IsFalse(attribute.IsValid("foo.png.txt"));
            Assert.IsFalse(attribute.IsValid(new HttpPostedFileBaseStub("foo.png.txt")));
        }

        [TestMethod]
        public void IsValidWithCustomArgumentsTests()
        {
            var attribute = new FileExtensionsAttribute("pdf|doc|docx|rtf");

            Assert.IsTrue(attribute.IsValid(null));  // Optional values are always valid
            Assert.IsTrue(attribute.IsValid("foo.pdf"));
            Assert.IsTrue(attribute.IsValid("foo.doc"));
            Assert.IsTrue(attribute.IsValid("foo.docx"));
            Assert.IsTrue(attribute.IsValid("foo.rtf"));
            Assert.IsTrue(attribute.IsValid(new HttpPostedFileBaseStub("foo.rtf")));
            Assert.IsTrue(attribute.IsValid(@"C:\Foo\bar.pdf"));
            Assert.IsFalse(attribute.IsValid("foo"));
            Assert.IsFalse(attribute.IsValid("foo.png"));
            Assert.IsFalse(attribute.IsValid("foo.jpeg"));
            Assert.IsFalse(attribute.IsValid(new HttpPostedFileBaseStub("foo.jpeg")));
            Assert.IsFalse(attribute.IsValid("foo.doc.txt"));
        }

        [TestMethod]
        public void ErrorResourcesTest()
        {
            var attribute = new FileExtensionsAttribute();
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

            var attribute = new FileExtensionsAttribute();
            attribute.ErrorMessageResourceName = "ErrorMessage";
            attribute.ErrorMessageResourceType = typeof(ErrorResources);

            const string invalidValue = "a";

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual("mensaje de error", result.ErrorMessage);
        }

        [TestMethod]
        public void ErrorMessageTest()
        {
            var attribute = new FileExtensionsAttribute();
            attribute.ErrorMessage = "SampleErrorMessage";

            const string invalidValue = "a";

            var result = attribute.GetValidationResult(invalidValue, new ValidationContext(0, null, null));

            Assert.AreEqual("SampleErrorMessage", result.ErrorMessage);
        }
    }
}
