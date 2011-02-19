using DataAnnotationsExtensions.ClientValidation;

[assembly: WebActivator.PreApplicationStartMethod(typeof(DataAnnotationsExtensions.NuGet.AppStart_RegisterClientValidationExtensions), "Start", callAfterGlobalAppStart: true)]
 
namespace DataAnnotationsExtensions.NuGet {
    public static class AppStart_RegisterClientValidationExtensions {
        public static void Start() {
            DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();            
        }
    }
}