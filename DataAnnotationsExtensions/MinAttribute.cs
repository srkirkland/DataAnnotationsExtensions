using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DataAnnotationsExtensions.Resources;

namespace DataAnnotationsExtensions
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MinAttribute : DataTypeAttribute
    {
        public object Min { get { return _min; } }

        private readonly double _min;
        
        public MinAttribute(int min) : base("min")
        {
            _min = min;
            ErrorMessage = ValidatorResources.MinAttribute_Invalid;
        }

        public MinAttribute(double min) : base("min")
        {
            _min = min;
            ErrorMessage = ValidatorResources.MinAttribute_Invalid;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, _min);
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;
            
            double valueAsDouble;

            var isDouble = double.TryParse(Convert.ToString(value), NumberStyles.Any, NumberFormatInfo.InvariantInfo, out valueAsDouble);

            return isDouble && valueAsDouble >= _min;
        }
    }
}
