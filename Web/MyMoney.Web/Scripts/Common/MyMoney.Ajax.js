/// <reference path="~/Scripts/jQuery/jquery-3.1.1.js"/>
/// <reference path="MyMoney.ErrorHandling.js"/>


window.AjaxResponse = function(callback) {
    if (typeof (callback) !== "function") {
        showError("Given callback is not a function.");
    }

    var handler = function(data) {
        if (checkResponseFormat(data)) {

            if (!data.success) {
                showError(data.errors[0]);
                return;
            }

            callback(data);
        }
    };
    return handler;
};