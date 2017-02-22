namespace MyMoney.API.Controllers.Spending
{
    #region Usings

    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

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

        [HttpGet]
        [Route("{userId:Guid}")]
        public async Task<IHttpActionResult> GetBillInformation(Guid userId)
        {
            var response = await orchestrator.GetBillInformation(userId);

            return Ok(response);
        }
    }
}