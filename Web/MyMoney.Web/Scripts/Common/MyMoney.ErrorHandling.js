﻿/// <reference path="~/Scripts/jQuery/jquery-3.1.1.js"/>
/// <reference path="~/Scripts/Toastr/toastr.js"/>
/// <reference path="~/Scripts/Common/MyMoney.Common.js" />

$(function() {
    toastr.options.closeButton = true;
    toastr.options.timeOut = 0;
    toastr.options.extendedTimeOut = 0;

    window.showError = function(error) {
        if (typeof (error) == "undefined" ||
            error == null ||
            error.message === "" ||
            typeof (error.message) == "undefined") {
            return;
        }

        var title = myMoney.strings.get("Common", "Error_Title");
        var message = error.message;

        if (typeof (error.title) !== "undefined") {
            title = error.title;
        }

        toastr.error(message, title);
    };
    window.showSuccess = function(msg) {
        if (typeof (msg) == "undefined" || msg == null) {
            return;
        }

        var title = myMoney.strings.get("Common", "Success_Title");

        toastr.success(msg, title);
    };
    window.showInfo = function(info) {
        if (typeof (info) == "undefined" || info == null) {
            return;
        }

        var title = myMoney.strings.get("Common", "Information_Title");
        var message = info;

        toastr.info(message, title);
    };
    window.showWarning = function(warning) {
        if (typeof (warning) == "undefined" || warning == null) {
            return;
        }

        var title = myMoney.strings.get("Common", "Warning_Title");
        var message = warning.message;

        toastr.warning(message, title);
    };
    window.checkResponseFormat = function(response) {
        if (typeof (response) == "undefined" || response == null) {
            console.error("DEV-ERR :: Response object is null.");
            return;
        }

        if (typeof (response.success) == "undefined" || typeof (response.success) !== "boolean") {
            console.error("DEV-ERR :: Success property on response object is either null or non-boolean.");
            return;
        }

        if (!response.success && (typeof (response.errors) == "undefined" || response.errors.length === 0)) {
            console
                .error("DEV-ERR :: Success property on response object is false, but the response contains no errors.");
            return;
        }
    };
});