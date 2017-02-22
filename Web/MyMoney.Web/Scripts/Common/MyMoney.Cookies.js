
function CookieManager() {
    this.get = function(cookieName) {
        var cookie = $.cookie(cookieName);

        if (typeof (cookie) == "undefined") {
            console.error("DEV-ERR :: Could not find cookie named " + cookieName);
        }

        return JSON.parse(cookie);
    };
    this.create = function(cookieName, object, global) {
        if (!global) {
            return $.cookie(cookieName, JSON.stringify(object));
        }

        return $.cookie(cookieName, JSON.stringify(object), { path: "/" });
    };
    this.exists = function(cookieName) {
        var cookie = $.cookie(cookieName);

        if (typeof (cookie) == "undefined") {
            return false;
        }

        return true;
    };
}