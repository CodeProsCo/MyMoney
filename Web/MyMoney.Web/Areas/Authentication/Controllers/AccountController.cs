namespace MyMoney.Web.Areas.Authentication.Controllers
{
    #region Usings

    using System.Web.Mvc;

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
            return View();
        }
    }
}