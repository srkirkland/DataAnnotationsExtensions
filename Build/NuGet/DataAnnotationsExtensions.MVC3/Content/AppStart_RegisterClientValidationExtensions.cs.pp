using DataAnnotationsExtensions.ClientValidation;

[assembly: WebActivator.PreApplicationStartMethod(typeof($rootnamespace$.AppStart_RegisterClientValidationExtensions), "Start", callAfterGlobalAppStart: true)]
 
namespace $rootnamespace$ {
    public static class AppStart_RegisterClientValidationExtensions {
        public static void Start() {
            DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();            
        }
    }
}