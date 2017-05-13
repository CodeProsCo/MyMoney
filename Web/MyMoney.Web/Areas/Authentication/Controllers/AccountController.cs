namespace MyMoney.Web.Areas.Authentication.Controllers
{
    #region Usings

    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Attributes;

    using Helpers.Benchmarking.Interfaces;
    using Helpers.Error.Interfaces;
    using Helpers.Views.Interfaces;

    using ViewModels.Authentication.Account;

    using Web.Controllers;

    #endregion

    /// <summary>
    ///     The <see cref="AccountController" /> class handles HTTP requests for performing account actions.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Controllers.BaseController" />
    [RouteArea("Authentication", AreaPrefix = "auth")]
    [RoutePrefix("account")]
    [Authorize]
    public class AccountController : BaseController
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="AccountController" /> class.
        /// </summary>
        /// <param name="errorHelper">The error helper.</param>
        /// <param name="benchmarkHelper">The benchmark helper.</param>
        /// <param name="viewHelper">The view helper.</param>
        public AccountController(IErrorHelper errorHelper, IBenchmarkHelper benchmarkHelper, IViewHelper viewHelper)
            : base(errorHelper, benchmarkHelper, viewHelper)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Handles an HTTP POST request to edit a given account.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The response object.</returns>
        [HttpPost]
        [AjaxOnly]
        [Route("edit/")]
        public Task<ActionResult> EditAccountDetails(AccountDetailsViewModel model)
        {
            return null;
        }

        /// <summary>
        ///     Handles an HTTP POST request to edit the given personal details.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The response object.</returns>
        [HttpPost]
        [AjaxOnly]
        [Route("edit/personal")]
        public Task<ActionResult> EditPersonalDetails(PersonalDetailsViewModel model)
        {
            return null;
        }

        /// <summary>
        ///     Handles an HTTP GET request for the account management view.
        /// </summary>
        /// <returns>The account management view.</returns>
        [HttpGet]
        [Route("manage")]
        public ActionResult Manage()
        {
            var model = new ManageAccountViewModel
                            {
                                AccountDetails =
                                    new AccountDetailsViewModel { EmailAddress = UserEmail },
                                PersonalDetails = new PersonalDetailsViewModel()
                            };

            return View(model);
        }

        #endregion
    }
}