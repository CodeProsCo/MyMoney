/// <reference path="~/Scripts/jQuery/jquery-3.1.1.js"/>
/// <reference path="~/Scripts/Semantic/calendar.js"/>
/// <reference path="~/Scripts/Chartist/chartist.js" />
/// <reference path="~/Scripts/Moment/moment.js" />
/// <reference path="~/Scripts/Extensions/MyMoney.NumberExtensions.js"/>
/// <reference path="~/Scripts/Semantic/semantic.js" />
/// <reference path="~/Scripts/Common/MyMoney.Forms.js" />
/// <reference path="~/Areas/Spending/Scripts/Expenditure/MyMoney.Expenditure.js" />
$(function() {
    function loadCalendarData(selector) {
        var calendar = $(selector);
        var url = calendar.data("url");
        //var callback = AjaxResponse(loadCalendarDataCallback);
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

        //$.ajax(url,
        //{
        //	method: "GET",
        //	async: true,
        //	dataType: "json",
        //	success: callback,
        //	error: ajaxFail
        //});

        var chart = new Chartist.Line("#expenditure-chart",
        {
            series: [
                {
                    data: [
                        {
                            x: 1461862387541,
                            y: 23.55

                        },
                        {
                            x: 9961862447991,
                            y: 25.55

                        }
                    ]
                }
            ],
            fullWidth: true        },
        {
            axisX: {
                type: Chartist.FixedScaleAxis,
                divisor: 10,
                labelInterpolationFnc: function(value) {
                    return moment(value).format("dd-MM");
                }
            },
            axisY : {
                labelInterpolationFnc: function(value) {
                    return value.asCurrency();
                }
            },
            lineSmooth: Chartist.Interpolation.cardinal({
                fillHoles: true
            }),
            low: 0,
            height: 300
        });
    }

    function showAddModal(event) {
        event.stopPropagation();

        $("#add-expenditure-modal").modal("show");
    }

    function showEditModal(event) {
        event.stopPropagation();

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

    $(function() {
        loadCalendarData("#expenditure-calendar");

        $("#add-expenditure").click(addExpenditureClick);
        $("#add").click(showAddModal);
        $("tr[data-get]").click(showEditModal);
    });
});