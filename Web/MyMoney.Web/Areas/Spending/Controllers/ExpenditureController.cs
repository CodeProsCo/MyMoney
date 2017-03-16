namespace MyMoney.Web.Areas.Spending.Controllers
{
    #region Usings

    using System.Web.Mvc;

    using Web.Controllers;

    #endregion

    /// <summary>
    ///     The <see cref="ExpenditureController" /> controller handles HTTP requests regarding expenditure.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Controllers.BaseController" />
    [RouteArea("Spending", AreaPrefix = "spending")]
    [RoutePrefix("expenditure")]
    [Authorize]
    public class ExpenditureController : BaseController
    {
        /// <summary>
        /// Returns the "Track Expenditure" view.
        /// </summary>
        /// <returns>The view.</returns>
        [Route("track")]
        [HttpGet]
        public ActionResult Track()
        {
            return View();
        }
    }
}