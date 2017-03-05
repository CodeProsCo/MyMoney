namespace MyMoney.Web.Areas.Dashboard.Controllers
{
    #region Usings

    using System.Web.Mvc;

    #endregion

    /// <summary>
    /// The <see cref="BudgetController"/> controller handles HTTP requests for the budgeting dashboard.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [RouteArea("Dashboard", AreaPrefix = "dash")]
    [RoutePrefix("budget")]
    [Authorize]
    public class BudgetController : Controller
    {
        #region  Public Methods

        /// <summary>
        /// Handles requests for the budget overview view.
        /// </summary>
        /// <returns>The budget overview view.</returns>
        [HttpGet]
        [Route("")]
        public ActionResult BudgetOverview()
        {
            return View();
        }

        #endregion

        /// <summary>
        /// Returns monthly spending data for charts.
        /// </summary>
        /// <returns>The monthly spending data.</returns>
        public ActionResult MonthlySpending()
        {
            return null;
        }
    }
}