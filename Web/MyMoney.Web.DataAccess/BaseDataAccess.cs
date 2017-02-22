namespace MyMoney.Web.DataAccess
{
    #region Usings

    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Configuration;

    using DTO.Request;
    using DTO.Response;

    #endregion

    /// <summary>
    /// The base class for all data access objects.
    /// </summary>
    public class BaseDataAccess
    {
        #region Fields

        /// <summary>
        /// The client
        /// </summary>
        private readonly HttpClient client;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDataAccess"/> class.
        /// </summary>
        protected BaseDataAccess()
        {
            client = new HttpClient { BaseAddress = new Uri(WebConfigurationManager.AppSettings.Get("ApiUri")) };
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sends a get request.
        /// </summary>
        /// <typeparam name="T">The response type.</typeparam>
        /// <param name="uri">The request URI.</param>
        /// <returns>The response object.</returns>
        protected async Task<T> Get<T>(string uri) where T : BaseResponse
        {
            var response = (T)Activator.CreateInstance(typeof(T));

            var httpResponse = await client.GetAsync(uri);

            if (!httpResponse.IsSuccessStatusCode)
            {
                response.AddError(GetHttpError(httpResponse));
                return response;
            }

            response = await httpResponse.Content.ReadAsAsync<T>();

            return response;
        }

        /// <summary>
        /// Sends a post request.
        /// </summary>
        /// <typeparam name="T">The response type.</typeparam>
        /// <param name="request">The request object.</param>
        /// <returns>The response object.</returns>
        protected async Task<T> Post<T>(BaseRequest request) where T : BaseResponse
        {
            var response = (T)Activator.CreateInstance(typeof(T));

            var httpResponse = await client.PostAsJsonAsync(request.GetAction(), request);

            if (!httpResponse.IsSuccessStatusCode)
            {
                response.AddError(GetHttpError(httpResponse));
                return response;
            }

            response = await httpResponse.Content.ReadAsAsync<T>();

            return response;
        }

        /// <summary>
        /// Gets the HTTP error from the <see cref="HttpResponseMessage"/>.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>The error message.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Exception thrown if status code is invalid.
        /// </exception>
        private static string GetHttpError(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.Continue:
                    break;
                case HttpStatusCode.SwitchingProtocols:
                    break;
                case HttpStatusCode.OK:
                    break;
                case HttpStatusCode.Created:
                    break;
                case HttpStatusCode.Accepted:
                    break;
                case HttpStatusCode.NonAuthoritativeInformation:
                    break;
                case HttpStatusCode.NoContent:
                    break;
                case HttpStatusCode.ResetContent:
                    break;
                case HttpStatusCode.PartialContent:
                    break;
                case HttpStatusCode.MultipleChoices:
                    break;
                case HttpStatusCode.MovedPermanently:
                    break;
                case HttpStatusCode.Found:
                    break;
                case HttpStatusCode.SeeOther:
                    break;
                case HttpStatusCode.NotModified:
                    break;
                case HttpStatusCode.UseProxy:
                    break;
                case HttpStatusCode.Unused:
                    break;
                case HttpStatusCode.TemporaryRedirect:
                    break;
                case HttpStatusCode.BadRequest:
                    break;
                case HttpStatusCode.Unauthorized:
                    break;
                case HttpStatusCode.PaymentRequired:
                    break;
                case HttpStatusCode.Forbidden:
                    return "You do not have sufficient priviledges to view this content.";
                case HttpStatusCode.NotFound:
                    return "The resource you requested could not be found.";
                case HttpStatusCode.MethodNotAllowed:
                    break;
                case HttpStatusCode.NotAcceptable:
                    break;
                case HttpStatusCode.ProxyAuthenticationRequired:
                    break;
                case HttpStatusCode.RequestTimeout:
                    break;
                case HttpStatusCode.Conflict:
                    break;
                case HttpStatusCode.Gone:
                    break;
                case HttpStatusCode.LengthRequired:
                    break;
                case HttpStatusCode.PreconditionFailed:
                    break;
                case HttpStatusCode.RequestEntityTooLarge:
                    break;
                case HttpStatusCode.RequestUriTooLong:
                    break;
                case HttpStatusCode.UnsupportedMediaType:
                    break;
                case HttpStatusCode.RequestedRangeNotSatisfiable:
                    break;
                case HttpStatusCode.ExpectationFailed:
                    break;
                case HttpStatusCode.UpgradeRequired:
                    break;
                case HttpStatusCode.InternalServerError:
                    break;
                case HttpStatusCode.NotImplemented:
                    break;
                case HttpStatusCode.BadGateway:
                    break;
                case HttpStatusCode.ServiceUnavailable:
                    break;
                case HttpStatusCode.GatewayTimeout:
                    break;
                case HttpStatusCode.HttpVersionNotSupported:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return string.Empty;
        }

        #endregion
    }
}