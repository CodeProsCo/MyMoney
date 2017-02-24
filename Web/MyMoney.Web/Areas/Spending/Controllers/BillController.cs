namespace MyMoney.Web.Areas.Spending.Controllers
{
    #region Usings

    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Attributes;

    using Orchestrators.Spending.Interfaces;

    using ViewModels.Spending.Bills;

    using Web.Controllers;

    #endregion

    [RouteArea("Spending", AreaPrefix = "spending")]
    [RoutePrefix("bill")]
    [Authorize]
    public class BillController : BaseController
    {
        #region Fields

        private readonly IBillOrchestrator orchestrator;

        #endregion

        #region Constructor

        public BillController(IBillOrchestrator orchestrator)
        {
            if (orchestrator == null)
            {
                throw new ArgumentNullException(nameof(orchestrator));
            }

            this.orchestrator = orchestrator;
        }

        #endregion

        #region  Public Methods

        [HttpPost]
        [Route("add")]
        [AjaxOnly]
        public async Task<ActionResult> Add(AddBillViewModel model)
        {
            var userIdClaim = GetUserClaim(ClaimTypes.NameIdentifier);

            var response = await orchestrator.AddBill(model, Guid.Parse(userIdClaim.Value));

            return JsonResponse(response);
        }

        [HttpGet]
        [Route("manage")]
        public async Task<ActionResult> Manage()
        {
            var userIdClaim = GetUserClaim(ClaimTypes.NameIdentifier);

            var modelWrapper = await orchestrator.GetBillInformation(Guid.Parse(userIdClaim.Value));

            AddModelErrors(modelWrapper.Errors);
            AddModelWarnings(modelWrapper.Warnings);

            return View("Manage", modelWrapper.Model);
        }

        #endregion
    }
}