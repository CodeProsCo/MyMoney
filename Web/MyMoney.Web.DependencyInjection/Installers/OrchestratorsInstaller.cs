namespace MyMoney.Web.DependencyInjection.Installers
{
    #region Usings

    using Assemblers.Authentication;
    using Assemblers.Authentication.Interfaces;
    using Assemblers.Chart;
    using Assemblers.Chart.Interfaces;
    using Assemblers.Spending;
    using Assemblers.Spending.Interfaces;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using DataAccess.Authentication;
    using DataAccess.Authentication.Interfaces;
    using DataAccess.Chart;
    using DataAccess.Chart.Interfaces;
    using DataAccess.Spending;
    using DataAccess.Spending.Interfaces;

    using Orchestrators.Authentication;
    using Orchestrators.Authentication.Interfaces;
    using Orchestrators.Chart;
    using Orchestrators.Chart.Interfaces;
    using Orchestrators.Spending;
    using Orchestrators.Spending.Interfaces;

    #endregion

    /// <summary>
    ///     Installs dependencies for orchestrator classes in the web application.
    /// </summary>
    /// <seealso cref="Castle.MicroKernel.Registration.IWindsorInstaller" />
    public class OrchestratorsInstaller : IWindsorInstaller
    {
        #region Methods

        /// <summary>
        ///     Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IUserOrchestrator>()
                    .ImplementedBy<UserOrchestrator>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IUserAssembler, UserAssembler>(),
                        Dependency.OnComponent<IUserDataAccess, UserDataAccess>()));

            container.Register(
                Component.For<IBillOrchestrator>()
                    .ImplementedBy<BillOrchestrator>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IBillAssembler, BillAssembler>(),
                        Dependency.OnComponent<IBillDataAccess, BillDataAccess>()));

            container.Register(
                Component.For<IExpenditureOrchestrator>()
                    .ImplementedBy<ExpenditureOrchestrator>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IExpenditureAssembler, ExpenditureAssembler>(),
                        Dependency.OnComponent<IExpenditureDataAccess, ExpenditureDataAccess>()));

            container.Register(
                Component.For<IChartOrchestrator>()
                    .ImplementedBy<ChartOrchestrator>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IChartAssembler, ChartAssembler>(),
                        Dependency.OnComponent<IChartDataAccess, ChartDataAccess>()));
        }

        #endregion
    }
}