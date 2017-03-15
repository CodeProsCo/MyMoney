/// <reference path="~/Scripts/jQuery/jquery-3.1.1.js"/>
/// <reference path="~/Scripts/jQuery/jquery.inputmask.bundle.js"/>
/// <reference path="~/Scripts/jQuery/jquery.tablesorter.js" />
/// <reference path="~/Scripts/Semantic/semantic.js" />
/// <reference path="~/Scripts/jQuery/jquery.validate.unobtrusive.js" />
/// <reference path="~/Scripts/Intro/intro.js" />
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
        $(item).addClass("selected");
    }
}

$.validator.unobtrusive.parse($("form"));

$(".ui.accordion").accordion();
$(".ui.dropdown").dropdown();

$("[data-input-mask=currency]").inputmask("currency", { rightAlign: false, prefix: "", groupSeparator: "" });
$("table[data-sort=true]").tablesorter();
$("table[data-sort=true] th")
    .on("click",
        function(e) {
            e.stopPropagation();

            $(this).siblings().removeClass("highlighted");
            $(this).addClass("highlighted");
        });

$(".modal").modal("setting", "closable", false);

introJs().addHints();
introJs().hideHints();

var hintsEnabled = false;

$("#hint-button").click(function(e) {
    e.stopPropagation();

    if (!hintsEnabled) {
        $("#hint-button").html($("#hint-button").html().replace("Show", "Hide"));
        introJs().showHints();
        hintsEnabled = true;
    } else {
        introJs().hideHints();
        $("#hint-button").html($("#hint-button").html().replace("Hide", "Show"));
        hintsEnabled = false;
    }
})