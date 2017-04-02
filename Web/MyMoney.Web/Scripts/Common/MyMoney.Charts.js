/// <reference path="~/Scripts/Chartist/chartist-plugin-tooltip.js"/>
/// <reference path="~/Scripts/Moment/moment.js" />
function ChartGenerator(data) {
    this.data = data;
    this.chart = {};

    var self = this;

    this.createExpenditureChart = function(containerId) {
        var options = {
            container: containerId,
            data: this.data,
            animated:true
        }

        return createLineChart(options);
    }

    function createLineChart(options) {
        var chartData = [];

        for (var i = 0; i < self.data.length; i++) {
            var entry = { x: new Date(self.data[i].key).getTime(), y: self.data[i].value };

            chartData.push(entry);
        }

        var currentDate = new Date();
        var startDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), 1).getTime();
        var endDate = new Date(currentDate.getFullYear(), currentDate.getMonth() + 1, 1).getTime();

        self.chart = new Chartist.Line(options.container,
            {
                series: [
                    {
                        data: chartData
                    }
                ],
                fullWidth: true
            },
            {
                axisX: {
                    type: Chartist.FixedScaleAxis,
                    divisor: 10,
                    labelInterpolationFnc: function (value) {
                        return moment(value).format("DD-MM");
                    },
                    low: startDate,
                    high: endDate
                },
                axisY: {
                    labelInterpolationFnc: function (value) {
                        return value.asCurrency();
                    },
                    low:0
                },
                lineSmooth: Chartist.Interpolation.cardinal({
                    fillHoles: true
                }),
                height: 300
            });
    }

    this.createBillCategoryChart = function(containerId) {
        var options = {
            container: containerId,
            data: this.data
        };
        return createDonutChart(options);
    };
    this.createBillPeriodChart = function(containerId) {
        var options = {
            container: containerId,
            data: this.data
        };
        return createDonutChart(options);
    };

    function createDonutChart(options) {
        var labels = [];
        var series = [];

        var chartData = options.data;

        for (var i = 0; i < chartData.length; i++) {
            var item = chartData[i];
            var label = item.key;
            var value = item.value;

            labels.push(label);
            series.push(new ChartSeries(label, value));
        }

        var chartOptions = {
            height: 200,
            labelOffset: 1,
            donut: true,
            plugins: [
                Chartist.plugins.tooltip({
                    appendToBody: true
                })
            ]
        };

        var fullData = {
            labels: labels,
            series: series
        };

        var chart = new Chartist.Pie(options.container, fullData, chartOptions);

        self.chart = chart;
    }
}

function ChartSeries(meta, value) {
    this.meta = meta;
    this.value = value;
}