/// <reference path="~/Scripts/jQuery/jquery-3.1.1.js"/>
/// <reference path="MyMoney.ErrorHandling.js"/>

$(function() {
    window.AjaxResponse = function(callback) {
        if (typeof (callback) !== "function") {
            console.error("DEV-ERR :: Given callback is not a function.");
        }

        var handler = function(data) {
            checkResponseFormat(data);

            if (!data.success) {
                showError(data.errors[0]);
                return;
            }

            callback(data);
        };
        return handler;
    };
});