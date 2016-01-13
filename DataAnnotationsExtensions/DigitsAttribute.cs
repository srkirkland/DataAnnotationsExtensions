using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using DataAnnotationsExtensions.Resources;

namespace DataAnnotationsExtensions
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DigitsAttribute : DataTypeAttribute
    {
        public DigitsAttribute()
            : base("digits")
        {
        }

        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = ValidatorResources.DigitsAttribute_Invalid;
            }

            return base.FormatErrorMessage(name);
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            Regex expression = new Regex(@"^[0-9]*$");
            if (value is string)
                return expression.IsMatch((string) value);
            else
                return expression.IsMatch(value.ToString());
        }
    }
}