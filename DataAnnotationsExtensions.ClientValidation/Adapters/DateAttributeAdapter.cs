using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataAnnotationsExtensions.ClientValidation.Rules;

namespace DataAnnotationsExtensions.ClientValidation.Adapters
{
    public class DateAttributeAdapter : DataAnnotationsModelValidator<DateAttribute>
    {
        public DateAttributeAdapter(ModelMetadata metadata, ControllerContext context, DateAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            if (Metadata.ModelType != typeof (DateTime)) //only add validation for non
            {
                return new[] {new ModelClientValidationDateRule(ErrorMessage)};
            }

            return new ModelClientValidationRule[0];
        }
    }
}