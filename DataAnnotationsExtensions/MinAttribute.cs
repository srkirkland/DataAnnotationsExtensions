using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace DataAnnotationsExtensions
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MinAttribute : DataTypeAttribute
    {
        private readonly double _min;
        
        public MinAttribute(int min) : base("min")
        {
            _min = min;
            ErrorMessage = "";
        }

        public MinAttribute(double min) : base("min")
        {
            _min = min;
            ErrorMessage = "";
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;
            
            double minimum;

            var isDouble = double.TryParse(Convert.ToString(value), NumberStyles.Any, NumberFormatInfo.InvariantInfo, out minimum);

            return isDouble && minimum >= _min;
        }
    }
}
