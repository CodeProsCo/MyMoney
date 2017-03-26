/// <reference path="~/Scripts/jQuery/jquery.cookie.js"/>
/// <reference path="~/Scripts/Common/MyMoney.Cookies.js" />
/// <reference path="MyMoney.Initialize.js"/>

function LocalizedString(namespace, key) {
    this.key = key;
    this.namespace = namespace;
    this.value = "";

    var states = {
        unloaded: 0,
        loading: 1,
        loaded: 2,
        error: 3
    };
    this.state = states.unloaded;

    this.get = function (url) {
        this.state = states.loading;

        var self = this;

        $.ajax(url,
        {
            method: "GET",
            async: false,
            dataType: "json",
            success: function (data) {
                self.value = data;
                self.state = states.loaded;
            },
            error: function () {
                self.state = states.error;
                console.error("Failed to obtain resource " + self.namespace + "." + self.key);
            }
        });
    };
    return this;
}

function LocalizedStringStore(urlFormat) {
    this.strings = [];
    this.urlFormat = urlFormat;
    this.cookieManager = new CookieManager();

    var self = this;

    this.get = function (namespace, key) {
        var string = find(namespace, key, this.strings);

        if (typeof (string) == "undefined") {
            string = this.add(namespace, key, this);
        }

        return string.value;
    };
    this.add = function (namespace, key) {
        var newString = new LocalizedString(namespace, key);
        var url = formatUrl(this.urlFormat, namespace, key);

        newString.get(url);

        if (newString.state < 3) {
            this.strings.push(newString);

            this.cookieManager.create("myMoney_LocalizedStrings", this, true);
        }

        return newString;
    };
    if (this.cookieManager.exists("myMoney_LocalizedStrings")) {
        var cookie = this.cookieManager.get("myMoney_LocalizedStrings");

        $.each(cookie.strings,
            function (i, item) {
                var toAdd = new LocalizedString(item.namespace, item.key);

                toAdd.state = item.state;
                toAdd.value = item.value;

                self.strings.push(toAdd);
            });
    }

    function find(namespace, key, array) {
        for (var j = 0; j < array.length; j++) {
            var string = array[j];

            if (string.namespace === namespace && string.key === key) {
                return string;
            }
        }

        return undefined;
    }

    function formatUrl(url, namespace, key) {
        return url.replace("{namespace}", encodeURIComponent(namespace)).replace("{key}", encodeURIComponent(key));
    }

    return this;

}