/// <reference path="~/Scripts/jQuery/jquery-3.1.1.js"/>
/// <reference path="~/Scripts/Common/MyMoney.ErrorHandling.js"/>
/// <reference path="~/Scripts/Common/MyMoney.Ajax.js" />
$(function() {
    window.submitForm = function(formId, successCallback, errorCallback) {
        var error = { message: "" };
        var form = $(formId);

        if (!form.valid()) {
            return;
        }

        if (typeof (form[0]) == "undefined") {
            console.error("DEV-ERR :: Failed to find form with identifier " + formId + ".");
            return;
        }

        var url = $(form).attr("action");

        if (typeof (url) == "undefined" || url === "") {
            console.error("DEV-ERR :: Element " + formId + " does not have an 'action' attribute.");
            return;
        }

        if (typeof (errorCallback) == "undefined" || errorCallback == null) {
            errorCallback = function() {
                var errMsg = myMoney.strings.get("Common", "Error_FailedToPerformAction");

                error.message = errMsg;
                showError(error);
            };
        }

        var managedSuccessCallback = AjaxResponse(successCallback);

        $.ajax({
            url: url,
            async: true,
            method: $(form).attr("method"),
            data: $(form).serialize(),
            success: managedSuccessCallback,
            error: errorCallback
        });
    };
});