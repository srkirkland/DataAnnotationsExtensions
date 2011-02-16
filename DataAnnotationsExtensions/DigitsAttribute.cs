using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DataAnnotationsExtensions.Resources;

namespace DataAnnotationsExtensions
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DigitsAttribute : DataTypeAttribute
    {
        public DigitsAttribute()
            : base("digits")
        {
            ErrorMessage = ValidatorResources.DigitsAttribute_Invalid;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            int retNum;

            return int.TryParse(Convert.ToString(value), NumberStyles.Any, NumberFormatInfo.InvariantInfo, out retNum);
        }
    }
}