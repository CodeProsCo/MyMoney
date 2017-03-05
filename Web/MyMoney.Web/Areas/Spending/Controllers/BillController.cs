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

    /// <summary>
    /// The <see cref="BillController"/> controller handles HTTP requests regarding bills.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Controllers.BaseController" />
    [RouteArea("Spending", AreaPrefix = "spending")]
    [RoutePrefix("bill")]
    [Authorize]
    public class BillController : BaseController
    {
        #region Fields

        /// <summary>
        /// The orchestrator
        /// </summary>
        private readonly IBillOrchestrator orchestrator;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BillController"/> class.
        /// </summary>
        /// <param name="orchestrator">The orchestrator.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Exception thrown if the orchestrator is null.
        /// </exception>
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

        /// <summary>
        /// Handles a HTTP request to add a bill to the database.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The response object.</returns>
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
            model.UserId = Guid.Parse(userIdClaim.Value);

            var response = await orchestrator.AddBill(model, GetUserClaim(ClaimTypes.Email).Value);

            return JsonResponse(response);
        }

        /// <summary>
        /// Handles a HTTP request to delete a specified bill.
        /// </summary>
        /// <param name="billId">The bill identifier.</param>
        /// <returns>The response object.</returns>
        [HttpGet]
        [Route("delete/{billId:Guid}")]
        [AjaxOnly]
        public async Task<ActionResult> Delete(Guid billId)
        {
            var response = await orchestrator.DeleteBill(billId, GetUserClaim(ClaimTypes.Email).Value);

            return JsonResponse(response);
        }

        /// <summary>
        /// Handles HTTP requests to edit a specified bill.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The response object.</returns>
        [HttpPost]
        [Route("edit")]
        [AjaxOnly]
        public async Task<ActionResult> Edit(BillViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return InvalidModelState(ModelState);
            }

            model.UserId = Guid.Parse(GetUserClaim(ClaimTypes.NameIdentifier).Value);

            var response = await orchestrator.EditBill(model, GetUserClaim(ClaimTypes.Email).Value);

            return JsonResponse(response);
        }

        /// <summary>
        /// Handles HTTP requests to get a specified bill.
        /// </summary>
        /// <param name="billId">The bill identifier.</param>
        /// <returns>The response object.</returns>
        [HttpGet]
        [AjaxOnly]
        [Route("get/{billId:Guid}")]
        public async Task<ActionResult> Get(Guid billId)
        {
            var modelWrapper = await orchestrator.GetBill(billId, GetUserClaim(ClaimTypes.Email).Value);

            return JsonResponse(modelWrapper);
        }

        /// <summary>
        /// Handles HTTP requests for the bill management view.
        /// </summary>
        /// <returns>The bill management view.</returns>
        [HttpGet]
        [Route("manage")]
        public async Task<ActionResult> Manage()
        {
            var userIdClaim = GetUserClaim(ClaimTypes.NameIdentifier);

            var modelWrapper =
                await
                orchestrator.GetBillsForUser(Guid.Parse(userIdClaim.Value), GetUserClaim(ClaimTypes.Email).Value);

            AddModelErrors(modelWrapper.Errors);
            AddModelWarnings(modelWrapper.Warnings);

            return View("Manage", modelWrapper.Model);
        }

        #endregion
    }
}