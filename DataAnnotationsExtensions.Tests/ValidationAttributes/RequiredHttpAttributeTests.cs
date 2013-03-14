using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Web;
using DataAnnotationsExtensions.ServerSideValidators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
    [TestClass]
    public class RequiredHttpAttributeTests
    {
        [TestMethod]
        public void IsValidFallbackTests()
        {
            var attribute = new RequiredHttpAttribute();

            Assert.IsTrue(attribute.IsValid("A"));
            Assert.IsTrue(attribute.IsValid("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"));
            Assert.IsFalse(attribute.IsValid(" "));
            Assert.IsFalse(attribute.IsValid(null));
            Assert.IsFalse(attribute.IsValid(string.Empty));
        }

        [TestMethod]
        public void IsValidRequiredTests()
        {
            var attribute = new RequiredHttpAttribute()
            {
                HttpMethod = "GET"
            };
            HttpRequest request = new HttpRequest("test", "http://localhost", string.Empty)
            {
                RequestType = "GET"
            };
            HttpResponse response = new HttpResponse(HttpWriter.Null);
            HttpContext.Current = new HttpContext(request, response);

            Assert.IsTrue(attribute.IsValid("A"));
            Assert.IsTrue(attribute.IsValid("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"));
            Assert.IsFalse(attribute.IsValid(" "));
            Assert.IsFalse(attribute.IsValid(null));
            Assert.IsFalse(attribute.IsValid(string.Empty));
        }

        [TestMethod]
        public void IsValidMultiMethodRequiredTests()
        {
            var attribute = new RequiredHttpAttribute()
            {
                HttpMethod = "GeT|PosT"
            };
            HttpRequest request = new HttpRequest("test", "http://localhost", string.Empty)
            {
                RequestType = "post"
            };
            HttpResponse response = new HttpResponse(HttpWriter.Null);
            HttpContext.Current = new HttpContext(request, response);

            Assert.IsTrue(attribute.IsValid("A"));
            Assert.IsTrue(attribute.IsValid("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"));
            Assert.IsFalse(attribute.IsValid(" "));
            Assert.IsFalse(attribute.IsValid(null));
            Assert.IsFalse(attribute.IsValid(string.Empty));
        }

        [TestMethod]
        public void IsValidIgnoreRequiredTests()
        {
            var attribute = new RequiredHttpAttribute()
            {
                HttpMethod = "POST"
            };
            HttpRequest request = new HttpRequest("test", "http://localhost", string.Empty)
            {
                RequestType = "Get"
            };
            HttpContext context = new HttpContext(request, null);

            Assert.IsTrue(attribute.IsValid("A"));
            Assert.IsTrue(attribute.IsValid("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"));
            Assert.IsTrue(attribute.IsValid(" "));
            Assert.IsTrue(attribute.IsValid(null));
            Assert.IsTrue(attribute.IsValid(string.Empty));
        }
    }
}
