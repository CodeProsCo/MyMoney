namespace MyMoney.Web.Areas.Authentication.Controllers
{
    #region Usings

    using System.Web.Mvc;

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
    }
}