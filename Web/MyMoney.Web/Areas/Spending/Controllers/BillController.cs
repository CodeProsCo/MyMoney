namespace MyMoney.Web.Areas.Spending.Controllers
{
    #region Usings

    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using MyMoney.ViewModels.Enum;
    using MyMoney.ViewModels.Spending.Bills;
    using MyMoney.Web.Attributes;
    using MyMoney.Web.Controllers;
    using MyMoney.Web.Orchestrators.Chart.Interfaces;
    using MyMoney.Web.Orchestrators.Spending.Interfaces;

    #endregion

    /// <summary>
    ///     The <see cref="BillController" /> controller handles HTTP requests regarding bills.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Controllers.BaseController" />
    [RouteArea("Spending", AreaPrefix = "spending")]
    [RoutePrefix("bill")]
    [Authorize]
    public class BillController : BaseController
    {
        #region Fields

        /// <summary>
        ///     The chart orchestrator
        /// </summary>
        private readonly IChartOrchestrator chartOrchestrator;

        /// <summary>
        ///     The orchestrator
        /// </summary>
        private readonly IBillOrchestrator orchestrator;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="BillController" /> class.
        /// </summary>
        /// <param name="orchestrator">The orchestrator.</param>
        /// <param name="chartOrchestrator">The chart orchestrator.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     Exception thrown if the chart or bill orchestrator are null.
        /// </exception>
        public BillController(IBillOrchestrator orchestrator, IChartOrchestrator chartOrchestrator)
        {
            if (orchestrator == null)
            {
                throw new ArgumentNullException(nameof(orchestrator));
            }

            if (chartOrchestrator == null)
            {
                throw new ArgumentNullException(nameof(chartOrchestrator));
            }

            this.orchestrator = orchestrator;
            this.chartOrchestrator = chartOrchestrator;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Handles a HTTP request to add a bill to the database.
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

            model.UserId = UserId;

            var response = await orchestrator.AddBill(model, UserEmail);

            return JsonResponse(response);
        }

        /// <summary>
        /// Handles an HTTP GET request to export the user's bills to a given type.
        /// </summary>
        /// <param name="exportType">Type of the export.</param>
        /// <returns>The response object.</returns>
        [HttpGet]
        [Route("export/{exportType}")]
        [AjaxOnly]
        public async Task<ActionResult> Export(ExportType exportType)
        {
            var response = await orchestrator.ExportBills(exportType, UserEmail, UserId);

            return JsonResponse(response);
        }

        /// <summary>
        ///     Handles a HTTP request to delete a specified bill.
        /// </summary>
        /// <param name="billId">The bill identifier.</param>
        /// <returns>The response object.</returns>
        [HttpGet]
        [Route("delete/{billId:Guid}")]
        [AjaxOnly]
        public async Task<ActionResult> Delete(Guid billId)
        {
            var response = await orchestrator.DeleteBill(billId, UserEmail);

            return JsonResponse(response);
        }

        /// <summary>
        ///     Handles HTTP requests to edit a specified bill.
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

            model.UserId = UserId;

            var response = await orchestrator.EditBill(model, UserEmail);

            return JsonResponse(response);
        }

        /// <summary>
        ///     Handles HTTP requests to get a specified bill.
        /// </summary>
        /// <param name="billId">The bill identifier.</param>
        /// <returns>The response object.</returns>
        [HttpGet]
        [AjaxOnly]
        [Route("get/{billId:Guid}")]
        public async Task<ActionResult> Get(Guid billId)
        {
            var modelWrapper = await orchestrator.GetBill(billId, UserEmail);

            return JsonResponse(modelWrapper);
        }

        /// <summary>
        ///     Handles HTTP requests to obtain the user's bills in a certain month.
        /// </summary>
        /// <param name="monthNumber">The month number.</param>
        /// <returns>The response object.</returns>
        [HttpGet]
        [AjaxOnly]
        [Route("get/month/{monthNumber:int}")]
        public async Task<ActionResult> GetBillsForMonth(int monthNumber)
        {
            var modelWrapper = await orchestrator.GetBillsForUserForMonth(monthNumber, UserId, UserEmail);

            return JsonResponse(modelWrapper);
        }

        /// <summary>
        ///     Handles HTTP requests to obtain the data required for the bill category chart.
        /// </summary>
        /// <returns>The response object.</returns>
        [HttpGet]
        [Route("chart/category")]
        [AjaxOnly]
        public async Task<ActionResult> GetCategoryChartData()
        {
            var modelWrapper = await chartOrchestrator.GetBillCategoryChartData(UserId, UserEmail);

            return JsonResponse(modelWrapper);
        }

        /// <summary>
        ///     Handles HTTP requests to obtain the data required for the bill period chart.
        /// </summary>
        /// <returns>The response object.</returns>
        [HttpGet]
        [Route("chart/period")]
        [AjaxOnly]
        public async Task<ActionResult> GetPeriodChartData()
        {
            var modelWrapper = await chartOrchestrator.GetBillPeriodChartData(UserId, UserEmail);

            return JsonResponse(modelWrapper);
        }

        /// <summary>
        ///     Handles HTTP requests for the bill management view.
        /// </summary>
        /// <returns>The bill management view.</returns>
        [HttpGet]
        [Route("manage")]
        public async Task<ActionResult> Manage()
        {
            var modelWrapper = await orchestrator.GetBillsForUser(UserId, UserEmail);

            AddModelErrors(modelWrapper.Errors);
            AddModelWarnings(modelWrapper.Warnings);

            return View("Manage", modelWrapper.Model);
        }

        #endregion
    }
}