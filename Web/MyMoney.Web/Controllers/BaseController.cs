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

    using Microsoft.Owin.Security;

    using MyMoney.Helpers.Benchmarking;
    using MyMoney.Helpers.Error;
    using MyMoney.Wrappers;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    #endregion

    /// <summary>
    ///     The base controller for the web application.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class BaseController : Controller
    {
        #region Fields

        /// <summary>
        /// The controller benchmark
        /// </summary>
        private Benchmark controllerBenchmark;

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
        /// Gets the resource value.
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
        /// Creates a JSON response object based on the given response object.
        /// </summary>
        /// <typeparam name="T">The model type.</typeparam>
        /// <param name="response">The response.</param>
        /// <returns>The JSON response.</returns>
        protected static ContentResult JsonResponse<T>(OrchestratorResponseWrapper<T> response)
        {
            return new ContentResult
                       {
                           ContentType = "application/json",
                           Content =
                               JsonConvert.SerializeObject(
                                   response,
                                   new JsonSerializerSettings
                                       {
                                           ContractResolver =
                                               new CamelCasePropertyNamesContractResolver()
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
            controllerBenchmark = BenchmarkHelper.Create(requestContext.HttpContext.Request.RawUrl);

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
                    var errorWrapper = ErrorHelper.Create(error.ErrorMessage, UserEmail, GetType(), "InvalidModelState");

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