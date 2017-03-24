namespace MyMoney.Web.Areas.Authentication.Controllers
{
    #region Usings

    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Attributes;

    using ViewModels.Authentication.Account;

    using Web.Controllers;

    #endregion

    [RouteArea("Authentication", AreaPrefix = "auth")]
    [RoutePrefix("account")]
    [Authorize]
    public class AccountController : BaseController
    {
        [HttpGet]
        [Route("manage")]
        public ActionResult Manage()
        {
            var model = new ManageAccountViewModel
            {
                AccountDetails = new AccountDetailsViewModel
                {
                    EmailAddress = UserEmail
                },
                PersonalDetails = new PersonalDetailsViewModel()
            };

            return View(model);
        }

        [HttpPost]
        [AjaxOnly]
        [Route("edit/personal")]
        public async Task<ActionResult> EditPersonalDetails(PersonalDetailsViewModel model)
        {
            return null;
        }

        [HttpPost]
        [AjaxOnly]
        [Route("edit/")]
        public async Task<ActionResult> EditAccountDetails(AccountDetailsViewModel model)
        {
            return null;
        }
    }
}