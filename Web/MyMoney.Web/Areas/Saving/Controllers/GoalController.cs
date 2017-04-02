using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMoney.Web.Areas.Saving.Controllers
{
    using System.Threading.Tasks;

    [RouteArea("Saving", AreaPrefix = "savings")]
    [RoutePrefix("goals")]
    [Authorize]
    public class GoalController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult> Manage()
        {
            return View();
        }


    }
}