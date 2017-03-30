namespace MyMoney.Web.DependencyInjection.Installers
{
    #region Usings

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using MyMoney.Web.Assemblers.Authentication;
    using MyMoney.Web.Assemblers.Authentication.Interfaces;
    using MyMoney.Web.Assemblers.Chart;
    using MyMoney.Web.Assemblers.Chart.Interfaces;
    using MyMoney.Web.Assemblers.Spending;
    using MyMoney.Web.Assemblers.Spending.Interfaces;
    using MyMoney.Web.DataAccess.Authentication;
    using MyMoney.Web.DataAccess.Authentication.Interfaces;
    using MyMoney.Web.DataAccess.Chart;
    using MyMoney.Web.DataAccess.Chart.Interfaces;
    using MyMoney.Web.DataAccess.Spending;
    using MyMoney.Web.DataAccess.Spending.Interfaces;
    using MyMoney.Web.Orchestrators.Authentication;
    using MyMoney.Web.Orchestrators.Authentication.Interfaces;
    using MyMoney.Web.Orchestrators.Chart;
    using MyMoney.Web.Orchestrators.Chart.Interfaces;
    using MyMoney.Web.Orchestrators.Spending;
    using MyMoney.Web.Orchestrators.Spending.Interfaces;

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