function GoalModel(dataObj) {
    if (typeof (dataObj) == "undefined" || dataObj == null) {
        showError("Could not create goal model. Given data object is null");
        return undefined;
    }

    this.name = dataObj.name || dataObj.Name;
    this.amount = dataObj.amount || dataObj.Amount;
    this.startDate = dataObj.startDate ? new Date(dataObj.startDate) : new Date(dataObj.StartDate);
    this.endDate = dataObj.endDate ? new Date(dataObj.endDate) : new Date(dataObj.EndDate);
    this.id = dataObj.id || dataObj.Id;

    return this;
}