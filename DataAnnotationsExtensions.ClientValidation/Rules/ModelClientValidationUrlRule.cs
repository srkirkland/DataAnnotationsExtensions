using System.Web.Mvc;

namespace DataAnnotationsExtensions.ClientValidation.Rules
{
    public class ModelClientValidationUrlRule : ModelClientValidationRule
    {
        public ModelClientValidationUrlRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "url";
        }
    }
}
