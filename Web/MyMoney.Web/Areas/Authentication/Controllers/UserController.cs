namespace MyMoney.Web.Areas.Authentication.Controllers
{
    #region Usings

    using System;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;

    using Orchestrators.Authentication.Interfaces;

    using ViewModels.Authentication.User;

    using Web.Controllers;

    #endregion

    /// <summary>
    ///     The <see cref="UserController" /> handles requests regarding user authentication.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [RouteArea("Authentication", AreaPrefix = "auth")]
    [RoutePrefix("user")]
    [Authorize]
    public class UserController : BaseController
    {
        #region Fields

        /// <summary>
        ///     The user orchestrator
        /// </summary>
        private readonly IUserOrchestrator orchestrator;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserController" /> class.
        /// </summary>
        /// <param name="orchestrator">
        ///     The orchestrator.
        /// </param>
        public UserController(IUserOrchestrator orchestrator)
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
        ///     Handles a request for the login view.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>If not logged in, the login view. If logged in, the main dashboard.</returns>
        [Route("login")]
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("BudgetOverview", "Budget", new { area = "Dashboard" });
            }

            return View("Login", new LoginViewModel { ReturnUrl = returnUrl });
        }

        /// <summary>
        ///     Handles a user logging in.
        /// </summary>
        /// <param name="model">The log in model.</param>
        /// <returns>If successful, the dashboard. Otherwise, return to log in page with errors.</returns>
        [Route("login")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var loginResponse = await orchestrator.ValidateUser(model);

            if (!loginResponse.Success)
            {
                AddModelErrors(loginResponse.Errors);

                return View(model);
            }

            var authManager = GetAuthenticationManager();

            authManager.SignIn(loginResponse.Model);
            authManager.SignOut("ApplicationCookie");
            authManager.SignIn(loginResponse.Model);

            if (string.IsNullOrEmpty(model.ReturnUrl))
            {
                return RedirectToAction("BudgetOverview", "Budget", new { area = "Dashboard" });
            }

            return Redirect(model.ReturnUrl);
        }

        /// <summary>
        ///     Logs a user out.
        /// </summary>
        /// <returns>The log in view.</returns>
        [Route("logout")]
        [HttpGet]
        public ActionResult LogOut()
        {
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;

            authManager.SignOut("ApplicationCookie");

            return RedirectToAction("Login");
        }

        /// <summary>
        ///     Handles a request for the register view
        /// </summary>
        /// <returns>If logged in, the main dashboard. If not, the register view.</returns>
        [Route("register")]
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("BudgetOverview", "Budget", new { area = "Dashboard" });
            }

            return View("Register");
        }

        /// <summary>
        ///     Handles a registration request from a user.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>If the user is registered, the main dashboard. If not, the register view with errors.</returns>
        [Route("register")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var registerResponse = await orchestrator.RegisterUser(model);

            if (registerResponse.Success)
            {
                return RedirectToAction("BudgetOverview", "Budget", new { area = "Dashboard" });
            }

            AddModelErrors(registerResponse.Errors);

            return View(model);
        }

        #endregion
    }
}