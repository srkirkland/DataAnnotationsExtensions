using System;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions.Resources;

namespace DataAnnotationsExtensions
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class NumericAttribute : DataTypeAttribute
    {
        public NumericAttribute() : base("numeric")
        {
        }

        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = ValidatorResources.NumericAttribute_Invalid;
            }

            return base.FormatErrorMessage(name);
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            double retNum;

            return double.TryParse(Convert.ToString(value), out retNum);
        }
    }
}
