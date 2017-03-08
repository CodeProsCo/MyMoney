namespace MyMoney.API.DependencyInjection
{
    #region Usings

    using Castle.Windsor;

    using Installers;

    #endregion

    /// <summary>
    ///     Configures the castle windsor container for both web and API applications.
    /// </summary>
    public static class APIContainerConfig
    {
        #region  Public Methods

        /// <summary>
        ///     Installs dependencies for the web API.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void InstallForWebApi(IWindsorContainer container)
        {
            container.Install(new OrchestratorsInstaller());
            container.Install(new AssemblersInstaller());
            container.Install(new DataAccessInstaller());
            container.Install(new DataTransformersInstaller());
        }

        #endregion
    }
}