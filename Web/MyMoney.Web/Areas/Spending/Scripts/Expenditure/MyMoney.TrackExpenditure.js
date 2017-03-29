/// <reference path="~/Scripts/jQuery/jquery-3.1.1.js"/>
/// <reference path="~/Scripts/Semantic/calendar.js"/>
/// <reference path="~/Scripts/Chartist/chartist.js" />
/// <reference path="~/Scripts/Moment/moment.js" />
/// <reference path="~/Scripts/Extensions/MyMoney.NumberExtensions.js"/>
/// <reference path="~/Scripts/Semantic/semantic.js" />
/// <reference path="~/Scripts/Common/MyMoney.Forms.js" />
/// <reference path="~/Areas/Spending/Scripts/Expenditure/MyMoney.Expenditure.js" />
/// <reference path="~/Scripts/Extensions/MyMoney.StringExtensions.js" />
/// <reference path="~/Scripts/Common/MyMoney.Charts.js" />
$(function () {
    function loadAjaxComponents() {
        loadCalendarData("#expenditure-calendar");
        createChart("#expenditure-chart");
    }

    function loadCalendarDataCallback(data) {
        if (data.success) {
            var calendarCells = $(".link");
            var monthCells = [];

            $(calendarCells)
                .each(function (i, elem) {
                    elem = $(elem);

                    if (elem.hasClass("disabled") || elem.hasClass("adjacent") || elem.is("span")) {
                        return;
                    }

                    monthCells.push({
                        element: elem,
                        date: parseInt($(elem).text())
                    });
                });

            var dateAmounts = [];

            for (var j = 0; j < data.model.length; j++) {
                var model = new ExpenditureModel(data.model[j]);
                var found = false;

                for (var l = 0; l < dateAmounts.length; l++) {
                    if (dateAmounts[l].date.getTime() === model.dateOccurred.getTime()) {
                        dateAmounts[l].amount += model.amount;
                        found = true;
                        continue;
                    }
                }

                if (dateAmounts.length === 0 || !found) {
                    dateAmounts.push({
                        date: model.dateOccurred,
                        amount: model.amount
                    });
                    continue;
                }
            }

            for (var k = 0; k < dateAmounts.length; k++) {
                var dateAmount = dateAmounts[k];

                for (var m = 0; m < monthCells.length; m++) {
                    var cell = monthCells[m];

                    if (cell.date === dateAmount.date.getDate()) {
                        cell.element.addClass("negative").text(dateAmount.amount.asCurrency());
                    }
                }
            }
        }
    }

    function loadCalendarData(selector) {
        var calendar = $(selector);
        var url = calendar.data("url");
        var callback = AjaxResponse(loadCalendarDataCallback);
        var date = new Date();
        var firstDay = new Date(date.getFullYear(), date.getMonth(), 1);
        var lastDay = new Date(date.getFullYear(), date.getMonth() + 1, 0);

        $(selector).empty();
        $(selector)
            .calendar({
                type: "date",
                inline: true,
                disableYear: true,
                disableMinute: true,
                disableMonth: true,
                minDate: firstDay,
                maxDate: lastDay
            });

        $(selector)
            .children()
            .unbind("mousedown")
            .unbind("mouseup")
            .unbind("touchstart")
            .unbind("touchend")
            .unbind("keydown");

        $.ajax(url,
            {
                method: "GET",
                async: true,
                dataType: "json",
                success: callback,
                error: ajaxFail
            });


    }

    function createChart(selector) {
        var container = $(selector);

        var url = container.data("url");
        var callback = AjaxResponse(getExpenditureChartDataCallback);

        $.ajax(url,
            {
                method: "GET",
                async: true,
                dataType: "json",
                success: callback,
                error: ajaxFail
            });
    }

    function getExpenditureChartDataCallback(data) {
        if (data.success) {
            var generator = new ChartGenerator(data.model);

            generator.createExpenditureChart("#expenditure-chart");
        }
    }

    function showAddModal(event) {
        event.stopPropagation();

        $("#add-expenditure-modal").modal("show");
    }

    function showEditModal(event) {
        event.stopPropagation();

        var url = $(this).data("get");
        $(this).addClass("selected");

        var callback = AjaxResponse(getExpenditureCallback);

        $.ajax(url,
            {
                method: "GET",
                async: true,
                dataType: "json",
                success: callback,
                error: ajaxFail
            });
    }

    function getExpenditureCallback(data) {
        var model = new ExpenditureModel(data.model);

        var modal = $("#edit-expenditure-modal");
        var inputs = $(modal).find("input");

        $(inputs)
            .each(function (i, elem) {
                var prop = elem.id.replace("#", "").toCamelCase();

                if ($(elem).attr("type") === "date") {
                    elem.valueAsDate = model[prop];
                } else {
                    var value = model[prop];

                    $(elem).val(value);
                }
            });

        $("#edit-expenditure-modal").modal("show");
    }

    function addExpenditureClick(event) {
        event.stopPropagation();

        submitForm("#add-expenditure-form", addExpenditureSuccessCallback);
    }

    function addExpenditureSuccessCallback(data) {
        if (data.success) {
            var successMsg = myMoney.strings.get("Expenditure", "Message_RecordedExpenditure");
            var exp = new ExpenditureModel(data.model);

            showSuccess(successMsg);
            $("#add-expenditure-form")[0].reset();

            var table = $("#expenditure-table");

            var row = exp.createTableRow(showEditModal);

            table.find("tbody").append(row);
            row.addClass("positive");

            setTimeout(function () {
                row.removeClass("positive");
            },
                5000);

            $("#expenditure-table").find("#table-warning").remove();
        }

        $("#add-expenditure-modal").modal("hide");
        loadAjaxComponents();
    }


    function editExpenditureClick(event) {
        event.stopPropagation();

        submitForm("#edit-expenditure-form", editExpenditureSuccessCallback);
    }

    function editExpenditureSuccessCallback(data) {
        if (data.success) {
            var successMsg = myMoney.strings.get("Expenditure", "Message_UpdatedExpenditure");
            var expenditure = new ExpenditureModel(data.model);

            if (typeof (expenditure.id) !== "undefined") {
                showSuccess(successMsg);
                $("#edit-expenditure-form")[0].reset();

                var table = $("#expenditure-table");

                var row = expenditure.createTableRow(showEditModal);

                table.find(".selected").replaceWith(row);
                row.addClass("warning");

                setTimeout(function () {
                    row.removeClass("warning");
                },
                    5000);
            }

        }

        $("#edit-expenditure-modal").modal("hide");
        loadAjaxComponents();
    }

    function deleteExpenditureClick(event) {
        event.stopPropagation();

        var confirmText = myMoney.strings.get("Common", "Button_Confirm");

        var icon = $(this).find("i");

        $(this).text(confirmText);
        $(this).append(icon);

        $(this).off("click");
        $(this).click(confirmDeleteExpenditureClick);
    }

    function confirmDeleteExpenditureClick(event) {
        event.stopPropagation();

        var url = $("tr.selected").data("delete");

        var callback = AjaxResponse(deleteExpenditureSuccessCallback);

        $.ajax(url,
            {
                method: "GET",
                async: true,
                dataType: "json",
                success: callback,
                error: ajaxFail
            });
    }

    function deleteExpenditureSuccessCallback(data) {
        if (data.success) {
            var successMsg = myMoney.strings.get("Expenditure", "Message_DeleteExpenditure");

            showSuccess(successMsg);
            $("tr.selected").remove();

            var table = $("#expenditure-table");

            if (table.find("tbody").find("tr").length === 0) {
                var row = $("<tr>").attr("id", "table-warning");
                var cellText = myMoney.strings.get("Expenditure", "Warning_NoExpenditure");
                var cell = $("<td>").attr("colspan", 5).text(cellText);

                table.append(row.append(cell));
            }
        }

        $("#edit-expenditure-modal").modal("hide");

        var btnText = myMoney.strings.get("Common", "Button_Delete");

        var btn = $("#delete-expenditure");
        var icon = $(btn).find("i");

        $(btn).text(btnText);
        $(btn).append(icon);
        $(btn).off("click");
        $(btn).click(deleteExpenditureClick);

        loadAjaxComponents();
    }

    $(function () {
        loadCalendarData("#expenditure-calendar");
        createChart("#expenditure-chart");

        $("#add-expenditure").click(addExpenditureClick);
        $("#add").click(showAddModal);
        $("#edit-expenditure").click(editExpenditureClick);
        $("#delete-expenditure").click(deleteExpenditureClick);

        $("tr[data-get]").click(showEditModal);
    });
});