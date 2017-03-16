namespace MyMoney.API.Controllers.Chart
{
    #region Usings

    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

    using DTO.Request.Chart.Bill;

    using Orchestrators.Chart.Interfaces;

    #endregion

    /// <summary>
    ///     The <see cref="BillChartController" /> class handles HTTP requests for the "chart/bill" route.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("chart/bill")]
    public class BillChartController : BaseController
    {
        #region Fields

        /// <summary>
        ///     The orchestrator
        /// </summary>
        private readonly IChartOrchestrator orchestrator;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="BillChartController" /> class.
        /// </summary>
        /// <param name="orchestrator">The orchestrator.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     Exception thrown if the orchestrator is null.
        /// </exception>
        public BillChartController(IChartOrchestrator orchestrator)
        {
            if (orchestrator == null)
            {
                throw new ArgumentNullException(nameof(orchestrator));
            }

            this.orchestrator = orchestrator;
        }

        #endregion

        #region  Public Methods

        /// <summary>
        ///     Handles HTTP GET requests for the bill category chart data for a user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object. Wrapped in a 200 response.</returns>
        [HttpGet]
        [Route("category/{userId:Guid}/{requestReference:Guid}")]
        public async Task<IHttpActionResult> GetCategoryChartData([FromUri] GetBillCategoryChartDataRequest request)
        {
            var response = await orchestrator.GetBillCategoryChartData(request);

            return Ok(response);
        }

        /// <summary>
        ///     Handles HTTP GET requests for the bill period chart data for a user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object. Wrapped in a 200 response.</returns>
        [HttpGet]
        [Route("period/{userId:Guid}/{requestReference:Guid}")]
        public async Task<IHttpActionResult> GetPeriodChartData([FromUri] GetBillPeriodChartDataRequest request)
        {
            var response = await orchestrator.GetBillPeriodChartData(request);

            return Ok(response);
        }

        #endregion
    }
}