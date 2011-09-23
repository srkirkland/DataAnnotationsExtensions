using System;
using System.Collections.Generic;
using System.Text;
using DataAnnotationsExtensions.Resources;

namespace DataAnnotationsExtensions
{
    /// <summary>
    /// Validates that the property is greater than the given 'otherProperty' 
    /// </summary>
    /// <remarks>
    /// From Mvc3 Futures
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class GreaterThanAttribute : BaseComparisonAttribute
    {
        public GreaterThanAttribute(string otherProperty) : base(otherProperty) { }

        Dictionary<Type, Func<object, object, bool>> _typeComparisons = new Dictionary<Type, Func<object, object, bool>>
                                                                            {
                                                                                {typeof(DateTime), (objA, objB) => (DateTime)objA > (DateTime)objB},
                                                                                {typeof(int), (objA, objB) => (int)objA > (int)objB},
                                                                                {typeof(double), (objA, objB) => (double)objA > (double)objB},
    };

        internal override string GetDefaultError()
        {
            return ValidatorResources.CompareAttribute_MustBeGreater;
        }

        internal override bool Compare(object objA, object objB)
        {
            var type = objA.GetType();
            if (_typeComparisons.ContainsKey(type))
                return _typeComparisons[type](objA, objB);
            throw new NotImplementedException(string.Format(ValidatorResources.CompareAttribute_TypeNotSupported, type));
        }
    }
}
