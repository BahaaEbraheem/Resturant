(function () {
    var _$form = $('#RegisterForm');

    $.validator.addMethod("customUsername", function (value, element) {
        if (value === _$form.find('input[name="EmailAddress"]').val()) {
            return true;
        }

        //Username can not be an email address (except the email address entered)
        return !$.validator.methods.email.apply(this, arguments);
    }, abp.localization.localize("RegisterFormUserNameInvalidMessage", "Resturant"));

    _$form.validate({
        rules: {
            UserName: {
                required: true,
                customUsername: true
            }
        }
    });
})();

//$(document).ready(function () {
//    debugger
//    $("#RegisterForm").validate({
//        rules: {
//            Name: "required"
//        },
//        messages: {
//            Name: "Please specify your name"

//        }
//    })

//    $('#btn').click(function () {
//        $("#form1").validate();  // This is not working and is not validating the form
//    });

//});