namespace MyMoney.API.DependencyInjection.Installers
{
    #region Usings

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using MyMoney.API.Assemblers.Authentication;
    using MyMoney.API.Assemblers.Authentication.Interfaces;
    using MyMoney.API.Assemblers.Chart;
    using MyMoney.API.Assemblers.Chart.Interfaces;
    using MyMoney.API.Assemblers.Spending;
    using MyMoney.API.Assemblers.Spending.Interfaces;
    using MyMoney.API.DataAccess.Authentication;
    using MyMoney.API.DataAccess.Authentication.Interfaces;
    using MyMoney.API.DataAccess.Spending;
    using MyMoney.API.DataAccess.Spending.Interfaces;
    using MyMoney.API.DataTransformers.Spending;
    using MyMoney.API.DataTransformers.Spending.Interfaces;
    using MyMoney.API.Orchestrators.Authentication;
    using MyMoney.API.Orchestrators.Authentication.Interfaces;
    using MyMoney.API.Orchestrators.Chart;
    using MyMoney.API.Orchestrators.Chart.Interfaces;
    using MyMoney.API.Orchestrators.Spending;
    using MyMoney.API.Orchestrators.Spending.Interfaces;

    #endregion

    /// <summary>
    ///     Installs dependencies for orchestrator classes in the API application.
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
                        Dependency.OnComponent<IUserRepository, UserRepository>()));

            container.Register(
                Component.For<IBillOrchestrator>()
                    .ImplementedBy<BillOrchestrator>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IBillAssembler, BillAssembler>(),
                        Dependency.OnComponent<IBillRepository, BillRepository>(),
                        Dependency.OnComponent<IBillDataTransformer, BillDataTransformer>()));

            container.Register(
                Component.For<IChartOrchestrator>()
                    .ImplementedBy<ChartOrchestrator>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IBillDataTransformer, BillDataTransformer>(),
                        Dependency.OnComponent<IBillRepository, BillRepository>(),
                        Dependency.OnComponent<IChartAssembler, ChartAssembler>(),
                        Dependency.OnComponent<IExpenditureRepository, ExpenditureRepository>(),
                        Dependency.OnComponent<IExpenditureDataTransformer, ExpenditureDataTransformer>()));

            container.Register(
                Component.For<IExpenditureOrchestrator>()
                    .ImplementedBy<ExpenditureOrchestrator>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IExpenditureRepository, ExpenditureRepository>(),
                        Dependency.OnComponent<IExpenditureAssembler, ExpenditureAssembler>()));
        }

        #endregion
    }
}