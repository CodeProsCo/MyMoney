namespace MyMoney.Web.DataAccess.Chart.Interfaces
{
    #region Usings

    using System.Threading.Tasks;

    using DTO.Request.Chart.Bill;
    using DTO.Request.Chart.Expenditure;
    using DTO.Response.Chart.Bill;
    using DTO.Response.Chart.Expenditure;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="ChartDataAccess" /> class.
    /// </summary>
    public interface IChartDataAccess
    {
        #region Methods

        /// <summary>
        ///     Sends an HTTP GET request to obtain data for the bill category chart.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<GetBillCategoryChartDataResponse> GetBillCategoryChartData(GetBillCategoryChartDataRequest request);

        /// <summary>
        ///     Sends an HTTP GET request to obtain data for the bill period chart.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<GetBillPeriodChartDataResponse> GetBillPeriodChartData(GetBillPeriodChartDataRequest request);

        /// <summary>
        /// Sends an HTTP GET request to obtain data for the expenditure chart.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<GetExpenditureChartDataResponse> GetExpenditureChartData(GetExpenditureChartDataRequest request);

        #endregion
    }
}