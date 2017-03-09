namespace MyMoney.API.Controllers.Chart
{
    #region Usings

    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

    using DTO.Request.Chart.Bill;

    using Orchestrators.Chart.Interfaces;

    #endregion

    [RoutePrefix("chart/bill")]
    public class BillChartController : ApiController
    {
        #region Fields

        private readonly IChartOrchestrator orchestrator;

        #endregion

        #region Constructor

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

        [HttpGet]
        [Route("category/{userId:Guid}/{requestReference:Guid}")]
        public async Task<IHttpActionResult> GetCategoryChartData([FromUri] GetBillCategoryChartDataRequest request)
        {
            var response = await orchestrator.GetBillCategoryChartData(request);

            return Ok(response);
        }

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