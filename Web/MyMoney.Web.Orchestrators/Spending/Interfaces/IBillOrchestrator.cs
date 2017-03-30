namespace MyMoney.Web.Orchestrators.Spending.Interfaces
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyMoney.ViewModels.Spending.Bills;
    using MyMoney.Wrappers;

    #endregion

    /// <summary>
    ///     The interface for the <see cref="BillOrchestrator" /> class.
    /// </summary>
    public interface IBillOrchestrator
    {
        #region Methods

        /// <summary>
        ///     Builds and sends a request to add a bill to the database.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="username">The username.</param>
        /// <returns>The response object.</returns>
        Task<OrchestratorResponseWrapper<BillViewModel>> AddBill(BillViewModel model, string username);

        /// <summary>
        ///     Builds and sends a request to delete a bill from the database.
        /// </summary>
        /// <param name="billId">
        ///     The bill Id.
        /// </param>
        /// <param name="username">
        ///     The username.
        /// </param>
        /// <returns>
        ///     The response object.
        /// </returns>
        Task<OrchestratorResponseWrapper<bool>> DeleteBill(Guid billId, string username);

        /// <summary>
        ///     Builds and sends a request to edit a bill from the database.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="username">The username.</param>
        /// <returns>The response object.</returns>
        Task<OrchestratorResponseWrapper<BillViewModel>> EditBill(BillViewModel model, string username);

        /// <summary>
        ///     Builds and sends a request to obtain a bill from the database.
        /// </summary>
        /// <param name="billId">
        ///     The bill Id.
        /// </param>
        /// <param name="username">
        ///     The username.
        /// </param>
        /// <returns>
        ///     The response object.
        /// </returns>
        Task<OrchestratorResponseWrapper<BillViewModel>> GetBill(Guid billId, string username);

        /// <summary>
        ///     Builds and sends a request to obtain bills for a specific user from the database.
        /// </summary>
        /// <param name="userId">
        ///     The user Id.
        /// </param>
        /// <param name="username">
        ///     The username.
        /// </param>
        /// <returns>
        ///     The response object.
        /// </returns>
        Task<OrchestratorResponseWrapper<ManageBillsViewModel>> GetBillsForUser(Guid userId, string username);

        /// <summary>
        ///     Builds and sends a request to obtain bills for a specific user for a given month from the database.
        /// </summary>
        /// <param name="monthNumber">The month number.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>The response object.</returns>
        Task<OrchestratorResponseWrapper<IList<KeyValuePair<DateTime, double>>>> GetBillsForUserForMonth(
            int monthNumber,
            Guid userId,
            string username);

        #endregion
    }
}