using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using DataAnnotationsExtensions.Resources;

namespace DataAnnotationsExtensions
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CreditCardAttribute : DataTypeAttribute
    {
        public CreditCardAttribute()
            : base("creditcard")
        {
        }

        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = ValidatorResources.CreditCardAttribute_Invalid;
            }

            return base.FormatErrorMessage(name);
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var ccValue = value as string;
            if (ccValue == null)
            {
                return false;
            }

            if (!new Regex("[0-9\\-]+").IsMatch(ccValue))
            {
                return false;
            }

            ccValue = ccValue.Replace("-", string.Empty).Replace(" ", string.Empty);

            if (string.IsNullOrEmpty(ccValue)) return false; //Don't accept only dashes/spaces

            // Basing min and max length on
            // http://developer.ean.com/general_info/Valid_Credit_Card_Types
            if (ccValue.Length < 13 || ccValue.Length > 19)
            {
                return false;
            }

            int checksum = 0;
            bool evenDigit = false;

            // http://www.beachnet.com/~hstiles/cardtype.html
            foreach (char digit in ccValue.Reverse())
            {
                if (!Char.IsDigit(digit))
                {
                    return false;
                }

                int digitValue = (digit - '0') * (evenDigit ? 2 : 1);
                evenDigit = !evenDigit;

                while (digitValue > 0)
                {
                    checksum += digitValue % 10;
                    digitValue /= 10;
                }
            }

            return (checksum % 10) == 0;
        }
    }
}