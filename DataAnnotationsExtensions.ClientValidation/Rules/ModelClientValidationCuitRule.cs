using System.Web.Mvc;

namespace DataAnnotationsExtensions.ClientValidation.Rules
{
    public class ModelClientValidationCuitRule : ModelClientValidationRule
    {
        public ModelClientValidationCuitRule(string errorMessage, string regex)
        {
            ErrorMessage = errorMessage;
            ValidationType = "regex";
            ValidationParameters["pattern"] = regex;
        }
    }
}