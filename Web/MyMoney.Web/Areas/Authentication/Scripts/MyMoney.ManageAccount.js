/// <reference path="~/Scripts/jQuery/jquery-3.1.1.js"/>
/// <reference path="~/Scripts/Common/MyMoney.Forms.js"/>
$(function () {
    function saveAccountClick(event) {
        event.stopPropagation();

        submitForm("#edit-account-form", saveAccountDetailsSuccessCallback);
    }

    function savePersonalClick(event) {
        event.stopPropagation();
        submitForm("#edit-personal-form", savePersonalDetailsSuccessCallback);
    }

    function saveAccountDetailsSuccessCallback(data) {
        
    }

    function savePersonalDetailsSuccessCallback(data) {
        
    }

    $(function() {
        $("#save-account").click(saveAccountClick);
        $("#save-personal").click(savePersonalClick);
    });
})