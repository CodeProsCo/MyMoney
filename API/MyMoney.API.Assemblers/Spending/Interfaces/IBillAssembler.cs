namespace MyMoney.API.Assemblers.Spending.Interfaces
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using DataModels.Spending;

    using DTO.Response.Spending.Bill;

    using Proxies.Spending;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="BillAssembler" /> class.
    /// </summary>
    public interface IBillAssembler
    {
        #region Methods

        /// <summary>
        ///     Creates a new instance of the <see cref="AddBillResponse" /> class.
        /// </summary>
        /// <param name="bill">The bill.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        AddBillResponse NewAddBillResponse(BillDataModel bill, Guid requestReference);

        /// <summary>
        ///     Creates an instance of the <see cref="BillDataModel" /> class.
        /// </summary>
        /// <param name="bill">The bill proxy.</param>
        /// <returns>The bill data model.</returns>
        BillDataModel NewBillDataModel(BillProxy bill);

        /// <summary>
        ///     Creates an instance of the <see cref="DeleteBillResponse" /> class.
        /// </summary>
        /// <param name="success">The success indicator.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        DeleteBillResponse NewDeleteBillResponse(bool success, Guid requestReference);

        /// <summary>
        ///     Creates an instance of the <see cref="EditBillResponse" /> class.
        /// </summary>
        /// <param name="model">The data model.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        EditBillResponse NewEditBillResponse(BillDataModel model, Guid requestReference);

        /// <summary>
        ///     Creates an instance of the <see cref="GetBillResponse" /> class.
        /// </summary>
        /// <param name="bill">The bill.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        GetBillResponse NewGetBillResponse(BillDataModel bill, Guid requestReference);

        /// <summary>
        ///     Creates an instance of the <see cref="GetBillsForUserForMonthResponse" /> class.
        /// </summary>
        /// <param name="data">The bill data.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        GetBillsForUserForMonthResponse NewGetBillsForUserForMonthResponse(
            IList<KeyValuePair<DateTime, double>> data,
            Guid requestReference);

        /// <summary>
        ///     Creates an instance of the <see cref="GetBillsForUserResponse" /> class.
        /// </summary>
        /// <param name="bills">The bills.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        GetBillsForUserResponse NewGetBillsForUserResponse(IList<BillDataModel> bills, Guid requestReference);

        #endregion
    }
}