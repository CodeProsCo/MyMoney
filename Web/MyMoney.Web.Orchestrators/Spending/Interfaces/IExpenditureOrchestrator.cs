namespace MyMoney.Web.Orchestrators.Spending.Interfaces
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyMoney.ViewModels.Common;
    using MyMoney.ViewModels.Enum;
    using MyMoney.ViewModels.Spending.Expenditure;
    using MyMoney.Wrappers;

    #endregion

    /// <summary>
    ///     The interface for the <see cref="ExpenditureOrchestrator" /> class.
    /// </summary>
    public interface IExpenditureOrchestrator
    {
        #region Methods

        /// <summary>
        ///     Builds and sends a request to add a bill to the database.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="username">The username.</param>
        /// <returns>The response object.</returns>
        Task<OrchestratorResponseWrapper<ExpenditureViewModel>> AddExpenditure(
            ExpenditureViewModel model,
            string username);

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
        Task<OrchestratorResponseWrapper<bool>> DeleteExpenditure(Guid billId, string username);

        /// <summary>
        ///     Builds and sends a request to edit a bill from the database.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="username">The username.</param>
        /// <returns>The response object.</returns>
        Task<OrchestratorResponseWrapper<ExpenditureViewModel>> EditExpenditure(
            ExpenditureViewModel model,
            string username);

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
        Task<OrchestratorResponseWrapper<ExpenditureViewModel>> GetExpenditure(Guid billId, string username);

        /// <summary>
        ///     Builds and sends a request to obtain expenditure for a specific user from the database.
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
        Task<OrchestratorResponseWrapper<TrackExpenditureViewModel>> GetExpenditureForUser(Guid userId, string username);

        /// <summary>
        ///     Builds and sends a request to obtain expenditure for a specific user for a given month from the database.
        /// </summary>
        /// <param name="monthNumber">The month number.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>The response object.</returns>
        Task<OrchestratorResponseWrapper<IList<ExpenditureViewModel>>> GetExpenditureForUserForMonth(
            int monthNumber,
            Guid userId,
            string username);

        #endregion

        Task<OrchestratorResponseWrapper<ExportViewModel>> ExportExpenditure(ExportType exportType, string userEmail, Guid userId);
    }
}