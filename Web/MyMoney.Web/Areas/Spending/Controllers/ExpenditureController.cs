namespace MyMoney.Web.Areas.Spending.Controllers
{
    #region Usings

    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using MyMoney.ViewModels.Spending.Expenditure;
    using MyMoney.Web.Attributes;
    using MyMoney.Web.Controllers;
    using MyMoney.Web.Orchestrators.Chart.Interfaces;
    using MyMoney.Web.Orchestrators.Spending.Interfaces;

    #endregion

    /// <summary>
    ///     The <see cref="ExpenditureController" /> controller handles HTTP requests regarding expenditures.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Controllers.BaseController" />
    [RouteArea("Spending", AreaPrefix = "spending")]
    [RoutePrefix("expenditure")]
    [Authorize]
    public class ExpenditureController : BaseController
    {
        #region Fields

        /// <summary>
        ///     The chart orchestrator
        /// </summary>
        private readonly IChartOrchestrator chartOrchestrator;

        /// <summary>
        ///     The orchestrator
        /// </summary>
        private readonly IExpenditureOrchestrator orchestrator;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpenditureController" /> class.
        /// </summary>
        /// <param name="orchestrator">The orchestrator.</param>
        /// <param name="chartOrchestrator">The chart orchestrator.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     Exception thrown if the chart or expenditure orchestrator are null.
        /// </exception>
        public ExpenditureController(IExpenditureOrchestrator orchestrator, IChartOrchestrator chartOrchestrator)
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
        ///     Handles a HTTP request to add a expenditure to the database.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The response object.</returns>
        [HttpPost]
        [Route("add")]
        [AjaxOnly]
        public async Task<ActionResult> Add(ExpenditureViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return InvalidModelState(ModelState);
            }

            model.UserId = UserId;

            var response = await orchestrator.AddExpenditure(model, UserEmail);

            return JsonResponse(response);
        }

        /// <summary>
        ///     Handles a HTTP request to delete a specified expenditure.
        /// </summary>
        /// <param name="expenditureId">The expenditure identifier.</param>
        /// <returns>The response object.</returns>
        [HttpGet]
        [Route("delete/{expenditureId:Guid}")]
        [AjaxOnly]
        public async Task<ActionResult> Delete(Guid expenditureId)
        {
            var response = await orchestrator.DeleteExpenditure(expenditureId, UserEmail);

            return JsonResponse(response);
        }

        /// <summary>
        ///     Handles HTTP requests to edit a specified expenditure.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The response object.</returns>
        [HttpPost]
        [Route("edit")]
        [AjaxOnly]
        public async Task<ActionResult> Edit(ExpenditureViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return InvalidModelState(ModelState);
            }

            model.UserId = UserId;

            var response = await orchestrator.EditExpenditure(model, UserEmail);

            return JsonResponse(response);
        }

        /// <summary>
        ///     Handles HTTP requests to get a specified expenditure.
        /// </summary>
        /// <param name="expenditureId">The expenditure identifier.</param>
        /// <returns>The response object.</returns>
        [HttpGet]
        [AjaxOnly]
        [Route("get/{expenditureId:Guid}")]
        public async Task<ActionResult> Get(Guid expenditureId)
        {
            var modelWrapper = await orchestrator.GetExpenditure(expenditureId, UserEmail);

            return JsonResponse(modelWrapper);
        }

        /// <summary>
        ///     Handles HTTP requests to obtain the data required for the expenditure category chart.
        /// </summary>
        /// <returns>The response object.</returns>
        [HttpGet]
        [Route("chart/month/")]
        [AjaxOnly]
        public async Task<ActionResult> GetExpenditureChartData()
        {
            var modelWrapper = await chartOrchestrator.GetExpenditureChartData(UserId, UserEmail);

            return JsonResponse(modelWrapper);
        }

        /// <summary>
        ///     Handles HTTP requests to obtain the user's expenditures in a certain month.
        /// </summary>
        /// <param name="monthNumber">The month number.</param>
        /// <returns>The response object.</returns>
        [HttpGet]
        [AjaxOnly]
        [Route("get/month/{monthNumber:int}")]
        public async Task<ActionResult> GetExpenditureForMonth(int monthNumber)
        {
            var modelWrapper = await orchestrator.GetExpenditureForUserForMonth(monthNumber, UserId, UserEmail);

            return JsonResponse(modelWrapper);
        }

        /// <summary>
        ///     Handles HTTP requests for the expenditure management view.
        /// </summary>
        /// <returns>The expenditure management view.</returns>
        [HttpGet]
        [Route("track")]
        public async Task<ActionResult> Track()
        {
            var modelWrapper = await orchestrator.GetExpenditureForUser(UserId, UserEmail);

            AddModelErrors(modelWrapper.Errors);
            AddModelWarnings(modelWrapper.Warnings);

            return View("Track", modelWrapper.Model);
        }

        #endregion
    }
}