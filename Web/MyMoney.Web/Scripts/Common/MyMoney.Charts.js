/// <reference path="~/Scripts/Chartist/chartist-plugin-tooltip.js"/>

function ChartGenerator(data) {
    this.data = data;

    var self = this;

    this.createBillCategoryChart = function(containerId) {
        var options = {
            container: containerId,
            data: this.data,
            animated:true
        };
        return createDonutChart(options);
    };
    this.createBillPeriodChart = function(containerId) {
        var options = {
            container: containerId,
            data: this.data,
            animated: true
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