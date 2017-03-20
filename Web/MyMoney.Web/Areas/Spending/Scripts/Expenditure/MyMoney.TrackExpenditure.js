/// <reference path="~/Scripts/jQuery/jquery-3.1.1.js"/>
/// <reference path="~/Scripts/Semantic/calendar.js"/>
/// <reference path="~/Scripts/Chartist/chartist.js" />
/// <reference path="~/Scripts/Moment/moment.js" />
$(function () {
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
	                x: 1461862387541, y: 23.55

	            },
	            	            {
	            	                x: 9961862447991, y: 25.55

	            	            }]
	        }],
	        fullWidth: true,
	        chartPadding: {
	            right: 160
	        } 

	    },
	    {
	        axisX: {
	            type: Chartist.FixedScaleAxis,
	            divisor: 10,
	            labelInterpolationFnc: function (value) {
	                return moment(value).format("d-MM");
	            }
	        },
	        lineSmooth: Chartist.Interpolation.cardinal({
	            fillHoles: true
	        }),
	        low: 0,
	        height: 200
	    });
    }

    $(function () {
        loadCalendarData("#expenditure-calendar");
    });
});