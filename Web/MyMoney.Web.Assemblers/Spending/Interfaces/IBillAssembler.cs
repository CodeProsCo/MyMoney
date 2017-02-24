namespace MyMoney.Web.Assemblers.Spending.Interfaces
{
    #region Usings

    using System;

    using DTO.Request.Spending;
    using DTO.Response.Spending;

    using ViewModels.Spending.Bills;

    #endregion

    /// <summary>
    /// Interface for the <see cref="BillAssembler"/> class.
    /// </summary>
    public interface IBillAssembler
    {
        #region  Public Methods

        /// <summary>
        ///     Assembles an instance of the <see cref="GetBillInformationRequest" /> class based on the given
        ///     <see cref="string" />.
        /// </summary>
        /// <param name="email">The user's email address.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        GetBillInformationRequest NewGetBillInformationRequest(Guid email);

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

        AddBillRequest NewAddBillRequest(AddBillViewModel model, Guid userId);

        BillViewModel NewBillViewModel(AddBillResponse apiResponse);
    }
}