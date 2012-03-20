jQuery.validator.addMethod("greaterThan", function (value, element, param) {
    var target = $(param).unbind(".validate-greaterThan").bind("change.validate-greaterThan", function () {
            $(element).valid();
        });
    return (Date.parse(value) || parseFloat(value)) > (Date.parse($(param).val()) || parseFloat($(param).val()));
});