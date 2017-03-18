namespace MyMoney.Web.Areas.Common.Controllers
{
    #region Usings

    using System.Web.Mvc;

    using Web.Controllers;

    #endregion

    /// <summary>
    ///     The <see cref="ErrorController" /> class handles various error pages.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Controllers.BaseController" />
    [RouteArea("Common", AreaPrefix = "common")]
    [RoutePrefix("error")]
    public class ErrorController : BaseController
    {
        #region  Public Methods

        /// <summary>
        ///     The error page shown when a system error occurs.
        /// </summary>
        /// <returns>The system error page.</returns>
        [Route("system")]
        [HttpGet]
        public ActionResult SystemError()
        {
            return View();
        }

        #endregion
    }
}