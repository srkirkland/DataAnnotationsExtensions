using System.Web.Mvc;

namespace DataAnnotationsExtensions.ClientValidation.Rules
{
    public class ModelClientValidationFileExtensionsRule : ModelClientValidationRule
    {
        public ModelClientValidationFileExtensionsRule(string errorMessage, string extensions)
        {
            ErrorMessage = errorMessage;
            ValidationType = "accept";
            ValidationParameters["exts"] = extensions;
        }
    }
}