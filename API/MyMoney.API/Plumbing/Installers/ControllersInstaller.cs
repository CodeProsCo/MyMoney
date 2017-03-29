namespace MyMoney.API.Plumbing.Installers
{
    #region Usings

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Controllers.Authentication;
    using Controllers.Chart;
    using Controllers.Spending;

    using Orchestrators.Authentication;
    using Orchestrators.Authentication.Interfaces;
    using Orchestrators.Chart;
    using Orchestrators.Chart.Interfaces;
    using Orchestrators.Spending;
    using Orchestrators.Spending.Interfaces;

    #endregion

    /// <summary>
    ///     The dependency installer for API controllers.
    /// </summary>
    /// <seealso cref="Castle.MicroKernel.Registration.IWindsorInstaller" />
    public class ControllersInstaller : IWindsorInstaller
    {
        #region  Public Methods

        /// <summary>
        ///     Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<UserController>()
                    .LifestylePerWebRequest()
                    .DependsOn(Dependency.OnComponent<IUserOrchestrator, UserOrchestrator>()));

            container.Register(
                Component.For<BillController>()
                    .LifestylePerWebRequest()
                    .DependsOn(Dependency.OnComponent<IBillOrchestrator, BillOrchestrator>()));

            container.Register(
                Component.For<BillChartController>()
                    .LifestylePerWebRequest()
                    .DependsOn(Dependency.OnComponent<IChartOrchestrator, ChartOrchestrator>()));

            container.Register(
                Component.For<ExpenditureChartController>()
                    .LifestylePerWebRequest()
                    .DependsOn(Dependency.OnComponent<IChartOrchestrator, ChartOrchestrator>()));

            container.Register(
                Component.For<ExpenditureController>()
                    .LifestylePerWebRequest()
                    .DependsOn(Dependency.OnComponent<IExpenditureOrchestrator, ExpenditureOrchestrator>()));
        }

        #endregion
    }
}