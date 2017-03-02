namespace MyMoney.Web.Assemblers.Spending.Interfaces
{
    #region Usings

    using System;

    using DTO.Request.Spending;
    using DTO.Response.Spending;

    using ViewModels.Spending.Bills;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="BillAssembler" /> class.
    /// </summary>
    public interface IBillAssembler
    {
        #region  Public Methods

        AddBillRequest NewAddBillRequest(BillViewModel model, string username);

        BillViewModel NewBillViewModel(AddBillResponse apiResponse);

        BillViewModel NewBillViewModel(GetBillResponse apiResponse);

        /// <summary>
        ///     Assembles an instance of the <see cref="GetBillInformationRequest" /> class based on the given
        ///     <see cref="string" />.
        /// </summary>
        /// <param name="email">The user's email address.</param>
        /// <param name="username"></param>
        /// <returns>
        ///     The request object.
        /// </returns>
        GetBillInformationRequest NewGetBillInformationRequest(Guid email, string username);

        GetBillRequest NewGetBillRequest(Guid billId, string username);

        /// <summary>
        ///     Assembles an instance of the <see cref="ManageBillsViewModel" /> class based on the given
        ///     <see cref="GetBillInformationResponse" />.
        /// </summary>
        /// <param name="apiResponse">The response object.</param>
        /// <returns>
        ///     The view model.
        /// </returns>
        ManageBillsViewModel NewManageBillsViewModel(GetBillInformationResponse apiResponse);

        #endregion

        DeleteBillRequest NewDeleteBillRequest(Guid billId, string username);

        EditBillRequest NewEditBillRequest(BillViewModel model, string username);

        BillViewModel NewBillViewModel(EditBillResponse apiResponse);
    }
}