using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using DataAnnotationsExtensions.Resources;

namespace DataAnnotationsExtensions
{
    /// <summary>
    /// Validates that the property has the same value as the given 'otherProperty' 
    /// </summary>
    /// <remarks>
    /// From Mvc3 Futures
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EqualToAttribute : ValidationAttribute
    {
        public EqualToAttribute(string otherProperty)
        {
            if (otherProperty == null)
            {
                throw new ArgumentNullException("otherProperty");
            }
            OtherProperty = otherProperty;
            OtherPropertyDisplayName = null;
        }

        public string OtherProperty { get; private set; }

        public string OtherPropertyDisplayName { get; set; }

        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = ValidatorResources.CompareAttribute_MustMatch;
            }

            var otherPropertyDisplayName = OtherPropertyDisplayName ?? OtherProperty;

            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, otherPropertyDisplayName);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
            if (otherPropertyInfo == null)
            {
                return new ValidationResult(String.Format(CultureInfo.CurrentCulture, ValidatorResources.EqualTo_UnknownProperty, OtherProperty));
            }

            var displayAttribute =
                otherPropertyInfo.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;

            if (displayAttribute != null && !string.IsNullOrWhiteSpace(displayAttribute.Name))
            {
                OtherPropertyDisplayName = displayAttribute.Name;
            }

            object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
            if (!Equals(value, otherPropertyValue))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return null;
        }
    }
}