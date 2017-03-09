namespace MyMoney.Web.Areas.Common.Controllers
{
    #region Usings

    using System.Web.Mvc;

    using Attributes;

    using Web.Controllers;

    #endregion

    /// <summary>
    ///     The <see cref="ResourceController" /> handles HTTP requests for resources such as localized strings.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Controllers.BaseController" />
    [RouteArea("Common", AreaPrefix = "common")]
    [RoutePrefix("resource")]
    public class ResourceController : BaseController
    {
        #region  Public Methods

        /// <summary>
        ///     Gets the resource string.
        /// </summary>
        /// <param name="nameSpace">The resource file's namespace.</param>
        /// <param name="key">The resource key.</param>
        /// <returns>If existing, the resource string.</returns>
        [Route("{nameSpace}/{key}")]
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetResourceString(string nameSpace, string key)
        {
            var retVal = GetResourceValue(nameSpace, key);

            return Json(retVal, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}