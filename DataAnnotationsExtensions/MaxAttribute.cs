using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DataAnnotationsExtensions.Resources;

namespace DataAnnotationsExtensions
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MaxAttribute : DataTypeAttribute
    {
        private readonly double _max;

        public MaxAttribute(int max)
            : base("max")
        {
            _max = max;
            ErrorMessage = ValidatorResources.MaxAttribute_Invalid;
        }

        public MaxAttribute(double max)
            : base("max")
        {
            _max = max;
            ErrorMessage = ValidatorResources.MaxAttribute_Invalid;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, _max);
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            double valueAsDouble;

            var isDouble = double.TryParse(Convert.ToString(value), NumberStyles.Any, NumberFormatInfo.InvariantInfo, out valueAsDouble);

            return isDouble && valueAsDouble <= _max;
        }
    }
}