using System.Web.Mvc;

namespace DataAnnotationsExtensions.ClientValidation.Rules
{
    public class ModelClientValidationGreaterThanRule : ModelClientValidationRule
    {
        public ModelClientValidationGreaterThanRule(string errorMessage, string otherProperty)
        {
            ErrorMessage = errorMessage;

            ValidationType = "greaterthan";
            ValidationParameters.Add("other", otherProperty);
        }
    }
}