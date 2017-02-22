namespace MyMoney.DependencyInjection.API.Installers
{
    #region Usings

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using MyMoney.API.Assemblers.Authentication;
    using MyMoney.API.Assemblers.Authentication.Interfaces;
    using MyMoney.API.DataAccess.Authentication;
    using MyMoney.API.DataAccess.Authentication.Interfaces;
    using MyMoney.API.Orchestrators.Authentication;
    using MyMoney.API.Orchestrators.Authentication.Interfaces;
    using MyMoney.API.Orchestrators.Spending;
    using MyMoney.API.Orchestrators.Spending.Interfaces;

    #endregion

    /// <summary>
    ///     Installs dependencies for orchestrator classes in the API application.
    /// </summary>
    /// <seealso cref="Castle.MicroKernel.Registration.IWindsorInstaller" />
    public class OrchestratorsInstaller : IWindsorInstaller
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
                Component.For<IUserOrchestrator>()
                    .ImplementedBy<UserOrchestrator>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IUserAssembler, UserAssembler>(), 
                        Dependency.OnComponent<IUserRepository, UserRepository>()));

            container.Register(Component.For<IBillOrchestrator>().ImplementedBy<BillOrchestrator>());
        }

        #endregion
    }
}