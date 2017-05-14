namespace MyMoney.Web.DataAccess
{
    #region Usings

    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Configuration;

    using DTO.Request;
    using DTO.Response;

    using Helpers.Benchmarking.Interfaces;
    using Helpers.Error.Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     The base class for all data access objects.
    /// </summary>
    [UsedImplicitly]
    public class BaseDataAccess
    {
        #region Fields

        /// <summary>
        ///     The benchmark helper
        /// </summary>
        private readonly IBenchmarkHelper benchmarkHelper;

        /// <summary>
        ///     The client
        /// </summary>
        private readonly HttpClient client;

        /// <summary>
        ///     The error helper.
        /// </summary>
        private readonly IErrorHelper errorHelper;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseDataAccess" /> class.
        /// </summary>
        /// <param name="errorHelper">The error helper.</param>
        /// <param name="benchmarkHelper">The benchmark helper.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     Exception thrown if either of the helpers are null.
        /// </exception>
        protected BaseDataAccess(IErrorHelper errorHelper, IBenchmarkHelper benchmarkHelper)
        {
            if (errorHelper == null)
            {
                throw new ArgumentNullException(nameof(errorHelper));
            }

            this.errorHelper = errorHelper;

            if (benchmarkHelper == null)
            {
                throw new ArgumentNullException(nameof(benchmarkHelper));
            }

            this.benchmarkHelper = benchmarkHelper;

            var context = HttpContext.Current.GetOwinContext();
            var user = context.Authentication.User;
            var claim = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            client = new HttpClient { BaseAddress = new Uri(WebConfigurationManager.AppSettings.Get("ApiUri")) };

            client.DefaultRequestHeaders.Clear();

            if (claim != null)
            {
                client.DefaultRequestHeaders.Add("USER_ID", claim.Value);
            }

            client.DefaultRequestHeaders.Add("API_KEY", WebConfigurationManager.AppSettings.Get("ApiKey"));
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Sends an HTTP DELETE request to the given uri.
        /// </summary>
        /// <typeparam name="T">The response type.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="username">The username.</param>
        /// <returns>The response object.</returns>
        protected async Task<T> Delete<T>(string uri, string username)
            where T : BaseResponse
        {
            var response = (T)Activator.CreateInstance(typeof(T));

            HttpResponseMessage httpResponse;

            using (benchmarkHelper.Create(uri))
            {
                httpResponse = await client.DeleteAsync(uri);
            }

            if (!httpResponse.IsSuccessStatusCode)
            {
                var err = errorHelper.Create(GetHttpError(httpResponse), username, GetType(), "Delete");
                response.AddError(err);

                return response;
            }

            response = await httpResponse.Content.ReadAsAsync<T>();

            return response;
        }

        /// <summary>
        ///     Sends a get request.
        /// </summary>
        /// <typeparam name="T">The response type.</typeparam>
        /// <param name="uri">The request URI.</param>
        /// <param name="username">The username</param>
        /// <returns>The response object.</returns>
        protected async Task<T> Get<T>(string uri, string username)
            where T : BaseResponse
        {
            var response = (T)Activator.CreateInstance(typeof(T));

            HttpResponseMessage httpResponse;

            using (benchmarkHelper.Create(uri))
            {
                httpResponse = await client.GetAsync(uri);
            }

            if (!httpResponse.IsSuccessStatusCode)
            {
                var err = errorHelper.Create(GetHttpError(httpResponse), username, GetType(), "Get");
                response.AddError(err);

                return response;
            }

            response = await httpResponse.Content.ReadAsAsync<T>();

            return response;
        }

        /// <summary>
        ///     Sends a post request.
        /// </summary>
        /// <typeparam name="T">The response type.</typeparam>
        /// <param name="request">The request object.</param>
        /// <returns>The response object.</returns>
        protected async Task<T> Post<T>(BaseRequest request)
            where T : BaseResponse
        {
            var response = (T)Activator.CreateInstance(typeof(T));

            HttpResponseMessage httpResponse;

            using (benchmarkHelper.Create(request.GetAction()))
            {
                httpResponse = await client.PostAsJsonAsync(request.GetAction(), request);
            }

            if (!httpResponse.IsSuccessStatusCode)
            {
                var err = errorHelper.Create(GetHttpError(httpResponse), request.Username, GetType(), "Post");
                response.AddError(err);

                return response;
            }

            response = await httpResponse.Content.ReadAsAsync<T>();

            return response;
        }

        /// <summary>
        ///     Gets the HTTP error from the <see cref="HttpResponseMessage" />.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>The error message.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     Exception thrown if status code is invalid.
        /// </exception>
        private static string GetHttpError(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.Continue: break;
                case HttpStatusCode.SwitchingProtocols: break;
                case HttpStatusCode.OK: break;
                case HttpStatusCode.Created: break;
                case HttpStatusCode.Accepted: break;
                case HttpStatusCode.NonAuthoritativeInformation: break;
                case HttpStatusCode.NoContent: break;
                case HttpStatusCode.ResetContent: break;
                case HttpStatusCode.PartialContent: break;
                case HttpStatusCode.MultipleChoices: break;
                case HttpStatusCode.MovedPermanently: break;
                case HttpStatusCode.Found: break;
                case HttpStatusCode.SeeOther: break;
                case HttpStatusCode.NotModified: break;
                case HttpStatusCode.UseProxy: break;
                case HttpStatusCode.Unused: break;
                case HttpStatusCode.TemporaryRedirect: break;
                case HttpStatusCode.BadRequest: break;
                case HttpStatusCode.Unauthorized: break;
                case HttpStatusCode.PaymentRequired: break;
                case HttpStatusCode.Forbidden: return "You do not have sufficient priviledges to view this content.";
                case HttpStatusCode.NotFound: return "The resource you requested could not be found.";
                case HttpStatusCode.MethodNotAllowed: break;
                case HttpStatusCode.NotAcceptable: break;
                case HttpStatusCode.ProxyAuthenticationRequired: break;
                case HttpStatusCode.RequestTimeout: break;
                case HttpStatusCode.Conflict: break;
                case HttpStatusCode.Gone: break;
                case HttpStatusCode.LengthRequired: break;
                case HttpStatusCode.PreconditionFailed: break;
                case HttpStatusCode.RequestEntityTooLarge: break;
                case HttpStatusCode.RequestUriTooLong: break;
                case HttpStatusCode.UnsupportedMediaType: break;
                case HttpStatusCode.RequestedRangeNotSatisfiable: break;
                case HttpStatusCode.ExpectationFailed: break;
                case HttpStatusCode.UpgradeRequired: break;
                case HttpStatusCode.InternalServerError: return "An internal server error has occurred in the API.";
                case HttpStatusCode.NotImplemented: break;
                case HttpStatusCode.BadGateway: break;
                case HttpStatusCode.ServiceUnavailable: break;
                case HttpStatusCode.GatewayTimeout: break;
                case HttpStatusCode.HttpVersionNotSupported: break;
                default: throw new ArgumentOutOfRangeException();
            }

            return string.Empty;
        }

        #endregion
    }
}