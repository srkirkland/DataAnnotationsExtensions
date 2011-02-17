using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DataAnnotationsExtensions.Resources;

namespace DataAnnotationsExtensions
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DateAttribute : DataTypeAttribute
    {
        public DateAttribute()
            : base(DataType.Date)
        {
            ErrorMessage = ValidatorResources.DateAttribute_Invalid;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            DateTime retDate;

            return DateTime.TryParse(Convert.ToString(value), DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out retDate);
        }
    }
}