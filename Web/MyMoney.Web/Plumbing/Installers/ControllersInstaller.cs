namespace MyMoney.Web.Plumbing.Installers
{
    #region Usings

    using Areas.Authentication.Controllers;
    using Areas.Common.Controllers;
    using Areas.Dashboard.Controllers;
    using Areas.Spending.Controllers;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Orchestrators.Authentication;
    using Orchestrators.Authentication.Interfaces;
    using Orchestrators.Spending;
    using Orchestrators.Spending.Interfaces;

    #endregion

    /// <summary>
    ///     The castle windsor installer for web application controllers.
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

            container.Register(Component.For<BudgetController>().LifestylePerWebRequest());

            container.Register(
                Component.For<BillController>()
                    .LifestylePerWebRequest()
                    .DependsOn(Dependency.OnComponent<IBillOrchestrator, BillOrchestrator>()));

            container.Register(Component.For<ResourceController>().LifestylePerWebRequest());
        }

        #endregion
    }
}