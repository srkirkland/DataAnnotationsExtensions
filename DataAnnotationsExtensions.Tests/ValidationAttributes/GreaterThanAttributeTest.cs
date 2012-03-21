using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
    [TestClass]
    public class GreaterThanAttributeTest
    {
        protected CompareObject<DateTime> _mainObject;
        protected CompareObject<DateTime> _otherObject;
        protected ValidationContext _testContext;
        protected BaseComparisonAttribute _attribute;
        protected ValidationResult _result;

        [TestInitialize]
        public void Initialize()
        {
            _mainObject = new CompareObject<DateTime>(DateTime.Now.Date.AddDays(2));
            _otherObject = new CompareObject<DateTime>(DateTime.Now.Date);
            _testContext = new ValidationContext(_otherObject, null, null);
            _attribute = new GreaterThanAttribute("CompareProperty");
        }

        public void Because(object value)
        {
            _attribute.Validate(value, _testContext);
        }
        public void Because()
        {
            Because(_mainObject.CompareProperty);
        }
        public void BecauseWithResult()
        {
            _result = _attribute.GetValidationResult(_mainObject.CompareProperty, _testContext);
        }

        [TestMethod]
        public void ValidateDoesNotThrowWhenComparedObjectsAreEqual()
        {
            Because();
        }
        [TestMethod]
        public void ValidateDoesNotThrowWhenComparedIntsAreEqual()
        {
            var mainObject = new CompareObject<int>(4);
            var otherObject = new CompareObject<int>(2);
            _testContext = new ValidationContext(otherObject, null, null);

            Because(mainObject.CompareProperty);
        }
        [TestMethod]
        public void ValidateDoesNotThrowWhenComparedDoublesAreEqual()
        {
            var mainObject = new CompareObject<double>(4);
            var otherObject = new CompareObject<double>(2);
            _testContext = new ValidationContext(otherObject, null, null);

            Because(mainObject.CompareProperty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateThrowsWhenComparedToNull()
        {
            _attribute = new GreaterThanAttribute(null);
            
            Because();
        }


        [TestMethod]
        [ExpectedException(typeof(ValidationException), "'CurrentProperty' and 'CompareProperty' do not match.")]
        public void ValidateThrowsWhenComparedObjectsAreNotGreater()
        {
            _mainObject = new CompareObject<DateTime>(DateTime.Now.Date.AddDays(-2));

            Because();
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException), "Could not find a property named UnknownPropertyName.")]
        public void ValidateThrowsWhenPropertyNameIsUnknown()
        {
            _attribute = new GreaterThanAttribute("UnknownPropertyName");
            
            Because();
        }

        // TODO: inheritance isn't valid; original test on EqualToAttributeTests isn't valid either b/c it should throw an exception but doesn't
        //[TestMethod]
        //[ExpectedException(typeof(ValidationException), "'CurrentProperty' and 'CompareProperty' do not match.")]
        //public void GreaterThanAttributeCanBeDerivedFromAndOverrideIsValid()
        //{
        //    _mainObject = new CompareObject<DateTime>(DateTime.Now.Date.AddDays(-2));
        //    _attribute = new DerivedGreaterThanAttribute("CompareProperty");

        //    Because();
        //}

        [TestMethod]
        public void ErrorResourcesTest()
        {
            _mainObject = new CompareObject<DateTime>(DateTime.Now.Date.AddDays(-2));
            _attribute = new GreaterThanAttribute("CompareProperty")
                                {
                                    ErrorMessageResourceName = "ErrorMessage",
                                    ErrorMessageResourceType = typeof(ErrorResources)
                                };

            BecauseWithResult();

            Assert.AreEqual(ErrorResources.ErrorMessage, _result.ErrorMessage);
        }


        [TestMethod]
        public void ErrorMessageTest()
        {
            _mainObject = new CompareObject<DateTime>(DateTime.Now.Date.AddDays(-2));

            _attribute = new GreaterThanAttribute("CompareProperty")
            {
                ErrorMessage = "SampleErrorMessage"
            };

            BecauseWithResult();

            Assert.AreEqual("SampleErrorMessage", _result.ErrorMessage);
        }

        protected class DerivedGreaterThanAttribute : GreaterThanAttribute
        {
            public DerivedGreaterThanAttribute(string otherProperty)
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

        protected class CompareObject<T>
        {
            public T CompareProperty { get; set; }

            public CompareObject(T otherValue)
            {
                CompareProperty = otherValue;
            }
        }
    }
}