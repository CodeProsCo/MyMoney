namespace MyMoney.API.Controllers.Spending
{
    #region Usings

    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

    using DTO.Request.Spending;

    using Orchestrators.Spending.Interfaces;

    #endregion

    [RoutePrefix("spending/bills")]
    public class BillController : ApiController
    {
        private readonly IBillOrchestrator orchestrator;

        public BillController(IBillOrchestrator orchestrator)
        {
            if (orchestrator == null)
            {
                throw new ArgumentNullException(nameof(orchestrator));
            }

            this.orchestrator = orchestrator;
        }

        [HttpPost]
        [Route("user")]
        public async Task<IHttpActionResult> GetBillInformation([FromBody] GetBillInformationRequest request)
        {
            var response = await orchestrator.GetBillInformation(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IHttpActionResult> AddBill([FromBody] AddBillRequest request)
        {
            var response = await orchestrator.AddBill(request);

            return Ok(response);
        }
    }
}