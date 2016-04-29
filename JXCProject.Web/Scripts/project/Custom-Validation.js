
jQuery.validator.addMethod("agerange", function (value, element, params) {

    var minAge = params.minage;
    var maxAge = params.maxage;

    var literalCurrentDate = params.currentdate;
    var literalBirthDate = value;
    var literalCurrentDates = literalCurrentDate.split('-');
    var literalBirthDates = literalBirthDate.split('-');

    var birthDate = new Date(literalBirthDates[2], literalBirthDates[1], literalBirthDates[0]);
    var currentDate = new Date(literalCurrentDates[2], literalCurrentDates[1], literalCurrentDates[0]);
    var age = currentDate.getFullYear() - birthDate.getFullYear();
    return age >= minAge && age <= maxAge
});

jQuery.validator.unobtrusive.adapters.add("agerange", ["currentdate", "minage", "maxage"], function (options) {
    options.rules["agerange"] = {
        currentdate: options.params.currentdate,
        minage: options.params.minage,
        maxage: options.params.maxage
    };
    options.messages["agerange"] = options.message;
});

jQuery.validator.addMethod("mustselected", function (value, element, params) {
    return value != '' && value != '--请选择--';
})

jQuery.validator.unobtrusive.adapters.add("mustselected", function (options) {
    if (options.element.tagName.toUpperCase() == "INPUT") {

        options.rules["mustselected"] = true;
        if (options.message) {
            options.messages["mustselected"] = options.message;
        }
    }
});
