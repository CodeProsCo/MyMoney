using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMoney.Web.Areas.Common.Controllers
{
    using Web.Controllers;
    [RouteArea("Common", AreaPrefix = "common")]
    [RoutePrefix("error")]
    public class ErrorController : BaseController
    {
        [Route("system")]
        [HttpGet]
        public ActionResult SystemError()
        {
            return View();
        }
    }
}