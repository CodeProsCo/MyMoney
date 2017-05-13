namespace MyMoney.Web
{
    #region Usings

    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Castle.Windsor;

    using DependencyInjection;

    using Helpers.Error;
    using Helpers.Error.Interfaces;
    using Helpers.Logging;
    using Helpers.Logging.Interfaces;

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
        #region Fields

        /// <summary>
        ///     The error helper
        /// </summary>
        private readonly IErrorHelper errorHelper;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="MvcApplication" /> class.
        /// </summary>
        public MvcApplication()
        {
            ILogHelper logHelper = new LogHelper();

            errorHelper = new ErrorHelper(logHelper);
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Handles the Error event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError();

            var userId = ((ClaimsIdentity)User.Identity).Claims
                .FirstOrDefault(c => c.Type.Equals(ClaimTypes.Email))
                ?.Value;

            errorHelper.Create(error, userId, GetType(), "Application_Error");

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