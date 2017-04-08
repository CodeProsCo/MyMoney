/// <reference path="~/Scripts/jQuery/jquery-3.1.1.js"/>
/// <reference path="~/Scripts/Common/MyMoney.Ajax.js" />
/// <reference path="~/Scripts/Semantic/semantic.js" />
/// <reference path="~/Scripts/Extensions/MyMoney.StringExtensions.js" />
/// <reference path="~/Areas/Saving/Scripts/Goal/MyMoney.Goal.js" />
/// <reference path="~/Scripts/Common/MyMoney.Forms.js" />
$(function() {
    function showEditModal(event) {
        event.stopPropagation();

        var url = $(this).data("get");

        var callback = AjaxResponse(getGoalCallback);

        $.ajax(url,
            {
                method: "GET",
                async: true,
                dataType: "json",
                success: callback,
                error: ajaxFail
            });
    }

    function getGoalCallback(data) {
        var model = new GoalModel(data.model);

        var modal = $("#edit-goal-modal");
        var inputs = $(modal).find("input");

        $(inputs)
            .each(function (i, elem) {
                var prop = elem.id.replace("#", "").toCamelCase();

                if ($(elem).attr("type") === "date") {
                    elem.valueAsDate = model[prop];
                } else {
                    var value = model[prop];

                    $(elem).val(value);

                    if ($(elem).parent().hasClass("dropdown")) {
                        $(elem).siblings(".text").text(value);
                    }
                }
            });

        $("#edit-goal-modal").modal("show");       
    }

    function showDeleteModal(event) {
        event.stopPropagation();

        var url = $(this).data("delete");

        alert(url);
    }

    function showAddModal(event) {
        event.stopPropagation();

        $("#add-goal-modal").modal("show");
    }

    function addGoalClick(event) {
        event.stopPropagation();

        submitForm("#add-goal-form", addGoalSuccessCallback);
    }

    function addGoalSuccessCallback(data) {
        alert("test");
    }

    function editGoalClick(event) {
        event.stopPropagation();
    }

    function deleteGoalClick(event) {
        event.stopPropagation();
    }

    $("#add").click(showAddModal);
    $("#add-goal").click(addGoalClick);
    $("#edit-goal").click(editGoalClick);
    $("#delete-goal").click(deleteGoalClick);
    $("div[data-edit]").click(showEditModal);
    $("div[data-delete]").click(showDeleteModal);
})