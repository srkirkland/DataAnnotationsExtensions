using System.Web.Mvc;

namespace DataAnnotationsExtensions.ClientValidation.Rules
{
    public class ModelClientValidationCuitRule : ModelClientValidationRule
    {
        public ModelClientValidationCuitRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "cuit";
        }
    }
}