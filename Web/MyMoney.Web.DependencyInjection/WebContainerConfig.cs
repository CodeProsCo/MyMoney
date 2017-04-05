namespace MyMoney.Web.DependencyInjection
{
    #region Usings

    using Castle.Windsor;

    using Installers;

    #endregion

    /// <summary>
    ///     Configures the castle windsor container for both web and API applications.
    /// </summary>
    public static class WebContainerConfig
    {
        #region Methods

        /// <summary>
        ///     Installs dependencies for the web application.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void InstallForWebApplication(IWindsorContainer container)
        {
            container.Install(new OrchestratorsInstaller());
            container.Install(new AssemblersInstaller());
            container.Install(new DataAccessInstaller());
        }

        #endregion
    }
}