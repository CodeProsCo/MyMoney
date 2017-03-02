/// <reference path="~/Scripts/jQuery/jquery-3.1.1.js"/>
/// <reference path="~/Scripts/Toastr/toastr.js"/>
/// <reference path="~/Scripts/Common/MyMoney.Initialize.js" />

toastr.options.closeButton = true;
toastr.options.timeOut = 60000;
toastr.options.extendedTimeOut = 120000;
toastr.options.closeButton = true;
toastr.options.tapToDismiss = false;

window.showError = function(error) {
    var message = "";

    if (typeof (error) === "string") {
        message = error;
    }

    if (typeof (error) === "object") {
        message = error.message;
    }

    var title = myMoney.strings.get("Common", "Error_Title");

    if (typeof (error.title) !== "undefined") {
        title = error.title;
    }

    var reportButtonText = myMoney.strings.get("Common", "Button_Report");
    var buttonContainer = $("<div>").addClass("error-button-container");
    var reportButton =
        $("<button>").addClass("ui").addClass("button").prop("id", "report-error").text(reportButtonText);

    buttonContainer.append(reportButton);

    toastr.error(message + buttonContainer.prop("outerHTML"), title);
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
        showError("Failed to perform action, response object is null.");
        return false;
    }

    if (typeof (response.success) == "undefined" || typeof (response.success) !== "boolean") {
        showError("Failed to perform action, success property on response object is either null or non-boolean.");
        return false;
    }

    if (!response.success && (typeof (response.errors) == "undefined" || response.errors.length === 0)) {
        showError("Failed to perform action, success property on response object is false, but the response contains no errors.");
        return false;
    }

    return true;
};