using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataAnnotationsExtensions.ClientValidation.Resources;

namespace DataAnnotationsExtensions.ClientValidation.Adapters
{
    public class EqualToValidationAdapter : DataAnnotationsModelValidator<EqualToAttribute>
    {
        public EqualToValidationAdapter(ModelMetadata metadata, ControllerContext context, EqualToAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var otherProp = FormatPropertyForClientValidation(Attribute.OtherProperty);
            //We'll just use the built-in System.Web.Mvc client validation rule
            return new[] { new ModelClientValidationEqualToRule(ErrorMessage, otherProp) };
        }

        public static string FormatPropertyForClientValidation(string property)
        {
            if (property == null)
            {
                throw new ArgumentException(ClientValidationResources.Common_NullOrEmpty, "property");
            }
            return "*." + property;
        }
    }
}