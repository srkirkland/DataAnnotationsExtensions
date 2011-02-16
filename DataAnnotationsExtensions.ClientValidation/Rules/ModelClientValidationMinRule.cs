using System.Web.Mvc;

namespace DataAnnotationsExtensions.ClientValidation.Rules
{
    public class ModelClientValidationMinRule : ModelClientValidationRule
    {
        public ModelClientValidationMinRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "min";
        }
    }
}