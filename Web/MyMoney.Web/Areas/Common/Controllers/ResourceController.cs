namespace MyMoney.Web.Areas.Common.Controllers
{
    #region Usings

    using System.Web.Mvc;

    using Attributes;

    using Helpers.Benchmarking.Interfaces;
    using Helpers.Error.Interfaces;
    using Helpers.Views.Interfaces;

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
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="ResourceController" /> class.
        /// </summary>
        /// <param name="errorHelper">The error helper.</param>
        /// <param name="benchmarkHelper">The benchmark helper.</param>
        /// <param name="viewHelper">The view helper.</param>
        public ResourceController(IErrorHelper errorHelper, IBenchmarkHelper benchmarkHelper, IViewHelper viewHelper)
            : base(errorHelper, benchmarkHelper, viewHelper)
        {
        }

        #endregion

        #region Methods

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