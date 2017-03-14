namespace MyMoney.Web.Controllers
{
    #region Usings

    using System.Web.Mvc;

    #endregion

    /// <summary>
    /// The <see cref="HomeController"/> class handles the default route.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Controllers.BaseController" />
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        #region  Public Methods

        /// <summary>
        /// The main endpoint for the application. Redirects based on authentication.
        /// </summary>
        /// <returns>If authenticated, the budget dashboard. Otherwise, returns to the login screen.</returns>
        [AllowAnonymous]
        public ActionResult Index()
        {
            return User.Identity.IsAuthenticated
                       ? RedirectToAction("BudgetOverview", "Budget", new { area = "Dashboard" })
                       : RedirectToAction("Login", "User", new { area = "Authentication" });
        }

        #endregion
    }
}