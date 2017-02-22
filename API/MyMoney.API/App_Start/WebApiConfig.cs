namespace MyMoney.API
{
    #region Usings

    using System.Web.Http;

    #endregion

    /// <summary>
    ///     The configuration class for the web API.
    /// </summary>
    public static class WebApiConfig
    {
        #region  Public Methods

        /// <summary>
        ///     Registers routes to specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
        }

        #endregion
    }
}