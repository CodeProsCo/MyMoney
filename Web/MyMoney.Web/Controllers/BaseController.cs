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

    using Helpers.Error;
    using Helpers.Network;

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
        #region  Properties

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

        #region  Public Methods

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

        #endregion

        #region Private Methods

        protected static string GetResourceValue(string nmSpace, string key)
        {
            var assembly = Assembly.Load("MyMoney.Resources");
            var resourceNames = assembly.GetManifestResourceNames();

            foreach (var t in resourceNames)
            {
                if (!t.Contains($"{nmSpace}.resources"))
                {
                    continue;
                }

                var rm = new ResourceManager(t.Substring(0, t.Length - 10), assembly);

                return rm.GetString(key);
            }

            return string.Empty;
        }

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
                                               new CamelCasePropertyNamesContractResolver
                                               ()
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
            using (BenchmarkHelper.Create(requestContext.HttpContext.Request.RawUrl))
            {
                return base.BeginExecute(requestContext, callback, state);
            }
        }

        /// <summary>
        /// Adds model state errors to the JSON response.
        /// </summary>
        /// <param name="state">The model state.</param>
        /// <returns>The <see cref="ContentResult"/>.</returns>
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

        /// <summary>
        /// Gets the given user claim.
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