namespace MyMoney.API.Controllers.Chart
{
    #region Usings

    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

    using DTO.Request.Chart.Expenditure;

    using Orchestrators.Chart.Interfaces;

    #endregion

    /// <summary>
    /// The <see cref="ExpenditureChartController"/> class handles HTTP requests in the "chart/expenditure" route.
    /// </summary>
    /// <seealso cref="MyMoney.API.Controllers.BaseController" />
    [RoutePrefix("chart/expenditure")]
    public class ExpenditureChartController : BaseController
    {
        #region Fields

        /// <summary>
        /// The orchestrator
        /// </summary>
        private readonly IChartOrchestrator orchestrator;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenditureChartController"/> class.
        /// </summary>
        /// <param name="orchestrator">The orchestrator.</param>
        /// <exception cref="System.ArgumentNullException">orchestrator
        /// Exception thrown if the orchestrator is null.
        /// </exception>
        public ExpenditureChartController(IChartOrchestrator orchestrator)
        {
            if (orchestrator == null)
            {
                throw new ArgumentNullException(nameof(orchestrator));
            }

            this.orchestrator = orchestrator;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles an HTTP GET request to obtain the data for the expenditure chart.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object, wrapped in a 200 response.</returns>
        [HttpGet]
        [Route("month/{userId:Guid}/{month:int}/{requestReference:Guid}")]
        public async Task<IHttpActionResult> GetExpenditureChartData([FromUri] GetExpenditureChartDataRequest request)
        {
            var response = await orchestrator.GetExpenditureChartData(request);

            return Ok(response);
        }

        #endregion
    }
}