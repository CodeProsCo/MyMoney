
function BillModel(dataObj) {
    if (typeof(dataObj) == "undefined" || dataObj == null) {
        showError("Could not create bill model. Given data object is null");
        return undefined;
    }

    this.name = dataObj.name || dataObj.Name;
    this.amount = dataObj.amount || dataObj.Amount;
    this.startDate = dataObj.startDate ? new Date(dataObj.startDate) : new Date(dataObj.StartDate);
    this.category = dataObj.category || dataObj.Category;
    this.reoccurringPeriod = dataObj.reoccurringPeriod || dataObj.ReoccurringPeriod;
    this.id = dataObj.id || dataObj.Id;

    this.createTableRow = function(clickCallback) {
        var row = $("<tr>");

        var dateRow = $("<td>").text(this.startDate.toLocaleDateString());
        var descRow = $("<td>").text(this.name);
        var catRow = $("<td>").text(this.category);
        var periodRow = $("<td>").text(this.reoccurringPeriod);
        var amountRow = $("<td>").addClass("right").addClass("aligned").text(this.amount.asCurrency());

        row.attr("data-get", "/spending/bills/get/" + this.id);
        row.attr("data-delete", "/spending/bills/delete/" + this.id);

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