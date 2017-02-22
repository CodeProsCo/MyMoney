/// <reference path="~/Scripts/jQuery/jquery-3.1.1.js"/>
/// <reference path="~/Scripts/Semantic/semantic.js"/>
/// <reference path="~/Scripts/Common/MyMoney.ErrorHandling.js"/>
/// <reference path="~/Scripts/Common/MyMoney.Forms.js"/>

$(function() {
    function addBillSuccessCallback(data) {

        if (data.success) {
            var successMsg = myMoney.strings.get("Bills", "Message_RecordedBill");

            showSuccess(successMsg);
        }

        $("#add-bill-modal").modal("hide");
    }

    function addBillClick(event) {
        event.stopPropagation();

        submitForm("#add-bill-form", addBillSuccessCallback);
    }

    function showAddModal(event) {
        event.stopPropagation();

        $("#add-bill-modal").modal("show");
    }

    $("#add").click(showAddModal);
    $("#add-bill").click(addBillClick);
});