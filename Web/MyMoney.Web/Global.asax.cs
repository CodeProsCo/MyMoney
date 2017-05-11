namespace MyMoney.Web
{
    #region Usings

    using System;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Castle.Windsor;

    using DependencyInjection;

    using Helpers.Error;

    using JetBrains.Annotations;

    using Newtonsoft.Json.Serialization;

    using Plumbing;
    using Plumbing.Installers;

    #endregion

    /// <summary>
    ///     The start up class for the web application.
    /// </summary>
    /// <seealso cref="System.Web.HttpApplication" />
    [UsedImplicitly]
    public class MvcApplication : HttpApplication
    {
        #region Methods

        /// <summary>
        ///     Handles the Error event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            HttpContext.Current.Response.RedirectToRoute(
                new { action = "SystemError", controller = "Error", area = "Common" });
        }

        /// <summary>
        ///     Starts the application.
        /// </summary>
        protected void Application_Start()
        {
            var container = new WindsorContainer();
            var castleControllerFactory = new WindsorControllerFactory(container);

            WebContainerConfig.InstallForWebApplication(container);
            ControllerBuilder.Current.SetControllerFactory(castleControllerFactory);

            container.Install(new ControllersInstaller());

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        #endregion
    }
}