using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
    [TestClass]
    public class DateNotBeforeAttributeTests
    {
        [TestMethod]
        public void IsValidTestFails()
        {

            //Arrange
            var badDateInstance = new DateTestClass {earlyDate = DateTime.Today, laterDate = DateTime.Today.AddDays(-1)};


            //Act
            var errors = ValidationRunner.ValidateAttributes(badDateInstance);
            var haveProperErrorMessage = errors.Any(x => x.ErrorMessage.Equals("earlyDate cannot be before laterDate"));
            //Assert
            Assert.IsTrue(haveProperErrorMessage);
        }
        [TestMethod]
        public void IsValidTestPasses()
        {

            //Arrange
            var badDateInstance = new DateTestClass {earlyDate = DateTime.Today.AddDays(-1), laterDate = DateTime.Today};


            //Act
            var errors = ValidationRunner.ValidateAttributes(badDateInstance);
            var haveProperErrorMessage = errors.Any(x => x.ErrorMessage.Equals("earlyDate cannot be before laterDate"));
            //Assert
            Assert.IsFalse(haveProperErrorMessage);
        }

    }

    [DateNotBefore("earlyDate","laterDate",ErrorMessage = "earlyDate cannot be before laterDate")]
    public class DateTestClass
    {
        public DateTime earlyDate { get; set; }
        public DateTime laterDate { get; set; }
    }


    public class ValidationRunner
    {
        public static List<ValidationIssue> ValidateAttributes<TEntity>(TEntity entity)
        {
            var validationInstance = new ValidationRunner();
            return validationInstance.ValidateAttributesInternal(entity);
        }

        protected List<ValidationIssue> ValidateAttributesInternal<TEntity>(TEntity entity)
        {
            var validationIssues = new List<ValidationIssue>();

            var props = typeof(TEntity).GetProperties();
            foreach (var propertyInfo in props)
            {
                ValidateProperty(validationIssues, entity, propertyInfo);
            }

            ValidationAttribute[] classProps = (ValidationAttribute[])typeof(TEntity).GetCustomAttributes(typeof(ValidationAttribute), false);
            foreach (var classProp in classProps)
            {
                ValidateClassProperty(validationIssues, entity, classProp);
            }
            return validationIssues;
        }

        private void ValidateClassProperty<TEntity>(List<ValidationIssue> validationIssues, TEntity entity, ValidationAttribute classProp)
        {
            if (!classProp.IsValid(entity))
                validationIssues.Add(new ValidationIssue("Dates", entity, classProp.ErrorMessage));
        }

        protected virtual void ValidateProperty<TEntity>(List<ValidationIssue> validationIssues, TEntity entity, PropertyInfo propertyInfo)
        {
            var validators = propertyInfo.GetCustomAttributes(typeof(ValidationAttribute), true);
            foreach (var validator in validators)
            {
                ValidateValidator(validationIssues, entity, propertyInfo, (ValidationAttribute)validator);
            }
        }

        private void ValidateValidator<TEntity>(List<ValidationIssue> validationIssues, TEntity entity, PropertyInfo propertyInfo, ValidationAttribute validator)
        {
            var value = propertyInfo.GetValue(entity, null);
            if (!validator.IsValid(value))
                validationIssues.Add(new ValidationIssue(propertyInfo.Name, value, validator.ErrorMessage));
        }
    }

    public class ValidationIssue
    {
        public ValidationIssue(string key, object attemptedValue, string errorMessage)
        {
            Key = key;
            AttemptedValue = attemptedValue;
            ErrorMessage = errorMessage;
        }

        protected string Key { get; set; }

        protected object AttemptedValue { get; set; }

        public string ErrorMessage { get; set; }
    }
}
