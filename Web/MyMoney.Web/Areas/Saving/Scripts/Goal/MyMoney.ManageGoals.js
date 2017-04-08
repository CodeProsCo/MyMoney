/// <reference path="~/Scripts/jQuery/jquery-3.1.1.js"/>
/// <reference path="~/Scripts/Common/MyMoney.Ajax.js" />
/// <reference path="~/Scripts/Semantic/semantic.js" />
/// <reference path="~/Scripts/Extensions/MyMoney.StringExtensions.js" />
/// <reference path="~/Areas/Saving/Scripts/Goal/MyMoney.Goal.js" />
/// <reference path="~/Scripts/Common/MyMoney.Forms.js" />
$(function () {
    function showEditModal(event) {
        event.stopPropagation();

        var url = $(this).data("get");

        $(this).parent().parent().addClass("active-goal");

        var callback = AjaxResponse(getGoalSuccessCallback);

        $.ajax(url,
            {
                method: "GET",
                async: true,
                dataType: "json",
                success: callback,
                error: ajaxFail
            });
    }

    function getGoalSuccessCallback(data) {
        var model = new GoalModel(data.model);

        var modal = $("#edit-goal-modal");
        var inputs = $(modal).find("input");

        var deleteUrl = $("#delete-goal").data("url");
        deleteUrl = deleteUrl.substr(0, deleteUrl.length - 36) + model.id;

        $("#delete-goal").data("url", deleteUrl).attr("data-url", deleteUrl);


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
        if (data.success) {
            var successMsg = myMoney.strings.get("Goal", "Message_CreatedGoal");
            var goal = new GoalModel(data.model);

            if (typeof (goal.id) !== "undefined") {
                showSuccess(successMsg);
                $("#add-goal-form")[0].reset();
            }
        }

        $("#add-goal-modal").modal("hide");
    }

    function editGoalClick(event) {
        event.stopPropagation();

        submitForm("#edit-goal-form", editGoalSuccessCallback);
    }

    function editGoalSuccessCallback(data) {
        if (data.success) {
            var successMsg = myMoney.strings.get("Goal", "Message_UpdatedGoal");
            var goal = new GoalModel(data.model);

            if (typeof (goal.id) !== "undefined") {
                showSuccess(successMsg);
                $("#edit-goal-form")[0].reset();
            }

        }

        $("#edit-goal-modal").modal("hide");
    }

    function deleteGoalClick(event) {
        event.stopPropagation();

        var confirmText = myMoney.strings.get("Common", "Button_Confirm");

        var icon = $(this).find("i");

        $(this).text(confirmText);
        $(this).append(icon);

        $(this).off("click");
        $(this).click(confirmDeleteGoalClick);
    }

    function confirmDeleteGoalClick(event) {
        event.stopPropagation();

        var url = $(this).data("url");

        var callback = AjaxResponse(deleteGoalSuccessCallback);

        $.ajax(url,
            {
                method: "GET",
                async: true,
                dataType: "json",
                success: callback,
                error: ajaxFail
            });
    }

    function deleteGoalSuccessCallback(data) {
        if (data.success) {
            var successMsg = myMoney.strings.get("Goal", "Message_DeletedGoal");

            showSuccess(successMsg);

            $(".active-goal").remove();
        }

        $("#edit-goal-modal").modal("hide");

        var btnText = myMoney.strings.get("Common", "Button_Delete");

        var btn = $("#delete-goal");
        var icon = $(btn).find("i");

        $(btn).text(btnText);
        $(btn).append(icon);
        $(btn).off("click");
        $(btn).click(deleteGoalClick);

        
    }

    $("#add").click(showAddModal);
    $("#add-goal").click(addGoalClick);
    $("#edit-goal").click(editGoalClick);
    $("#delete-goal").click(deleteGoalClick);
    $("div[data-edit]").click(showEditModal);
    $("div[data-delete]").click(showDeleteModal);
})