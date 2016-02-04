using DataAnnotationsExtensions.ClientValidation;
using DataAnnotationsExtensions.Web;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(AppStart_RegisterClientValidationExtensions), "Start")]

namespace DataAnnotationsExtensions.Web
{
    public static class AppStart_RegisterClientValidationExtensions
    {
        public static void Start()
        {
            DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();
        }
    }
}