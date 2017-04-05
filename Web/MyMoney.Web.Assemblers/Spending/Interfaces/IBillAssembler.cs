namespace MyMoney.Web.Assemblers.Spending.Interfaces
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using DTO.Request.Spending.Bill;
    using DTO.Response.Spending.Bill;

    using Proxies.Spending;

    using ViewModels.Common;
    using ViewModels.Enum;
    using ViewModels.Spending.Bills;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="BillAssembler" /> class.
    /// </summary>
    public interface IBillAssembler
    {
        #region Methods

        /// <summary>
        ///     Creates an instance of the <see cref="AddBillRequest" />. class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="username">The username.</param>
        /// <returns>The request object.</returns>
        AddBillRequest NewAddBillRequest(BillViewModel model, string username);

        /// <summary>
        ///     Creates an instance of the <see cref="BillViewModel" />. class.
        /// </summary>
        /// <param name="apiResponse">
        ///     The API Response.
        /// </param>
        /// <returns>
        ///     The view model.
        /// </returns>
        BillViewModel NewBillViewModel(AddBillResponse apiResponse);

        /// <summary>
        ///     Creates an instance of the <see cref="BillViewModel" />. class.
        /// </summary>
        /// <param name="apiResponse">
        ///     The API Response.
        /// </param>
        /// <returns>
        ///     The view model.
        /// </returns>
        BillViewModel NewBillViewModel(GetBillResponse apiResponse);

        /// <summary>
        ///     Creates an instance of the <see cref="BillViewModel" />. class.
        /// </summary>
        /// <param name="apiResponse">
        ///     The API Response.
        /// </param>
        /// <returns>
        ///     The view model.
        /// </returns>
        BillViewModel NewBillViewModel(EditBillResponse apiResponse);

        /// <summary>
        ///     Creates an instance of the <see cref="DeleteBillRequest" />. class.
        /// </summary>
        /// <param name="billId">
        ///     The bill Id.
        /// </param>
        /// <param name="username">
        ///     The username.
        /// </param>
        /// <returns>
        ///     The request object.
        /// </returns>
        DeleteBillRequest NewDeleteBillRequest(Guid billId, string username);

        /// <summary>
        ///     Creates an instance of the <see cref="EditBillRequest" />. class.
        /// </summary>
        /// <param name="model">
        ///     The model.
        /// </param>
        /// <param name="username">
        ///     The username.
        /// </param>
        /// <returns>
        ///     The request object.
        /// </returns>
        EditBillRequest NewEditBillRequest(BillViewModel model, string username);

        /// <summary>
        /// Creates a new instance of the <see cref="ExportViewModel"/> class based on the given list of bills.
        /// </summary>
        /// <param name="exportType">Type of the export.</param>
        /// <param name="apiResponseBills">The bills.</param>
        /// <returns>The view model.</returns>
        ExportViewModel NewExportViewModel(ExportType exportType, IList<BillProxy> apiResponseBills);

        /// <summary>
        ///     Creates an instance of the <see cref="GetBillRequest" />. class.
        /// </summary>
        /// <param name="billId">The bill identifier.</param>
        /// <param name="username">
        ///     The username.
        /// </param>
        /// <returns>
        ///     The request object.
        /// </returns>
        GetBillRequest NewGetBillRequest(Guid billId, string username);

        /// <summary>
        ///     Creates an instance of the <see cref="GetBillsForUserForMonthRequest" />. class.
        /// </summary>
        /// <param name="monthNumber">The month number.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="userEmail">The user email.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        GetBillsForUserForMonthRequest NewGetBillsForUserForMonthRequest(int monthNumber, Guid userId, string userEmail);

        /// <summary>
        ///     Assembles an instance of the <see cref="GetBillsForUserRequest" /> class based on the given
        ///     <see cref="string" />.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        GetBillsForUserRequest NewGetBillsForUserRequest(Guid userId, string username);

        /// <summary>
        ///     Assembles an instance of the <see cref="ManageBillsViewModel" /> class based on the given
        ///     <see cref="GetBillsForUserResponse" />.
        /// </summary>
        /// <param name="apiResponse">The response object.</param>
        /// <returns>
        ///     The view model.
        /// </returns>
        ManageBillsViewModel NewManageBillsViewModel(GetBillsForUserResponse apiResponse);

        #endregion
    }
}