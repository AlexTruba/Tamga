//Custom validator
jQuery.validator.unobtrusive.adapters.add(
    'requiredif', ['other'], function (options) {

        var getModelPrefix = function (fieldName) {
            return fieldName.substr(0, fieldName.lastIndexOf('.') + 1);
        }

        var appendModelPrefix = function (value, prefix) {
            if (value.indexOf('*.') === 0) {
                value = value.replace('*.', prefix);
            }
            return value;
        }

        var prefix = getModelPrefix(options.element.name),
            other = options.params.other,
            fullOtherName = appendModelPrefix(other, prefix),
            element = $(options.form).find(':input[name="' + fullOtherName + '"]')[0];

        options.rules['requiredif'] = element;
        if (options.message) {
            options.messages['requiredif'] = options.message;
        }
    }
);

jQuery.validator.addMethod('requiredif', function (value, element, params) {
    var otherValue = $(params).prop("checked");
    if (otherValue) {
        return !(value == null || value == "");
    }
    return true;
}, '');



$(document).ready(function () {
    $(document).on('click', '.inline-checkbox input', function () {
        var hideEl = $(this).parents(".user-form").find(".change-visible");
        hideEl.toggleClass("hide");
        hideEl.find("input").val("");
    });    
});
function save() {
    var form = $(".user-form");
    var isValid = true;
    for (var i = 0; i < form.length; i++) {
        var item = $(form[i]);
        $.validator.unobtrusive.parse(item);
        if (!item.valid()) {
            isValid = false;
            break;
        }
    }
   
    if (isValid) {
        var data = getFormData();
        saveAjax(data);
    }
}
function saveAjax(value) {
    $.ajax({
        url: '/Home/Save',
        type: 'POST',
        data: JSON.stringify(value),
        contentType: 'application/json; charset=utf-8',
        success: function () {
            alert("Success save");
        }
    });
}
function getFormData() {
    var form = $(".user-form");
    var dataArray = [];
    for (var i = 0; i < form.length; i++) {
        var user = {};
        var inputs = $(form[i]).find("input[type!='checkbox']");
        for (var j = 0; j < inputs.length; j++) {
            user[inputs[j].name] = inputs[j].value == "" ? null : inputs[j].value;
        }
        var inputsCheckbox = $(form[i]).find("input[type='checkbox']");
        for (var j = 0; j < inputsCheckbox.length; j++) {
            user[inputsCheckbox[j].name] = inputsCheckbox[j].checked;
        }
        dataArray.push(user);
    }
    return dataArray;
}

function showAddBlock() {
    LoadForm();
}

function LoadForm() {
    var formGroup = $('.add-user-form');
    $.ajax({
        url: '/Home/GetUserForm',
        type: 'GET',
        dataType: 'html',
        success: function (result) {
            formGroup.append(result);
        }
    });
}

