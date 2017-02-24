
function BillModel(dataObj) {
	if (typeof(dataObj) == "undefined") {
		showError("Could not create bill model. Given data object is null");
	    return undefined;
	}

	this.name = dataObj.name;
	this.amount = dataObj.amount;
	this.startDate = new Date(dataObj.startDate);
	this.category = dataObj.category;
	this.period = dataObj.reoccuringPeriod;

    this.createTableRow = function() {
        var row = $("<tr>");

        var dateRow = $("<td>").text(this.startDate.toLocaleDateString());
        var descRow = $("<td>").text(this.name);
        var catRow = $("<td>").text(this.category);
        var periodRow = $("<td>").text(this.period);
        var amountRow = $("<td>").addClass("right").addClass("aligned").text("£" + this.amount);

        row.append(dateRow);
        row.append(descRow);
        row.append(catRow);
        row.append(periodRow);
        row.append(amountRow);
        row.addClass("positive");

        return row;
    }

    return this;
}