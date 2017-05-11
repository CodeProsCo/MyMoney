namespace MyMoney.Web.DataAccess.Chart
{
    #region Usings

    using System.Threading.Tasks;

    using DTO.Request.Chart.Bill;
    using DTO.Request.Chart.Expenditure;
    using DTO.Response.Chart.Bill;
    using DTO.Response.Chart.Expenditure;

    using Helpers.Error.Interfaces;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     The <see cref="ChartDataAccess" /> class sends requests to the API regarding charts.
    /// </summary>
    /// <seealso cref="MyMoney.Web.DataAccess.BaseDataAccess" />
    /// <seealso cref="MyMoney.Web.DataAccess.Chart.Interfaces.IChartDataAccess" />
    [UsedImplicitly]
    public class ChartDataAccess : BaseDataAccess, IChartDataAccess
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChartDataAccess"/> class.
        /// </summary>
        /// <param name="errorHelper">The error helper.</param>
        public ChartDataAccess(IErrorHelper errorHelper)
            : base(errorHelper)
        {          
        }

        #region Methods

        /// <summary>
        ///     Sends an HTTP GET request to obtain data for the bill category chart.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<GetBillCategoryChartDataResponse> GetBillCategoryChartData(
            GetBillCategoryChartDataRequest request)
        {
            return await Get<GetBillCategoryChartDataResponse>(request.FormatRequestUri(), request.Username);
        }

        /// <summary>
        ///     Sends an HTTP GET request to obtain data for the bill period chart.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<GetBillPeriodChartDataResponse> GetBillPeriodChartData(GetBillPeriodChartDataRequest request)
        {
            return await Get<GetBillPeriodChartDataResponse>(request.FormatRequestUri(), request.Username);
        }

        /// <summary>
        /// Sends an HTTP GET request to obtain data for the expenditure chart.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The response object.
        /// </returns>
        public async Task<GetExpenditureChartDataResponse> GetExpenditureChartData(
            GetExpenditureChartDataRequest request)
        {
            return await Get<GetExpenditureChartDataResponse>(request.FormatRequestUri(), request.Username);
        }

        #endregion
    }
}