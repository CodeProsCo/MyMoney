namespace MyMoney.Web.Controllers
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Resources;
    using System.Security.Claims;
    using System.Text;
    using System.Threading;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Helpers.Benchmarking;
    using Helpers.Benchmarking.Interfaces;
    using Helpers.Error.Interfaces;
    using Helpers.Views.Interfaces;

    using Microsoft.Owin.Security;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using Wrappers;

    #endregion

    /// <summary>
    ///     The base controller for the web application.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class BaseController : Controller
    {
        #region Fields

        /// <summary>
        ///     The benchmark helper.
        /// </summary>
        private readonly IBenchmarkHelper benchmarkHelper;

        /// <summary>
        ///     The error helper
        /// </summary>
        private readonly IErrorHelper errorHelper;

        /// <summary>
        ///     The controller benchmark
        /// </summary>
        private Benchmark controllerBenchmark;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseController" /> class.
        /// </summary>
        /// <param name="errorHelper">
        ///     The error helper.
        /// </param>
        /// <param name="benchmarkHelper">
        ///     The benchmark helper.
        /// </param>
        /// <param name="viewHelper">
        ///     The view helper.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Exception thrown if any of the given parameters are null.
        /// </exception>
        public BaseController(IErrorHelper errorHelper, IBenchmarkHelper benchmarkHelper, IViewHelper viewHelper)
        {
            if (errorHelper == null)
            {
                throw new ArgumentNullException(nameof(errorHelper));
            }

            if (benchmarkHelper == null)
            {
                throw new ArgumentNullException(nameof(errorHelper));
            }

            if (viewHelper == null)
            {
                throw new ArgumentNullException(nameof(viewHelper));
            }

            this.errorHelper = errorHelper;
            this.benchmarkHelper = benchmarkHelper;
            ViewHelper = viewHelper;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the user email.
        /// </summary>
        /// <value>
        ///     The user email.
        /// </value>
        protected static string UserEmail => GetUserClaim(ClaimTypes.Email).Value;

        /// <summary>
        ///     Gets the user identifier.
        /// </summary>
        /// <value>
        ///     The user identifier.
        /// </value>
        protected static Guid UserId => Guid.Parse(GetUserClaim(ClaimTypes.NameIdentifier).Value);

        /// <summary>
        /// Gets the view helper.
        /// </summary>
        /// <value>
        /// The view helper.
        /// </value>
        protected IViewHelper ViewHelper { get; }

        #endregion

        #region Methods

        /// <summary>
        ///     Adds errors to the model.
        /// </summary>
        /// <param name="errors">The errors.</param>
        public void AddModelErrors(IEnumerable<ResponseErrorWrapper> errors)
        {
            foreach (var error in errors)
            {
                ModelState.AddModelError(string.Empty, error.Message);
            }
        }

        /// <summary>
        ///     Adds warnings to the model.
        /// </summary>
        /// <param name="warnings">The warnings.</param>
        public void AddModelWarnings(IEnumerable<string> warnings)
        {
            foreach (var warning in warnings)
            {
                ModelState.AddModelError(string.Empty, warning);
            }
        }

        /// <summary>
        ///     Gets the authentication manager.
        /// </summary>
        /// <returns>The authentication manager.</returns>
        public IAuthenticationManager GetAuthenticationManager()
        {
            var context = Request.GetOwinContext();

            return context.Authentication;
        }

        /// <summary>
        ///     Gets the resource value.
        /// </summary>
        /// <param name="nameSpace">The resource namespace.</param>
        /// <param name="key">The key.</param>
        /// <returns>If found, the string. Otherwise an empty string.</returns>
        protected static string GetResourceValue(string nameSpace, string key)
        {
            var assembly = Assembly.Load("MyMoney.Resources");
            var resourceNames = assembly.GetManifestResourceNames();

            foreach (var t in resourceNames)
            {
                if (!t.Contains($"{nameSpace}.resources"))
                {
                    continue;
                }

                var rm = new ResourceManager(t.Substring(0, t.Length - 10), assembly);

                return rm.GetString(key);
            }

            return string.Empty;
        }

        /// <summary>
        ///     Creates a JSON response object based on the given response object.
        /// </summary>
        /// <typeparam name="T">The model type.</typeparam>
        /// <param name="response">The response.</param>
        /// <returns>The JSON response.</returns>
        protected static ContentResult JsonResponse<T>(OrchestratorResponseWrapper<T> response)
        {
            return new ContentResult
                       {
                           ContentType = "application/json",
                           Content = JsonConvert.SerializeObject(
                               response,
                               new JsonSerializerSettings
                                   {
                                       ContractResolver =
                                           new
                                               CamelCasePropertyNamesContractResolver()
                                   }),
                           ContentEncoding = Encoding.UTF8
                       };
        }

        /// <summary>
        ///     Creates an instance of the <see cref="ContentResult" /> class based on the given view data.
        /// </summary>
        /// <param name="viewData">The view data.</param>
        /// <returns>The content result.</returns>
        protected static ContentResult ViewResponse(string viewData)
        {
            return new ContentResult
                       {
                           ContentType = "application/json",
                           Content = JsonConvert.SerializeObject(
                               new { View = viewData, Success = true },
                               new JsonSerializerSettings
                                   {
                                       ContractResolver =
                                           new
                                               CamelCasePropertyNamesContractResolver()
                                   }),
                           ContentEncoding = Encoding.UTF8
                       };
        }

        /// <summary>Begins execution of the specified request context</summary>
        /// <returns>Returns an IAsyncController instance.</returns>
        /// <param name="requestContext">The request context.</param>
        /// <param name="callback">The asynchronous callback.</param>
        /// <param name="state">The state.</param>
        protected override IAsyncResult BeginExecute(
            RequestContext requestContext,
            AsyncCallback callback,
            object state)
        {
            controllerBenchmark = benchmarkHelper.Create(requestContext.HttpContext.Request.RawUrl);

            return base.BeginExecute(requestContext, callback, state);
        }

        /// <summary>Ends the invocation of the action in the current controller context.</summary>
        /// <param name="asyncResult">The asynchronous result.</param>
        protected override void EndExecute(IAsyncResult asyncResult)
        {
            base.EndExecute(asyncResult);

            controllerBenchmark.Dispose();
        }

        /// <summary>
        ///     Adds model state errors to the JSON response.
        /// </summary>
        /// <param name="state">The model state.</param>
        /// <returns>The <see cref="ContentResult" />.</returns>
        protected ContentResult InvalidModelState(ModelStateDictionary state)
        {
            var response = new OrchestratorResponseWrapper<bool>();

            foreach (var modelState in state.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    var errorWrapper = errorHelper.Create(
                        error.ErrorMessage,
                        UserEmail,
                        GetType(),
                        "InvalidModelState");

                    response.AddError(errorWrapper);
                }
            }

            return JsonResponse(response);
        }

        /// <summary>Called when an unhandled exception occurs in the action.</summary>
        /// <param name="filterContext">Information about the current request and action.</param>
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = RedirectToAction("SystemError", "Error", new { area = "Common" });
        }

        /// <summary>
        ///     Gets the given user claim.
        /// </summary>
        /// <param name="type">The claim type.</param>
        /// <returns>The claim</returns>
        private static Claim GetUserClaim(string type)
        {
            // Get the current claims principal
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;

            // Get the claims values
            var value = identity.Claims.FirstOrDefault(c => c.Type == type);

            return value;
        }

        #endregion
    }
}