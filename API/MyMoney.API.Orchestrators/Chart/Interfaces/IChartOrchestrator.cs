namespace MyMoney.API.Orchestrators.Chart.Interfaces
{
    #region Usings

    using System.Threading.Tasks;

    using DTO.Request.Chart.Bill;
    using DTO.Request.Chart.Expenditure;
    using DTO.Response.Chart.Bill;
    using DTO.Response.Chart.Expenditure;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="ChartOrchestrator" /> class.
    /// </summary>
    public interface IChartOrchestrator
    {
        #region Methods

        /// <summary>
        ///     Obtains the bill category chart data from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<GetBillCategoryChartDataResponse> GetBillCategoryChartData(GetBillCategoryChartDataRequest request);

        /// <summary>
        ///     Obtains the bill period chart data from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<GetBillPeriodChartDataResponse> GetBillPeriodChartData(GetBillPeriodChartDataRequest request);

        /// <summary>
        /// Obtains the data required for the expenditure chart.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<GetExpenditureChartDataResponse> GetExpenditureChartData(GetExpenditureChartDataRequest request);

        #endregion
    }
}