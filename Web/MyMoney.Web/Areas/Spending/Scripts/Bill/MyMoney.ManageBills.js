/// <reference path="~/Scripts/jQuery/jquery-3.1.1.js"/>
/// <reference path="~/Scripts/Semantic/semantic.js"/>
/// <reference path="~/Scripts/Common/MyMoney.ErrorHandling.js"/>
/// <reference path="~/Scripts/Common/MyMoney.Forms.js"/>
/// <reference path="~/Areas/Spending/Scripts/Bill/MyMoney.Bill.js" />
/// <reference path="~/Scripts/jQuery/jquery.tablesorter.js"/>
/// <reference path="~/Scripts/Chartist/chartist.js" />
/// <reference path="~/Scripts/Common/MyMoney.Charts.js" />
/// <reference path="~/Scripts/Extensions/MyMoney.StringExtensions.js"/>
/// <reference path="~/Scripts/Common/MyMoney.Localization.js"/>
/// <reference path="~/Scripts/Semantic/calendar.js"/>

function addBillSuccessCallback(data) {
    if (data.success) {
        var successMsg = myMoney.strings.get("Bills", "Message_RecordedBill");
        var bill = new BillModel(data.model);

        showSuccess(successMsg);
        $("#add-bill-form")[0].reset();

        var table = $("#bill-table");

        var row = bill.createTableRow(viewBillClick);

        table.find("tbody").append(row);
        row.addClass("positive");

        setTimeout(function() {
                row.removeClass("positive");
            },
            5000);

        $("#bill-table").find("#table-warning").remove();
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

            var row = bill.createTableRow(viewBillClick);

            table.find(".selected").replaceWith(row);
            row.addClass("warning");

            setTimeout(function() {
                    row.removeClass("warning");
                },
                5000);
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

var chartFailed = false;

function createBillCategoryChart(data) {
    if ((data.length <= 1 && !chartFailed) || chartFailed) {
        chartFailed = true;
        var text = myMoney.strings.get("Common", "Error_NoDataForChart");
        $("#chart-loading-text").text(text);
        $("#chart-loading-text").closest(".segment").css("height", "230px");
        $("#chart-loading-text").addClass("no-pseudo");
        $("#period-chart").remove();
        $("#category-chart").remove();
        return;
    }

    var chartGenerator = new ChartGenerator(data);
    chartGenerator.createBillCategoryChart("#category-chart");

    $("#category-chart").siblings(".dimmer").addClass("disabled").removeClass("active");
}

function createBillPeriodChart(data) {
    if ((data.length <= 1 && !chartFailed) || chartFailed) {
        chartFailed = true;
        var text = myMoney.strings.get("Common", "Error_NoDataForChart");
        $("#chart-loading-text").text(text);
        $("#chart-loading-text").closest(".segment").css("height", "230px");
        $("#chart-loading-text").addClass("no-pseudo");
        $("#period-chart").remove();
        $("#category-chart").remove();
        return;
    }

    var chartGenerator = new ChartGenerator(data);
    chartGenerator.createBillPeriodChart("#period-chart");

    $("#period-chart").siblings(".dimmer").addClass("disabled").removeClass("active");
}

function addBillsToCalendar(data) {
    var calendarItems = $("#bill-calendar").find(".link");
    var dateElems = [];
    var date = new Date();
    var day = 1;

    $(".calendar").removeAttr("tabindex");

    $(calendarItems)
        .each(function(i, elem) {
            if ($(elem).hasClass("disabled") || $(elem).is("span")) {
                return;
            }

            var elemDate = new Date(date.getFullYear(), date.getMonth(), day);
            day++;

            var elemObj = {
                "element": elem,
                "date": elemDate
            };

            dateElems.push(elemObj);
        });

    for (var b = 0; b < data.length; b++) {
        var bill = data[b];

        for (var d = 0; d < dateElems.length; d++) {
            var dateElem = dateElems[d];

            var billDay = new Date(bill.StartDate).getTime();
            var calendarDay = dateElem.date.getTime();

            $(dateElem.element).off("click");

            if (billDay === calendarDay) {
                $(dateElem.element).addClass("negative");
                break;
            }
        }
    }

    $("#bill-calendar")
        .children()
        .unbind("mousedown")
        .unbind("mouseup")
        .unbind("touchstart")
        .unbind("touchend")
        .unbind("keydown");

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
                var value = model[prop];

                $(elem).val(value);
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

        var table = $("#bill-table");

        if (table.find("tbody").find("tr").length === 0) {
            var row = $("<tr>").attr("id", "table-warning");
            var cellText = myMoney.strings.get("Bills", "Warning_NoBills");
            var cell = $("<td>").attr("colspan", 5).text(cellText);

            table.append(row.append(cell));
        }
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

var date = new Date();
var firstDay = new Date(date.getFullYear(), date.getMonth(), 1);
var lastDay = new Date(date.getFullYear(), date.getMonth() + 1, 0);

$("#bill-calendar")
    .calendar({
        type: "date",
        inline: true,
        disableYear: true,
        disableMinute: true,
        disableMonth: true,
        minDate: firstDay,
        maxDate: lastDay
    });

$("tr[data-get]").click(viewBillClick);