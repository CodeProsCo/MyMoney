using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMoney.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return User.Identity.IsAuthenticated
                       ? RedirectToAction("BudgetOverview", "Budget", new { area = "Dashboard" })
                       : RedirectToAction("Login", "User", new { area = "Authentication" });
        }
    }
}