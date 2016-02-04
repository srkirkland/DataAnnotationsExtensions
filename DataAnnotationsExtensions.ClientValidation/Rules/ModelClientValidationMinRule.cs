using System.Web.Mvc;

namespace DataAnnotationsExtensions.ClientValidation.Rules
{
    public class ModelClientValidationMinRule : ModelClientValidationRule
    {
        public ModelClientValidationMinRule(string errorMessage, object min)
        {
            ErrorMessage = errorMessage;
            ValidationType = "range";
            ValidationParameters["min"] = min;
            ValidationParameters["max"] = double.MaxValue;
        }
    }
}