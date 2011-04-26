using System.Collections.Generic;
using System.Web.Mvc;
using DataAnnotationsExtensions.ClientValidation.Rules;
using System;

namespace DataAnnotationsExtensions.ClientValidation.Adapters
{
    public class NumericAttributeAdapter : DataAnnotationsModelValidator<NumericAttribute>
    {
        private static readonly HashSet<Type> NumericTypes = new HashSet<Type>(new Type[] {
            typeof(byte), typeof(sbyte),
            typeof(short), typeof(ushort),
            typeof(int), typeof(uint),
            typeof(long), typeof(ulong),
            typeof(float), typeof(double), typeof(decimal)
        });

        public NumericAttributeAdapter(ModelMetadata metadata, ControllerContext context, NumericAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            //Don't add a client validator if the datatype is numeric (the mvc framework will handle that for us)
            Type type = Metadata.ModelType;
            if (!IsNumericType(type))
            {
                yield return new ModelClientValidationNumericRule(ErrorMessage);
            }
        }

        private static bool IsNumericType(Type type)
        {
            Type underlyingType = Nullable.GetUnderlyingType(type); // strip off the Nullable<>
            return NumericTypes.Contains(underlyingType ?? type);
        }
    }
}