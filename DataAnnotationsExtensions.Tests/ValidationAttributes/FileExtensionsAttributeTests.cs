using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
    [TestClass]
    public class FileExtensionsAttributeTest
    {
        [TestMethod]
        public void DefaultExtensions()
        {
            Assert.AreEqual("png,jpg,jpeg,gif", new FileExtensionsAttribute(null).Extensions);
        }

        [TestMethod]
        public void IsValidWithNoArgumentTests()
        {
            var attribute = new FileExtensionsAttribute(null);

            Assert.IsTrue(attribute.IsValid(null));  // Optional values are always valid
            Assert.IsTrue(attribute.IsValid("foo.png"));
            Assert.IsTrue(attribute.IsValid("foo.jpeg"));
            Assert.IsTrue(attribute.IsValid("foo.jpg"));
            Assert.IsTrue(attribute.IsValid("foo.gif"));
            Assert.IsTrue(attribute.IsValid(@"C:\Foo\bar.png"));
            Assert.IsFalse(attribute.IsValid("foo"));
            Assert.IsFalse(attribute.IsValid("foo.doc"));
            Assert.IsFalse(attribute.IsValid("foo.txt"));
            Assert.IsFalse(attribute.IsValid("foo.png.txt"));
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
            Assert.IsTrue(attribute.IsValid(@"C:\Foo\bar.pdf"));
            Assert.IsFalse(attribute.IsValid("foo"));
            Assert.IsFalse(attribute.IsValid("foo.png"));
            Assert.IsFalse(attribute.IsValid("foo.jpeg"));
            Assert.IsFalse(attribute.IsValid("foo.doc.txt"));
        }
    }
}
