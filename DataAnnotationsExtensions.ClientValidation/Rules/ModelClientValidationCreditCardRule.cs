using System.Web.Mvc;

namespace DataAnnotationsExtensions.ClientValidation.Rules
{
    public class ModelClientValidationCreditCardRule : ModelClientValidationRule
    {
        public ModelClientValidationCreditCardRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "creditcard";
        }
    }

    public class ModelClientValidationNumericRule : ModelClientValidationRule
    {
        public ModelClientValidationNumericRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "number";
        }
    }
}