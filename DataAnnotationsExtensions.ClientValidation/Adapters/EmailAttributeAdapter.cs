using System.Collections.Generic;
using System.Web.Mvc;
using DataAnnotationsExtensions.ClientValidation.Rules;

namespace DataAnnotationsExtensions.ClientValidation.Adapters
{
    public class EmailAttributeAdapter : DataAnnotationsModelValidator<EmailAttribute>
    {
        public EmailAttributeAdapter(ModelMetadata metadata, ControllerContext context, EmailAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationEmailRule(ErrorMessage) };
        }
    }
}