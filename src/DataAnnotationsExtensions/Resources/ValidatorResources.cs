using System;

namespace DataAnnotationsExtensions.Resources
{
    public static class ValidatorResources
    {
        public static string Common_ModelBinderDoesNotSupportModelType = "This model binder does not support the model type '{0}'.";
        public static string Common_NullOrEmpty = "Value cannot be null or empty.";
        public static string ControllerBuilder_FactoryReturnedNull = "The IControllerFactory '{0}' did not return a controller for a controller named '{1}'.";
        public static string ExpressionHelper_CannotRouteToController = "Cannot route to class named 'Controller'.";
        public static string ExpressionHelper_MustBeMethodCall = "Expression must be a method call.";
        public static string ExpressionHelper_TargetMustEndInController = "Controller name must end in 'Controller'.";
        public static string HtmlHelper_MissingSelectData = "There is no ViewData item with the key '{0}' of type '{1}'.";
        public static string HtmlHelper_WrongSelectDataType = "The ViewData item with the key '{0}' is of type '{1}' but needs to be of type '{2}'.";
        public static string CommonControls_NameRequired = "The 'Name' property must be set.";
        public static string MvcSerializer_DeserializationFailed = "Deserialization failed.Verify that the data is being deserialized using the same SerializationMode with which it was serialized.Otherwise see the inner exception.";
        public static string MvcSerializer_InvalidSerializationMode = "The provided SerializationMode is invalid.<";
        public static string Resources_UnsupportedMediaType = "Unsupported Media Type: '{0}'.";
        public static string Resources_UnsupportedFormat = "Format '{0}' is not supported.";
        public static string MvcDynamicSessionModule_WrongControllerFactory = "The ControllerBuilder must return an IControllerFactory of type { 0} if the MvcDynamicSessionModule is enabled.";
        public static string ExpressionHelper_CannotCallCompletedMethod = "The method '{0}' is an asynchronous completion method and cannot be called directly.";
        public static string ExpressionHelper_CannotCallNonAction = "The method '{0}' is marked[NonAction] and cannot be called directly.";
        public static string ModelBinderUtil_ModelCannotBeNull = "The binding context has a null Model, but this binder requires a non-null model of type '{0}'.";
        public static string ModelBinderUtil_ModelInstanceIsWrong = "The binding context has a Model of type '{0}', but this binder can only operate on models of type '{1}'.";
        public static string ModelBinderUtil_ModelMetadataCannotBeNull = "The binding context cannot have a null ModelMetadata.";
        public static string ModelBinderUtil_ModelTypeIsWrong = "The binding context has a ModelType of '{0}', but this binder can only operate on models of type '{1}'.";
        public static string ModelBinderConfig_ValueInvalid = "The value '{0}' is not valid for { 1}.";
        public static string ModelBinderConfig_ValueRequired = "A value is required.";
        public static string ModelBinderProviderCollection_BinderForTypeNotFound = "A binder for type {0} could not be located.";
        public static string ModelBindingContext_ModelMetadataMustBeSet = "The ModelMetadata property must be set before accessing this property.";
        public static string Common_TypeMustImplementInterface = "The type '{0}' does not implement the interface '{1}'.";
        public static string GenericModelBinderProvider_ParameterMustSpecifyOpenGenericType = "The type '{0}' is not an open generic type.";
        public static string GenericModelBinderProvider_TypeArgumentCountMismatch = "The open model type '{0}' has {1} generic type argument(s), but the open binder type '{2}' has {3} generic type argument(s). The binder type must not be an open generic type or must have the same number of generic arguments as the open model type.";
        public static string BindingBehavior_ValueNotFound = "A value for '{0}' is required but was not present in the request.";
        public static string ExtensibleModelBinderAdapter_PropertyFilterMustNotBeSet = "The new model binding system cannot be used when a property whitelist or blacklist has been specified in [Bind] or via the call to UpdateModel() / TryUpdateModel(). Use the[BindRequired] and[BindNever] attributes on the model type or its properties instead.";
        public static string ModelBinderProviderCollection_TypeCannotHaveBindAttribute = "The model of type '{0}' has a [Bind] attribute.The new model binding system cannot be used with models that have type-level[Bind] attributes.Use the[BindRequired] and [BindNever] attributes on the model type or its properties instead.";
        public static string ModelBinderProviderCollection_InvalidBinderType = "The type '{0}' does not subclass {1} or implement the interface {2}.";
        public static string ChildActionCacheAttribute_DurationMustBePositive = "The 'Duration' property must be a positive number.";
        public static string DynamicViewDataDictionary_SingleIndexerOnly = "DynamicViewDataDictionary only supports single indexers.";
        public static string DynamicViewDataDictionary_StringIndexerOnly = "DynamicViewDataDictionary only supports string-based indexers.";
        public static string DynamicViewPage_NoProperties = "The property {0} doesn't exist. There are no public properties on this object.";
        public static string DynamicViewPage_PropertyDoesNotExist = "The property {0} doesn't exist. Supported properties are: {1}.";
        public static string DropDownList_SampleItem = "Sample Item";
        public static string ResourceControllerFactory_ConflictingActions = "Error dispatching on controller { 0}, conflicting actions matched: {1}.";
        public static string ResourceControllerFactory_NoActions = "Error dispatching on controller {0}, no actions matched.";
        public static string FileExtensionsAttribute_Invalid = "The {0} field only accepts files with the following extensions: {1}";
        public static string CreditCardAttribute_Invalid = "The {0} field is not a valid credit card number.";
        public static string EmailAddressAttribute_Invalid = "The {0} field is not a valid e-mail address.";
        public static string UrlAttribute_Invalid = "The {0} field is not a valid fully-qualified http, https, or ftp URL.";
        public static string MvcSerializer_MagicHeaderCheckFailed = "The data being serialized is corrupt.";
        public static string DataAnnotationsModelMetadataProvider_UnknownProperty = "{0} has a DisplayColumn attribute for {1}, but property {1} does not exist.";
        public static string DataAnnotationsModelMetadataProvider_UnreadableProperty = "{0} has a DisplayColumn attribute for {1}, but property {1} does not have a public getter.";
        public static string Common_PropertyNotFound = "The property {0}.{1} could not be found.";
        public static string CompareAttribute_MustMatch = "'{0}' and '{1}' do not match.";
        public static string EqualTo_UnknownProperty = "Could not find a property named {0}.";
        public static string NumericAttribute_Invalid = "The {0} field is not a valid number.";
        public static string DigitsAttribute_Invalid = "The field {0} should contain only digits";
        public static string MaxAttribute_Invalid = "The field {0} must be less than or equal to {1}";
        public static string MinAttribute_Invalid = "The field {0} must be greater than or equal to {1}";
        public static string DateAttribute_Invalid = "The field {0} is not a valid date";
        public static string IntegerAttribute_Invalid = "The field {0} should be a positive or negative non-decimal number.";
        public static string CuitAttribute_Invalid = "The {0} field is not a valid CUIT number.";
        public static string YearAttribute_Invalid = "The {0} field is not a valid year";
        public static string UrlAttributeProtocolOptional_Invalid = "The {0} field is not a valid URL.";
        public static string UrlAttributeWithoutProtocol_Invalid = "The {0} field is not a valid protocol-less URL.";
    }
}
