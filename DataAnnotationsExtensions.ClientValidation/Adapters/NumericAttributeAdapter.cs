using System.Collections.Generic;
using System.Web.Mvc;
using DataAnnotationsExtensions.ClientValidation.Rules;

namespace DataAnnotationsExtensions.ClientValidation.Adapters
{
    public class NumericAttributeAdapter : DataAnnotationsModelValidator<NumericAttribute>
    {
        public NumericAttributeAdapter(ModelMetadata metadata, ControllerContext context, NumericAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationNumericRule(ErrorMessage) };
        }
    }
}