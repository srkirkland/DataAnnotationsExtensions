using System.Web.Mvc;

namespace DataAnnotationsExtensions.ClientValidation.Rules
{
    public class ModelClientValidationIntegerRule : ModelClientValidationRule
    {
        private const string Regex = @"^-?\d+$";

        public ModelClientValidationIntegerRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "regex";
            ValidationParameters["pattern"] = Regex;
        }
    }
}