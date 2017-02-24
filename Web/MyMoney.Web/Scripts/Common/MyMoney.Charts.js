
function ChartGenerator(data) {
	this.data = data;
	this.colours = ["#F0B67F", "#FE5F55", "#D6D1B1", "#C7EFCF", "#EEF5DB"];

	var groupTypes = {
		sum: 0,
		count: 1
	}

    var self = this;

	this.createBillCategoryChart = function (containerId) {
		var options = {
			container: containerId,
			data: this.data,
			groupProperty: "Category",
			groupType: groupTypes.count,
			animated: true
		}

		return createDonutChart(options);
	}

	this.createBillPeriodChart = function(containerId) {
		var options = {
			container: containerId,
			data: this.data,
			groupProperty: "ReoccuringPeriod",
			groupType: groupTypes.count,
			animated: true
		}

		return createDonutChart(options);
	}

	function createDonutChart(options) {
		var labels = [];
		var series = [];

		var chartData = options.data;
		var groupType = options.groupType;
	    var groupProperty = options.groupProperty;

		for (var i = 0; i < chartData.length; i++) {
			var item = chartData[i];

			labels.push(item[0][groupProperty]);

			if (groupType === groupTypes.count) {
				series.push(item.length.toString());
				continue;
			}

			if (groupType === groupTypes.sum) {
				var total = 0;
				var sumProperty = options.sumProperty;

				for (var j = 0; j < item.length; item++) {
					total += item[j][sumProperty];
				}
			}
		}

		var chartOptions = {
			height: 200,
			labelOffset: 1,
			donut: true
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
        function (data) {
        	if (data.type === "slice") {
        		var pathLength = data.element._node.getTotalLength();

        		data.element.attr({
        			'stroke-dasharray': pathLength + "px " + pathLength + "px"
        		});

        		var animationDefinition = {
        			'stroke-dashoffset': {
        				id: "anim" + data.index,
        				dur: 500,
        				from: -pathLength + "px",
        				to: "0px",
        				easing: Chartist.Svg.Easing.easeOutQuint,
        				fill: "freeze"
        			}
        		};

        		if (data.index !== 0) {
        			animationDefinition["stroke-dashoffset"].begin = "anim" + (data.index - 1) + ".end";
        		}

        		data.element.attr({
        			'stroke-dashoffset': -pathLength + "px"
        		});

        		data.element.animate(animationDefinition, false);
        	}
        });
	}
}