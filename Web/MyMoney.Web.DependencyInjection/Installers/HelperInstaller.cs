namespace MyMoney.Web.DependencyInjection.Installers
{
    #region Usings

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Helpers.Benchmarking;
    using Helpers.Benchmarking.Interfaces;
    using Helpers.Error;
    using Helpers.Error.Interfaces;
    using Helpers.Logging;
    using Helpers.Logging.Interfaces;
    using Helpers.Views;
    using Helpers.Views.Interfaces;

    #endregion

    /// <summary>
    ///     The castle windsor installer for web application helpers.
    /// </summary>
    /// <seealso cref="Castle.MicroKernel.Registration.IWindsorInstaller" />
    public class HelperInstaller : IWindsorInstaller
    {
        #region Methods

        /// <summary>
        ///     Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ILogHelper>().ImplementedBy<LogHelper>().LifestylePerWebRequest());

            container.Register(
                Component.For<IErrorHelper>()
                    .ImplementedBy<ErrorHelper>()
                    .LifestylePerWebRequest()
                    .DependsOn(Dependency.OnComponent<ILogHelper, LogHelper>()));

            container.Register(Component.For<IViewHelper>().ImplementedBy<ViewHelper>().LifestylePerWebRequest());

            container.Register(
                Component.For<IBenchmarkHelper>().ImplementedBy<BenchmarkHelper>().LifestylePerWebRequest());
        }

        #endregion
    }
}
