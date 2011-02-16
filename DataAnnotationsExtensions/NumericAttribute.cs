using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DataAnnotationsExtensions.Resources;

namespace DataAnnotationsExtensions
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class NumericAttribute : DataTypeAttribute
    {
        public NumericAttribute() : base("numeric")
        {
            ErrorMessage = ValidatorResources.NumericAttribute_Invalid;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            double retNum;

            return double.TryParse(Convert.ToString(value), NumberStyles.Any, NumberFormatInfo.InvariantInfo, out retNum);
        }
    }
}
