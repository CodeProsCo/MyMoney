using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MyMoney.API.Orchestrators.Chart.Interfaces;
using MyMoney.DTO.Request.Chart.Expenditure;

namespace MyMoney.API.Controllers.Chart
{
    [RoutePrefix("chart/expenditure")]
    public class ExpenditureChartController : BaseController
    {
        private IChartOrchestrator orchestrator;

        public ExpenditureChartController(IChartOrchestrator orchestrator)
        {
            if (orchestrator == null)
            {
                throw new ArgumentNullException(nameof(orchestrator));
            }

            this.orchestrator = orchestrator;
        }

        [HttpGet]
        [Route("month/{userId:Guid}/{month:int}/{requestReference:Guid}")]
        public async Task<IHttpActionResult> GetExpenditureChartData([FromUri] GetExpenditureChartDataRequest request)
        {
            var response = await orchestrator.GetExpenditureChartData(request);

            return Ok(response);
        }
    }
}