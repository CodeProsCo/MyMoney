namespace MyMoney.Web.Areas.Common.Controllers
{
    #region Usings

    using System.Web.Mvc;

    using Web.Controllers;

    #endregion

    [RouteArea("Common", AreaPrefix = "common")]
    [RoutePrefix("resource")]
    public class ResourceController : BaseController
    {
        #region  Public Methods

        [Route("{nmSpace}/{key}")]
        [HttpGet]

        // [AjaxOnly]
        public ActionResult GetResourceString(string nmSpace, string key)
        {
            var retVal = GetResourceValue(nmSpace, key);

            return Json(retVal, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}