using DataAnnotationsExtensions.ClientValidation;

[assembly: WebActivator.PreApplicationStartMethod(typeof($rootnamespace$.App_Start.RegisterClientValidationExtensions), "Start", callAfterGlobalAppStart: true)]
 
namespace $rootnamespace$.App_Start {
    public static class RegisterClientValidationExtensions {
        public static void Start() {
            DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();            
        }
    }
}