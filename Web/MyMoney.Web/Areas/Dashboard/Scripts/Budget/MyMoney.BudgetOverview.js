/// <reference path="~/Scripts/jQuery/jquery-3.1.1.js"/>
/// <reference path="~/Scripts/Chartist/chartist.js"/>
/// <reference path="~/Scripts/Common/MyMoney.ErrorHandling.js" />
/// <reference path="~/Scripts/Common/MyMoney.Ajax.js"/>
/// <reference path="~/Scripts/Common/MyMoney.Initialize.js" />

var url = $("#spending-chart-endpoint").val();
var callback = AjaxResponse(generateChart);

$.ajax(url,
{
    method: "GET",
    async: true,
    dataType: "json",
    success: callback,
    error: function() {
        var errMsg = myMoney.strings.get("Spending", "Error_FailedToLoadSpendingChart");

        var error = {
            message: errMsg
        };
        showError(error);
    }
});

function generateChart(data) {
    var model = data.model;

    Chartist.Line("#spending-chart",
    {
        labels: model.labels,
        series: model.series,
        fullWidth: true,
        chartPadding: {
            right: 10,
            left: 10,
            top: 10,
            bottom: 10
        }
    });
}