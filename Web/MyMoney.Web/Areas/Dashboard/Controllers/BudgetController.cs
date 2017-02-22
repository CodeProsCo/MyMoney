namespace MyMoney.Web.Areas.Dashboard.Controllers
{
    #region Usings

    using System.Web.Mvc;

    #endregion

    [RouteArea("Dashboard", AreaPrefix = "dash")]
    [RoutePrefix("budget")]
    [Authorize]
    public class BudgetController : Controller
    {
        #region  Public Methods

        [HttpGet]
        [Route("")]
        public ActionResult BudgetOverview()
        {
            return View();
        }

        #endregion
    }
}