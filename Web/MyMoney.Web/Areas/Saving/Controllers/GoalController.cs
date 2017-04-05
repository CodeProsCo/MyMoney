namespace MyMoney.Web.Areas.Saving.Controllers
{
    #region Usings

    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Web.Controllers;

    #endregion

    [RouteArea("Saving", AreaPrefix = "savings")]
    [RoutePrefix("goals")]
    [Authorize]
    public class GoalController : BaseController
    {
        #region Methods

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> Manage()
        {
            return View("Manage");
        }

        #endregion
    }
}