namespace MyMoney.Web.Areas.Common.Controllers
{
    #region Usings

    using System.Web.Mvc;

    using Helpers.Benchmarking.Interfaces;
    using Helpers.Error.Interfaces;
    using Helpers.Views.Interfaces;

    using Web.Controllers;

    #endregion

    /// <summary>
    ///     The <see cref="ErrorController" /> class handles various error pages.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Controllers.BaseController" />
    [RouteArea("Common", AreaPrefix = "common")]
    [RoutePrefix("error")]
    [AllowAnonymous]
    public class ErrorController : BaseController
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="ErrorController" /> class.
        /// </summary>
        /// <param name="errorHelper">The error helper.</param>
        /// <param name="benchmarkHelper">The benchmark helper.</param>
        /// <param name="viewHelper">The view helper.</param>
        public ErrorController(IErrorHelper errorHelper, IBenchmarkHelper benchmarkHelper, IViewHelper viewHelper)
            : base(errorHelper, benchmarkHelper, viewHelper)
        {
        }

        #endregion

        #region Methods

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