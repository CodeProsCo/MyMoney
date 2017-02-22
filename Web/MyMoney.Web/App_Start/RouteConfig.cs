namespace MyMoney.Web
{
    #region Usings

    using System.Web.Mvc;
    using System.Web.Routing;

    #endregion

    /// <summary>
    ///     The routing configuration for the web application.
    /// </summary>
    public static class RouteConfig
    {
        #region  Public Methods

        /// <summary>
        ///     Registers the routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            var route = routes.MapRoute(
                "Default", 
                "{area}/{controller}/{action}/{id}", 
                new { controller = "User", action = "Login", id = UrlParameter.Optional });

            route.DataTokens["area"] = "Authentication";

            routes.LowercaseUrls = true;
        }

        #endregion
    }
}