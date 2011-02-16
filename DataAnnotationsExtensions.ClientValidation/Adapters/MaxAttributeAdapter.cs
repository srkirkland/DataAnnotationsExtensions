using System.Collections.Generic;
using System.Web.Mvc;
using DataAnnotationsExtensions.ClientValidation.Rules;

namespace DataAnnotationsExtensions.ClientValidation.Adapters
{
    public class MaxAttributeAdapter : DataAnnotationsModelValidator<MaxAttribute>
    {
        public MaxAttributeAdapter(ModelMetadata metadata, ControllerContext context, MaxAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationMaxRule(ErrorMessage, Attribute.Max) };
        }
    }
}