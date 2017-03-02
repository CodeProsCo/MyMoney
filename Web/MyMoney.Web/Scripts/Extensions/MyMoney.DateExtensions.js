Date.prototype.toISODate = function() {
    return this.getFullYear() + "-" + (this.getMonth() + 1) + "-" + this.getDate();
}