using System.Web.Mvc;
using DataAnnotationsExtensions.ClientValidation.Adapters;

namespace DataAnnotationsExtensions.ClientValidation
{
    public static class DataAnnotationsModelValidatorProviderExtensions
    {
        public static void RegisterValidationExtensions()
        {
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(EmailAttribute), typeof(EmailAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(UrlAttribute), typeof(UrlAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(CreditCardAttribute), typeof(CreditCardAttributeAdapter));
        }
    }
}
