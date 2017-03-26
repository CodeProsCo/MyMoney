function ExpenditureModel(dataObj) {
    if (typeof (dataObj) == "undefined" || dataObj == null) {
        showError("Could not create expenditure model. Given data object is null");
        return undefined;
    }

    this.description = dataObj.Description || dataObj.description;
    this.amount = dataObj.Amount || dataObj.amount;
    this.dateOccurred = typeof (dataObj.dateOccurred) == "undefined" ? new Date(dataObj.DateOccurred) : new Date(dataObj.dateOccurred);
    this.category = dataObj.category || dataObj.Category;
    this.id = dataObj.id || dataObj.Id;

    this.createTableRow = function (clickCallback) {
        var row = $("<tr>");

        var dateRow = $("<td>").text(this.dateOccurred.toLocaleDateString());
        var descRow = $("<td>").text(this.description);
        var catRow = $("<td>").text(this.category);
        var amountRow = $("<td>").addClass("right").addClass("aligned").text(this.amount.asCurrency());

        row.attr("data-get", "/spending/expenditure/get/" + this.id);
        row.attr("data-delete", "/spending/expenditure/delete/" + this.id);

        row.append(dateRow);
        row.append(descRow);
        row.append(catRow);
        row.append(amountRow);

        row.data("expenditure", this.id);

        if (typeof (clickCallback) !== "undefined" && typeof (clickCallback) == "function") {
            $(row).click(clickCallback);
        }

        return row;
    };
    return this;
}