﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
    [TestClass]
    public class EqualToAttributeTest : TestBase
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateThrowsWhenComparedToNull()
        {
            new EqualToAttribute(null);
        }

        [TestMethod]
        public void ValidateDoesNotThrowWhenComparedObjectsAreEqual()
        {
            object otherObject = new CompareObject("test");
            CompareObject currentObject = new CompareObject("test");
            ValidationContext testContext = new ValidationContext(otherObject, null, null);

            EqualToAttribute attr = new EqualToAttribute("CompareProperty");
            attr.Validate(currentObject.CompareProperty, testContext);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException), "'CurrentProperty' and 'CompareProperty' do not match.")]
        public void ValidateThrowsWhenComparedObjectsAreNotEqual()
        {
            CompareObject currentObject = new CompareObject("a");
            object otherObject = new CompareObject("b");

            ValidationContext testContext = new ValidationContext(otherObject, null, null);
            testContext.DisplayName = "CurrentProperty";

            EqualToAttribute attr = new EqualToAttribute("CompareProperty");
            
            attr.Validate(currentObject.CompareProperty, testContext);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException), "Could not find a property named UnknownPropertyName.")]
        public void ValidateThrowsWhenPropertyNameIsUnknown()
        {
            CompareObject currentObject = new CompareObject("a");
            object otherObject = new CompareObject("b");

            ValidationContext testContext = new ValidationContext(otherObject, null, null);
            testContext.DisplayName = "CurrentProperty";

            EqualToAttribute attr = new EqualToAttribute("UnknownPropertyName");

            attr.Validate(currentObject.CompareProperty, testContext);
        }

        [TestMethod]
        public void EqualToAttributeCanBeDerivedFromAndOverrideIsValid()
        {
            object otherObject = new CompareObject("a");
            CompareObject currentObject = new CompareObject("b");
            ValidationContext testContext = new ValidationContext(otherObject, null, null);

            DerivedEqualToAttribute attr = new DerivedEqualToAttribute("CompareProperty");
            attr.Validate(currentObject.CompareProperty, testContext);
        }

        [TestMethod]
        public void ErrorResourcesTest()
        {
            var currentObject = new CompareObject("a");
            object otherObject = new CompareObject("b");

            var testContext = new ValidationContext(otherObject, null, null);
            testContext.DisplayName = "CurrentProperty";

            var attribute = new EqualToAttribute("CompareProperty")
                                {
                                    ErrorMessageResourceName = "ErrorMessage",
                                    ErrorMessageResourceType = typeof (ErrorResources)
                                };

            var result = attribute.GetValidationResult(currentObject, new ValidationContext(otherObject, null, null));

            Assert.AreEqual("error message", result.ErrorMessage);
        }

        [TestMethod]
        public void GlobalizedErrorResourcesTest()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-MX");

            var currentObject = new CompareObject("a");
            object otherObject = new CompareObject("b");

            var testContext = new ValidationContext(otherObject, null, null);
            testContext.DisplayName = "CurrentProperty";

            var attribute = new EqualToAttribute("CompareProperty")
            {
                ErrorMessageResourceName = "ErrorMessage",
                ErrorMessageResourceType = typeof(ErrorResources)
            };

            var result = attribute.GetValidationResult(currentObject, new ValidationContext(otherObject, null, null));

            Assert.AreEqual("mensaje de error", result.ErrorMessage);
        }

        [TestMethod]
        public void ErrorMessageTest()
        {
            var currentObject = new CompareObject("a");
            object otherObject = new CompareObject("b");

            var testContext = new ValidationContext(otherObject, null, null);
            testContext.DisplayName = "CurrentProperty";

            var attribute = new EqualToAttribute("CompareProperty")
            {
                ErrorMessage = "SampleErrorMessage"
            };

            var result = attribute.GetValidationResult(currentObject, new ValidationContext(otherObject, null, null));

            Assert.AreEqual("SampleErrorMessage", result.ErrorMessage);
        }

        private class DerivedEqualToAttribute : EqualToAttribute
        {
            public DerivedEqualToAttribute(string otherProperty)
                : base(otherProperty)
            {
            }

            public override bool IsValid(object value)
            {
                return false;
            }

            protected override ValidationResult IsValid(object value, ValidationContext context)
            {
                return null;
            }
        }

        private class CompareObject
        {
            public string CompareProperty { get; set; }

            public CompareObject(string otherValue)
            {
                CompareProperty = otherValue;
            }
        }
    }
}