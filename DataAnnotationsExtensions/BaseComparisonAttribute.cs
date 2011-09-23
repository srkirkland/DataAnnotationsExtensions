using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using DataAnnotationsExtensions.Resources;

namespace DataAnnotationsExtensions
{
    public abstract class BaseComparisonAttribute : ValidationAttribute
    {
        protected BaseComparisonAttribute(string otherProperty)
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

        internal abstract string GetDefaultError();
        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = GetDefaultError();
            }

            var otherPropertyDisplayName = OtherPropertyDisplayName ?? OtherProperty;

            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, otherPropertyDisplayName);
        }

        internal abstract bool Compare(object objA, object objB);
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var memberNames = new[] { validationContext.MemberName };

            PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
            if (otherPropertyInfo == null)
            {
                return new ValidationResult(String.Format(CultureInfo.CurrentCulture, ValidatorResources.EqualTo_UnknownProperty, OtherProperty), memberNames);
            }

            var displayAttribute =
                otherPropertyInfo.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;

            if (displayAttribute != null && !string.IsNullOrWhiteSpace(displayAttribute.Name))
            {
                OtherPropertyDisplayName = displayAttribute.Name;
            }

            object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
            if (!Compare(value, otherPropertyValue))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName), memberNames);
            }
            return null;
        }
    }
}