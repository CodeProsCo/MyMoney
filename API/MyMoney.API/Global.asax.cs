namespace MyMoney.API
{
    #region Usings

    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Dispatcher;

    using Castle.Windsor;

    using JetBrains.Annotations;

    using MyMoney.API.DependencyInjection;
    using MyMoney.API.Plumbing;
    using MyMoney.API.Plumbing.Installers;

    #endregion

    /// <summary>
    ///     The start up class for the API application.
    /// </summary>
    /// <seealso cref="System.Web.HttpApplication" />
    [UsedImplicitly]
    public class WebApiApplication : HttpApplication
    {
        #region Methods

        /// <summary>
        ///     Starts the application.
        /// </summary>
        protected void Application_Start()
        {
            var container = new WindsorContainer();

            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new WindsorWebApiControllerActivator(container));

            container.Install(new ControllersInstaller());

            ApiContainerConfig.InstallForWebApi(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        #endregion
    }
}