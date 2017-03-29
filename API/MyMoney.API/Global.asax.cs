namespace MyMoney.API
{
    #region Usings

    using System.IO;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Dispatcher;

    using Castle.Windsor;

    using DependencyInjection;

    using JetBrains.Annotations;

    using Plumbing;
    using Plumbing.Installers;

    #endregion

    /// <summary>
    ///     The start up class for the API application.
    /// </summary>
    /// <seealso cref="System.Web.HttpApplication" />
    [UsedImplicitly]
    public class WebApiApplication : HttpApplication
    {
        #region Private Methods

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

            APIContainerConfig.InstallForWebApi(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        #endregion
    }
}