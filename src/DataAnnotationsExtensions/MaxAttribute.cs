using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DataAnnotationsExtensions.Resources;

namespace DataAnnotationsExtensions
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MaxAttribute : DataTypeAttribute
    {
        public object Max { get { return _max; } }

        private readonly double _max;

        public MaxAttribute(int max)
            : base("max")
        {
            _max = max;
        }

        public MaxAttribute(double max)
            : base("max")
        {
            _max = max;
        }

        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = ValidatorResources.MaxAttribute_Invalid;
            }

            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, _max);
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            double valueAsDouble;

            var isDouble = double.TryParse(Convert.ToString(value), out valueAsDouble);

            return isDouble && valueAsDouble <= _max;
        }
    }
}