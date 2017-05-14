namespace MyMoney.Web.Plumbing.Installers
{
    #region Usings

    using Areas.Authentication.Controllers;
    using Areas.Common.Controllers;
    using Areas.Dashboard.Controllers;
    using Areas.Saving.Controllers;
    using Areas.Spending.Controllers;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Controllers;

    using Helpers.Benchmarking;
    using Helpers.Benchmarking.Interfaces;
    using Helpers.Error;
    using Helpers.Error.Interfaces;
    using Helpers.Views;
    using Helpers.Views.Interfaces;

    using Orchestrators.Authentication;
    using Orchestrators.Authentication.Interfaces;
    using Orchestrators.Chart;
    using Orchestrators.Chart.Interfaces;
    using Orchestrators.Saving;
    using Orchestrators.Saving.Interfaces;
    using Orchestrators.Spending;
    using Orchestrators.Spending.Interfaces;

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
                    .DependsOn(
                        Dependency.OnComponent<IUserOrchestrator, UserOrchestrator>(),
                        Dependency.OnComponent<IErrorHelper, ErrorHelper>(),
                        Dependency.OnComponent<IBenchmarkHelper, BenchmarkHelper>(),
                        Dependency.OnComponent<IViewHelper, ViewHelper>()));

            container.Register(
                Component.For<BudgetController>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IErrorHelper, ErrorHelper>(),
                        Dependency.OnComponent<IBenchmarkHelper, BenchmarkHelper>(),
                        Dependency.OnComponent<IViewHelper, ViewHelper>()));

            container.Register(
                Component.For<BillController>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IBillOrchestrator, BillOrchestrator>(),
                        Dependency.OnComponent<IChartOrchestrator, ChartOrchestrator>(),
                        Dependency.OnComponent<IErrorHelper, ErrorHelper>(),
                        Dependency.OnComponent<IBenchmarkHelper, BenchmarkHelper>(),
                        Dependency.OnComponent<IViewHelper, ViewHelper>()));

            container.Register(
                Component.For<GoalController>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IGoalOrchestrator, GoalOrchestrator>(),
                        Dependency.OnComponent<IErrorHelper, ErrorHelper>(),
                        Dependency.OnComponent<IBenchmarkHelper, BenchmarkHelper>(),
                        Dependency.OnComponent<IViewHelper, ViewHelper>()));

            container.Register(
                Component.For<ResourceController>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IErrorHelper, ErrorHelper>(),
                        Dependency.OnComponent<IBenchmarkHelper, BenchmarkHelper>(),
                        Dependency.OnComponent<IViewHelper, ViewHelper>()));

            container.Register(
                Component.For<ErrorController>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IErrorHelper, ErrorHelper>(),
                        Dependency.OnComponent<IBenchmarkHelper, BenchmarkHelper>(),
                        Dependency.OnComponent<IViewHelper, ViewHelper>()));

            container.Register(
                Component.For<HomeController>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IErrorHelper, ErrorHelper>(),
                        Dependency.OnComponent<IBenchmarkHelper, BenchmarkHelper>(),
                        Dependency.OnComponent<IViewHelper, ViewHelper>()));

            container.Register(
                Component.For<ExpenditureController>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IErrorHelper, ErrorHelper>(),
                        Dependency.OnComponent<IBenchmarkHelper, BenchmarkHelper>(),
                        Dependency.OnComponent<IViewHelper, ViewHelper>()));

            container.Register(
                Component.For<AccountController>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IErrorHelper, ErrorHelper>(),
                        Dependency.OnComponent<IBenchmarkHelper, BenchmarkHelper>(),
                        Dependency.OnComponent<IViewHelper, ViewHelper>()));
        }

        #endregion
    }
}