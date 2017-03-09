namespace MyMoney.Web.Orchestrators.Chart.Interfaces
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ViewModels.Spending.Bills.Enum;

    using Wrappers;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="ChartOrchestrator" /> class.
    /// </summary>
    public interface IChartOrchestrator
    {
        #region  Public Methods

        /// <summary>
        ///     Builds and sends an HTTP request for the data required to produce the bill category chart.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>The response object.</returns>
        Task<OrchestratorResponseWrapper<IList<KeyValuePair<string, int>>>> GetBillCategoryChartData(
            Guid userId, 
            string username);

        /// <summary>
        ///     Builds and sends an HTTP request for the data required to produce the bill period chart.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>The response object.</returns>
        Task<OrchestratorResponseWrapper<IList<KeyValuePair<TimePeriod, int>>>> GetBillPeriodChartData(
            Guid userId, 
            string username);

        #endregion
    }
}