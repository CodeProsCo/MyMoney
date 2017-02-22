
$(function() {
    $("#menu-toggle")
        .click(function(e) {
            e.stopPropagation();

            $("#sidebar").sidebar("toggle");
        });


    $("[data-redirect]")
        .click(function(e) {
            e.stopPropagation();

            var url = $(this).data("redirect");

            window.location = url;
        });


    var menuItems = $("a.item");

    for (var i = 0; i < menuItems.length; i++) {
        var item = $(menuItems[i]);

        var url = $(item).attr("href");

        if (window.location.href.indexOf(url) >= 0) {
            $(item).addClass("disabled");
        }
    }


    $(".ui.accordion").accordion();
    $(".ui.dropdown").dropdown();
    $("[data-input-mask=currency]").inputmask("currency", { rightAlign: false, prefix: "", groupSeparator: "" });

    initializeGlobalObject();
});