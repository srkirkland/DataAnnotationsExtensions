using System.Collections.Generic;
using System.Web.Mvc;
using DataAnnotationsExtensions.ClientValidation.Rules;

namespace DataAnnotationsExtensions.ClientValidation.Adapters
{
    public class FileExtensionsAttributeAdapter : DataAnnotationsModelValidator<FileExtensionsAttribute>
    {
        public FileExtensionsAttributeAdapter(ModelMetadata metadata, ControllerContext context, FileExtensionsAttribute attribute)
            : base(metadata, context, attribute)
        {
            
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var extensionsRegex = string.Format(@"^.*\.({0})$", Attribute.Extensions.Replace(",", "|"));
            return new[] { new ModelClientValidationFileExtensionsRule(ErrorMessage, extensionsRegex) };
        }
    }
}