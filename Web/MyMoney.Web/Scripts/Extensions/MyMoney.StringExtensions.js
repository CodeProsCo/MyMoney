String.prototype.toCamelCase = function() {
    return this.replace(/(?:^\w|[A-Z]|\b\w)/g,
            function(letter, index) {
                return index === 0 ? letter.toLowerCase() : letter.toUpperCase();
            })
        .replace(/\s+/g, "");
};
String.prototype.format = function(values) {
    if (values.length === 0) {
        console.error("Input was not in the correct format");
        return;
    }

    var regex = /{\d*}/;

    if (this.match(regex).length === 0) {
        console.error("String conains no format indicators");
        return;
    }

    for (var i = 0; i < values.length; i++) {
        var value = values[i];

        this.replace("{" + i + "}", value);
    }
};