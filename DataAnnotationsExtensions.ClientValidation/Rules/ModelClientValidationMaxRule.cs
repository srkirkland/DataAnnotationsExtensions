using System.Web.Mvc;

namespace DataAnnotationsExtensions.ClientValidation.Rules
{
    public class ModelClientValidationMaxRule : ModelClientValidationRule
    {
        public ModelClientValidationMaxRule(string errorMessage, object max)
        {
            ErrorMessage = errorMessage;
            ValidationType = "range";
            ValidationParameters["max"] = max;
        }
    }
}