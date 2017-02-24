/// <reference path="~/Scripts/jQuery/jquery-3.1.1.js"/>
/// <reference path="~/Scripts/Semantic/semantic.js"/>
/// <reference path="~/Scripts/Common/MyMoney.ErrorHandling.js"/>
/// <reference path="~/Scripts/Common/MyMoney.Forms.js"/>
/// <reference path="~/Areas/Spending/Scripts/Bill/MyMoney.Bill.js" />
/// <reference path="~/Scripts/jQuery/jquery.tablesorter.js"/>
/// <reference path="~/Scripts/Chartist/chartist.js" />
/// <reference path="~/Scripts/Common/MyMoney.Charts.js" />
function addBillSuccessCallback(data) {
    if (data.success) {
        var successMsg = myMoney.strings.get("Bills", "Message_RecordedBill");
        var bill = new BillModel(data.model);

        showSuccess(successMsg);
        $("#add-bill-form")[0].reset();

        var table = $("#bill-table");

        var row = bill.createTableRow();

        table.find("tbody").append(row);
    }

    $("#add-bill-modal").modal("hide");
}

function addBillClick(event) {
    event.stopPropagation();

    submitForm("#add-bill-form", addBillSuccessCallback);
}

function showAddModal(event) {
    event.stopPropagation();

    $("#add-bill-modal").modal("show");
}

function createBillCategoryChart(data) {
    var chartGenerator = new ChartGenerator(data);
    chartGenerator.createBillCategoryChart("#category-chart");

    $("#category-chart").siblings(".dimmer").addClass("disabled").removeClass("active");
}

function createBillPeriodChart(data) {
    var chartGenerator = new ChartGenerator(data);
    chartGenerator.createBillPeriodChart("#period-chart");

    $("#period-chart").siblings(".dimmer").addClass("disabled").removeClass("active");
}

$("#add").click(showAddModal);
$("#add-bill").click(addBillClick);