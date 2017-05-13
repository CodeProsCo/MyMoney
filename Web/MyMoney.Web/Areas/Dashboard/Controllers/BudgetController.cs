namespace MyMoney.Web.Areas.Dashboard.Controllers
{
    #region Usings

    using System.Web.Mvc;

    using Helpers.Benchmarking.Interfaces;
    using Helpers.Error.Interfaces;
    using Helpers.Views.Interfaces;

    using Web.Controllers;

    #endregion

    /// <summary>
    ///     The <see cref="BudgetController" /> controller handles HTTP requests for the budgeting dashboard.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [RouteArea("Dashboard", AreaPrefix = "dash")]
    [RoutePrefix("budget")]
    [Authorize]
    public class BudgetController : BaseController
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BudgetController" /> class.
        /// </summary>
        /// <param name="errorHelper">The error helper.</param>
        /// <param name="benchmarkHelper">The benchmark helper.</param>
        /// <param name="viewHelper">The view helper.</param>
        public BudgetController(IErrorHelper errorHelper, IBenchmarkHelper benchmarkHelper, IViewHelper viewHelper)
            : base(errorHelper, benchmarkHelper, viewHelper)
        {
        }

        #region Methods

        /// <summary>
        ///     Handles requests for the budget overview view.
        /// </summary>
        /// <returns>The budget overview view.</returns>
        [HttpGet]
        [Route("")]
        public ActionResult BudgetOverview()
        {
            return View();
        }

        /// <summary>
        ///     Returns monthly spending data for charts.
        /// </summary>
        /// <returns>The monthly spending data.</returns>
        public ActionResult MonthlySpending()
        {
            return null;
        }

        #endregion
    }
}