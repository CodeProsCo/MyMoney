/// <reference path="~/Scripts/jQuery/jquery-3.1.1.js"/>
/// <reference path="~/Scripts/Semantic/semantic.js"/>
/// <reference path="~/Scripts/Common/MyMoney.ErrorHandling.js"/>
/// <reference path="~/Scripts/Common/MyMoney.Forms.js"/>
/// <reference path="~/Areas/Spending/Scripts/Bill/MyMoney.Bill.js" />
/// <reference path="~/Scripts/jQuery/jquery.tablesorter.js"/>
/// <reference path="~/Scripts/Chartist/chartist.js" />
/// <reference path="~/Scripts/Common/MyMoney.Charts.js" />
/// <reference path="~/Scripts/Extensions/MyMoney.StringExtensions.js"/>

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

function editBillSuccessCallback(data) {
    if (data.success) {
        var successMsg = myMoney.strings.get("Bills", "Message_UpdatedBill");
        var bill = new BillModel(data.model);

        if (typeof (bill.id) !== "undefined") {
            showSuccess(successMsg);
            $("#edit-bill-form")[0].reset();

            var table = $("#bill-table");

            var row = bill.createTableRow();

            table.find("[data-get=" + bill.id + "]").remove();
            table.find("tbody").append(row);
        }

    }

    $("#edit-bill-modal").modal("hide");
}

function addBillClick(event) {
    event.stopPropagation();

    submitForm("#add-bill-form", addBillSuccessCallback);
}

function editBillClick(event) {
    event.stopPropagation();

    submitForm("#edit-bill-form", editBillSuccessCallback);
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

function viewBillClick(event) {
    event.stopPropagation();

    var url = $(this).data("get");
    $(this).addClass("selected");

    var callback = AjaxResponse(getBillCallback);

    $.ajax(url,
    {
        method: "GET",
        async: false,
        dataType: "json",
        success: callback
    });
}

function getBillCallback(data) {
    var model = new BillModel(data.model);

    var modal = $("#edit-bill-modal");
    var inputs = $(modal).find("input");

    $(inputs)
        .each(function(i, elem) {
            var prop = elem.id.replace("#", "").toCamelCase();

            if ($(elem).attr("type") === "date") {
                elem.valueAsDate = model[prop];
            } else {
                $(elem).val(model[prop]);
            }
        });

    $("#edit-bill-modal").modal("show");
}

function deleteBillClick(event) {
    event.stopPropagation();

    var confirmText = myMoney.strings.get("Common", "Button_Confirm");

    var icon = $(this).find("i");

    $(this).text(confirmText);
    $(this).append(icon);

    $(this).off("click");
    $(this).click(confirmDeleteBillClick);
}

function confirmDeleteBillClick(event) {
    event.stopPropagation();

    var url = $("tr.selected").data("delete");

    var callback = AjaxResponse(deleteBillCallback);

    $.ajax(url,
    {
        method: "GET",
        async: false,
        dataType: "json",
        success: callback
    });
}

function deleteBillCallback(data) {
    if (data.success) {
        var successMsg = myMoney.strings.get("Bills", "Message_DeleteBill");

        showSuccess(successMsg);
        $("tr.selected").remove();
    }

    $("#edit-bill-modal").modal("hide");

    var btnText = myMoney.strings.get("Bills", "Button_DeleteBill");

    var btn = $("#delete-bill");
    var icon = $(btn).find("i");

    $(btn).text(btnText);
    $(btn).append(icon);
    $(btn).off("click");
    $(btn).click(deleteBillClick);
}

function cancelClick(event) {
    $("tr").removeClass("selected");
}

$("#add").click(showAddModal);
$("#add-bill").click(addBillClick);
$("#edit-bill").click(editBillClick);
$("#delete-bill").click(deleteBillClick);
$("#cancel").click(cancelClick);
$("tr[data-get]").click(viewBillClick);