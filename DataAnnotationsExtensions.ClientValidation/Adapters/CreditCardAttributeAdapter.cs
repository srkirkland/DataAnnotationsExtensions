using System.Collections.Generic;
using System.Web.Mvc;
using DataAnnotationsExtensions.ClientValidation.Rules;

namespace DataAnnotationsExtensions.ClientValidation.Adapters
{
    public class CreditCardAttributeAdapter : DataAnnotationsModelValidator<CreditCardAttribute>
    {
        public CreditCardAttributeAdapter(ModelMetadata metadata, ControllerContext context, CreditCardAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationCreditCardRule(ErrorMessage) };
        }
    }
}