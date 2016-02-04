using System.Web.Mvc;

namespace DataAnnotationsExtensions.ClientValidation.Rules
{
    public class ModelClientValidationFileExtensionsRule : ModelClientValidationRule
    {
        public ModelClientValidationFileExtensionsRule(string errorMessage, string extensionsRegex)
        {
            ErrorMessage = errorMessage;
            ValidationType = "regex";
            ValidationParameters["pattern"] = extensionsRegex; //match extensions at end of string
        }
    }
}