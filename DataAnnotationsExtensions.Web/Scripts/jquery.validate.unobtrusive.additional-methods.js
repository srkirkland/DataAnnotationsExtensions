jQuery.validator.unobtrusive.adapters.add("greaterthan", ["other"], function (options) {
//    options.rules["greaterThan"] = "#" + options.params.otherfield;
    //    options.messages["greaterThan"] = options.message;

    // 
    function getModelPrefix(fieldName) {
        return fieldName.substr(0, fieldName.lastIndexOf(".") + 1);
    }

    function appendModelPrefix(value, prefix) {
        if (value.indexOf("*.") === 0) {
            value = value.replace("*.", prefix);
        }
        return value;
    }
    function setValidationValues(options, ruleName, value) {
        options.rules[ruleName] = value;
        if (options.message) {
            options.messages[ruleName] = options.message;
        }
    }

        var prefix = getModelPrefix(options.element.name),
                other = options.params.other,
                fullOtherName = appendModelPrefix(other, prefix),
                element = $(options.form).find(":input[name=" + fullOtherName + "]")[0];

        setValidationValues(options, "greaterThan", element);
});