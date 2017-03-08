Number.prototype.asCurrency = function () {
	var number = this;

    return "£" + number.toFixed(2);
}