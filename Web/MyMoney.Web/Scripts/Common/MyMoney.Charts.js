/// <reference path="~/Scripts/Chartist/chartist-plugin-tooltip.js"/>

function ChartGenerator(data) {
    this.data = data;

    var groupTypes = {
        sum: 0,
        count: 1
    };
    var self = this;

    this.createBillCategoryChart = function(containerId) {
        var options = {
            container: containerId,
            data: this.data,
            groupProperty: "Category",
            groupType: groupTypes.count,
            animated: true,
            sumProperty: "Amount"
        };
        return createDonutChart(options);
    };
    this.createBillPeriodChart = function(containerId) {
        var options = {
            container: containerId,
            data: this.data,
            groupProperty: "ReoccuringPeriod",
            groupType: groupTypes.count,
            animated: true,
            sumProperty: "Amount"
        };
        return createDonutChart(options);
    };

    function createDonutChart(options) {
        var labels = [];
        var series = [];

        var chartData = options.data;
        var groupType = options.groupType;
        var groupProperty = options.groupProperty;

        for (var i = 0; i < chartData.length; i++) {
            var item = chartData[i];
            var label = item[0][groupProperty];

            labels.push(label);

            if (groupType === groupTypes.count) {
                var value = item.length.toString();

                series.push(new ChartSeries(label, value));
                continue;
            }

            if (groupType === groupTypes.sum) {
                var total = 0;
                var sumProperty = options.sumProperty;

                for (var j = 0; j < item.length; item++) {
                    total += item[j][sumProperty];
                }

                series.push(new ChartSeries(label, total));
            }
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
            series: series,
            colors: self.colours
        };

        var chart = new Chartist.Pie(options.container, fullData, chartOptions);

        if (options.animated) {
            addDonutAnimation(chart);
        }

        return chart;
    }

    function addDonutAnimation(chart) {
        chart.on("draw",
            function(chartData) {
                if (chartData.type === "slice") {
                    var pathLength = chartData.element._node.getTotalLength();

                    chartData.element.attr({
                        'stroke-dasharray': pathLength + "px " + pathLength + "px"
                    });

                    var animationDefinition = {
                        'stroke-dashoffset': {
                            id: "anim" + chartData.index,
                            dur: 500,
                            from: -pathLength + "px",
                            to: "0px",
                            easing: Chartist.Svg.Easing.easeOutQuint,
                            fill: "freeze"
                        }
                    };

                    if (chartData.index !== 0) {
                        animationDefinition["stroke-dashoffset"].begin = "anim" + (chartData.index - 1) + ".end";
                    }

                    chartData.element.attr({
                        'stroke-dashoffset': -pathLength + "px"
                    });

                    chartData.element.animate(animationDefinition, false);
                }
            });
    }
}

function ChartSeries(meta, value) {
    this.meta = meta;
    this.value = value;
}