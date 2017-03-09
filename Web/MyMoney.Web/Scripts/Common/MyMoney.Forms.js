/// <reference path="~/Scripts/jQuery/jquery-3.1.1.js"/>
/// <reference path="~/Scripts/Common/MyMoney.ErrorHandling.js"/>
/// <reference path="~/Scripts/Common/MyMoney.Ajax.js" />
/// <reference path="~/Scripts/jQuery/jquery.validate.js"/>
/// <reference path="~/Scripts/jQuery/jquery.validate.unobtrusive.js"/>


window.submitForm = function(formId, successCallback, errorCallback) {
    var form = $(formId);

    if (!form.valid()) {
        return;
    }

    if (typeof (form[0]) == "undefined") {
        showError("Failed to find form with identifier " + formId + ".");
        return;
    }

    var url = $(form).attr("action");

    if (typeof (url) == "undefined" || url === "") {
        showError("Element " + formId + " does not have an 'action' attribute.");
        return;
    }

    if (typeof (errorCallback) == "undefined" || errorCallback == null) {
        errorCallback = ajaxFail;
    }

    var managedSuccessCallback = AjaxResponse(successCallback);
    var data = $(form).serialize();

    $.ajax({
        url: url,
        async: true,
        method: $(form).attr("method"),
        data: data,
        success: managedSuccessCallback,
        error: errorCallback
    });
};