using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web;

namespace DataAnnotationsExtensions
{
    /// <summary>
    /// RequiredHttpAttribute class. Identical behavior to the RequiredAttribute class
    /// with the additon that it allows for bypassing validation based on the Http
    /// method of the current Http request.
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class RequiredHttpAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        /// <summary>
        /// Gets or sets the HTTP methods that this attribute will validate on.
        /// </summary>
        /// <remarks>The value is treated as a regular expression pattern, e.g., GET|POST.</remarks>
        public string HttpMethod { get; set; }

        /// <summary>
        /// Validates the specified value with respect to the current validation attribute.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>An instance of the ValidationResult class.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = HttpContext.Current;
            if (context != null && !string.IsNullOrWhiteSpace(this.HttpMethod))
            {
                if (!Regex.IsMatch(context.Request.HttpMethod, this.HttpMethod, RegexOptions.IgnoreCase))
                {
                    return ValidationResult.Success;
                }
            }

            return base.IsValid(value, validationContext);
        }
    }
}