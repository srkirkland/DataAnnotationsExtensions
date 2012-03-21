using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
    [TestClass]
    public class GreaterThanOrEqualToAttributeTest : GreaterThanAttributeTest
    {
        [TestInitialize]
        public void Initialize()
        {
            base.Initialize();
            _attribute = new GreaterThanOrEqualToAttribute("CompareProperty");
        }
        
        [TestMethod]
        public void ValidateDoesNotThrowWhenComparedDoublesAreEqual()
        {
            var mainObject = new CompareObject<double>(4);
            var otherObject = new CompareObject<double>(4);
            _testContext = new ValidationContext(otherObject, null, null);

            Because(mainObject.CompareProperty);
        }
        [TestMethod]
        [ExpectedException(typeof(ValidationException), "'CurrentProperty' and 'CompareProperty' do not match.")]
        public void ValidateThrowsWhenComparedDoublesAreLessThan()
        {
            var mainObject = new CompareObject<double>(4);
            var otherObject = new CompareObject<double>(14);
            _testContext = new ValidationContext(otherObject, null, null);

            Because(mainObject.CompareProperty);
        }
    }
}