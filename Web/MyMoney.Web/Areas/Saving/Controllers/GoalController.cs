namespace MyMoney.Web.Areas.Saving.Controllers
{
    #region Usings

    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using MyMoney.Web.Controllers;

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
            try
            {
                return View("Manage");
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        #endregion
    }
}