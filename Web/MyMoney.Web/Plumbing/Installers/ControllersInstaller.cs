namespace MyMoney.Web.Plumbing.Installers
{
    #region Usings

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using MyMoney.Web.Areas.Authentication.Controllers;
    using MyMoney.Web.Areas.Common.Controllers;
    using MyMoney.Web.Areas.Dashboard.Controllers;
    using MyMoney.Web.Areas.Saving.Controllers;
    using MyMoney.Web.Areas.Spending.Controllers;
    using MyMoney.Web.Controllers;
    using MyMoney.Web.Orchestrators.Authentication;
    using MyMoney.Web.Orchestrators.Authentication.Interfaces;
    using MyMoney.Web.Orchestrators.Chart;
    using MyMoney.Web.Orchestrators.Chart.Interfaces;
    using MyMoney.Web.Orchestrators.Spending;
    using MyMoney.Web.Orchestrators.Spending.Interfaces;

    #endregion

    /// <summary>
    ///     The castle windsor installer for web application controllers.
    /// </summary>
    /// <seealso cref="Castle.MicroKernel.Registration.IWindsorInstaller" />
    public class ControllersInstaller : IWindsorInstaller
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
                Component.For<UserController>()
                    .LifestylePerWebRequest()
                    .DependsOn(Dependency.OnComponent<IUserOrchestrator, UserOrchestrator>()));

            container.Register(Component.For<BudgetController>().LifestylePerWebRequest());

            container.Register(
                Component.For<BillController>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IBillOrchestrator, BillOrchestrator>(),
                        Dependency.OnComponent<IChartOrchestrator, ChartOrchestrator>()));

            container.Register(Component.For<GoalController>().LifestylePerWebRequest());

            container.Register(Component.For<ResourceController>().LifestylePerWebRequest());
            container.Register(Component.For<ErrorController>().LifestylePerWebRequest());
            container.Register(Component.For<HomeController>().LifestylePerWebRequest());
            container.Register(Component.For<ExpenditureController>().LifestylePerWebRequest());
            container.Register(Component.For<AccountController>().LifestylePerWebRequest());
        }

        #endregion
    }
}