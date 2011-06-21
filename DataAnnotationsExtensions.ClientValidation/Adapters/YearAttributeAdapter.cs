using System.Collections.Generic;
using System.Web.Mvc;

namespace DataAnnotationsExtensions.ClientValidation.Adapters
{
    public class YearAttributeAdapter : DataAnnotationsModelValidator<YearAttribute>
    {
        public YearAttributeAdapter(ModelMetadata metadata, ControllerContext context, YearAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationRegexRule(ErrorMessage, Attribute.Regex) };
        }
    }
}