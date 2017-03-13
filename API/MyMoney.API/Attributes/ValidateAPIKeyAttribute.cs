namespace MyMoney.API.Attributes
{
    #region Usings

    using System;
    using System.Linq;
    using System.Web.Configuration;
    using System.Web.Http;
    using System.Web.Http.Controllers;

    #endregion

    /// <summary>
    ///     The <see cref="ValidateAPIKeyAttribute" /> attribute ensures that an authorized request contains an API key that
    ///     matches the one stored on the server.
    /// </summary>
    /// <seealso cref="System.Web.Http.AuthorizeAttribute" />
    public class ValidateAPIKeyAttribute : AuthorizeAttribute
    {
        #region Private Methods

        /// <summary>Indicates whether the specified control is authorized.</summary>
        /// <returns>true if the control is authorized; otherwise, false.</returns>
        /// <param name="actionContext">The context.</param>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var givenKey = actionContext.Request.Headers.FirstOrDefault(x => x.Key == "API_KEY");
            var apiKey = WebConfigurationManager.AppSettings.Get("ApiKey");

            if (!givenKey.Value.Any())
            {
                return false;
            }

            if (string.IsNullOrEmpty(apiKey))
            {
                return false;
            }

            Guid givenGuid;
            Guid apiGuid;

            if (!Guid.TryParse(givenKey.Value.First(), out givenGuid))
            {
                return false;
            }

            return Guid.TryParse(apiKey, out apiGuid) && givenGuid.Equals(apiGuid);
        }

        #endregion
    }
}