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

    using Wrappers;

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
        public async Task<ActionResult> Add(BillViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return InvalidModelState(ModelState);
            }

            var userIdClaim = GetUserClaim(ClaimTypes.NameIdentifier);
            model.Id = Guid.Parse(userIdClaim.Value);

            var response =
                await orchestrator.AddBill(model, GetUserClaim(ClaimTypes.Email).Value);

            return JsonResponse(response);
        }

        [HttpGet]
        [Route("delete/{billId:Guid}")]
        [AjaxOnly]
        public async Task<ActionResult> Delete(Guid billId)
        {
            var response = await orchestrator.DeleteBill(billId, GetUserClaim(ClaimTypes.Email).Value);

            return JsonResponse(response);
        }

        [HttpPost]
        [Route("edit")]
        [AjaxOnly]
        public async Task<ActionResult> Edit(BillViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return InvalidModelState(ModelState);
            }

            var response = await orchestrator.EditBill(model, GetUserClaim(ClaimTypes.Email).Value);

            return JsonResponse(response);
        }

        [HttpGet]
        [AjaxOnly]
        [Route("get/{billId:Guid}")]
        public async Task<ActionResult> Get(Guid billId)
        {
            var modelWrapper = await orchestrator.GetBill(billId, GetUserClaim(ClaimTypes.Email).Value);

            modelWrapper.Errors = null;

            return JsonResponse(modelWrapper);
        }

        [HttpGet]
        [Route("manage")]
        public async Task<ActionResult> Manage()
        {
            var userIdClaim = GetUserClaim(ClaimTypes.NameIdentifier);

            var modelWrapper =
                await
                orchestrator.GetBillInformation(Guid.Parse(userIdClaim.Value), GetUserClaim(ClaimTypes.Email).Value);

            AddModelErrors(modelWrapper.Errors);
            AddModelWarnings(modelWrapper.Warnings);

            return View("Manage", modelWrapper.Model);
        }

        #endregion
    }
}