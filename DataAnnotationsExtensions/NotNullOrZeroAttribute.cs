using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DataAnnotationsExtensions.Resources;

namespace DataAnnotationsExtensions
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class NotNullOrZeroAttribute : DataTypeAttribute
    {
      
        public NotNullOrZeroAttribute() : base("notNullOrZero")
        {
        }

        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = ValidatorResources.NotNullOrZeroAttribute_Invalid;
            }

            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name);
        }

        public override bool IsValid(object value)
        {
            if (value == null) return false;
            
            double valueAsDouble;
            var isDouble = double.TryParse(Convert.ToString(value), out valueAsDouble);

            return isDouble && valueAsDouble != 0D;
        }
    }
}
