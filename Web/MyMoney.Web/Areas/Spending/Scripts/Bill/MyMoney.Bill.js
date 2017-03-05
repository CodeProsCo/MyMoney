
function BillModel(dataObj) {
    if (typeof(dataObj) == "undefined" || dataObj == null) {
        showError("Could not create bill model. Given data object is null");
        return undefined;
    }

    this.name = dataObj.name;
    this.amount = dataObj.amount;
    this.startDate = new Date(dataObj.startDate);
    this.category = dataObj.category;
    this.reoccuringPeriod = dataObj.reoccuringPeriod;
    this.id = dataObj.id;

    this.createTableRow = function(clickCallback) {
        var row = $("<tr>");

        var dateRow = $("<td>").text(this.startDate.toLocaleDateString());
        var descRow = $("<td>").text(this.name);
        var catRow = $("<td>").text(this.category);
        var periodRow = $("<td>").text(this.reoccuringPeriod); 
        var amountRow = $("<td>").addClass("right").addClass("aligned").text("£" + this.amount);

        row.attr("data-get", "/spending/bill/get/" + this.id);
        row.attr("data-delete", "/spending/bill/delete/" + this.id);

        row.append(dateRow);
        row.append(descRow);
        row.append(catRow);
        row.append(periodRow);
        row.append(amountRow);

        row.data("bill", this.id);

        if (typeof(clickCallback) !== "undefined" && typeof (clickCallback) == "function") {
            $(row).click(clickCallback);
        }

        return row;
    };
    return this;
}