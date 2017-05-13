namespace MyMoney.Web.Controllers
{
    #region Usings

    using System.Web.Mvc;

    using Helpers.Benchmarking.Interfaces;
    using Helpers.Error.Interfaces;
    using Helpers.Views.Interfaces;

    #endregion

    /// <summary>
    ///     The <see cref="HomeController" /> class handles the default route.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Controllers.BaseController" />
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        /// <param name="errorHelper">The error helper.</param>
        /// <param name="benchmarkHelper">The benchmark helper.</param>
        /// <param name="viewHelper">The view helper.</param>
        public HomeController(IErrorHelper errorHelper, IBenchmarkHelper benchmarkHelper, IViewHelper viewHelper)
            : base(errorHelper, benchmarkHelper, viewHelper)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        ///     The main endpoint for the application. Redirects based on authentication.
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