/// <reference path="~/Scripts/Intro/intro.js"/>

$(function() {
    $("#show-hints")
        .click(function(e) {
            e.stopPropagation();

            introJs().addHints();


        });
});