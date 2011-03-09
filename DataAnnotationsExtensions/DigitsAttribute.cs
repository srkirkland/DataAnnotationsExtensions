using System;
using System.ComponentModel.DataAnnotations;
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

            int retNum;

            var parseSuccess = int.TryParse(Convert.ToString(value), out retNum);

            return parseSuccess && retNum >= 0;
        }
    }
}