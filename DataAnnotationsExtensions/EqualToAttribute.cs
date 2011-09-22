using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using DataAnnotationsExtensions.Resources;

namespace DataAnnotationsExtensions
{
    /// <summary>
    /// Validates that the property has the same value as the given 'otherProperty' 
    /// </summary>
    /// <remarks>
    /// From Mvc3 Futures
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EqualToAttribute : BaseComparisonAttribute
    {
        public EqualToAttribute(string otherProperty) : base(otherProperty) {}

        internal override string GetDefaultError()
        {
            return ValidatorResources.CompareAttribute_MustMatch;
        }

        internal override bool Compare(object objA, object objB)
        {
            return Equals(objA, objB);
        }
    }
}