﻿namespace MyMoney.API.DependencyInjection.Installers
{
    #region Usings

    using Assemblers.Authentication;
    using Assemblers.Authentication.Interfaces;
    using Assemblers.Chart;
    using Assemblers.Chart.Interfaces;
    using Assemblers.Saving;
    using Assemblers.Saving.Interfaces;
    using Assemblers.Spending;
    using Assemblers.Spending.Interfaces;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using DataAccess.Authentication;
    using DataAccess.Authentication.Interfaces;
    using DataAccess.Saving;
    using DataAccess.Saving.Interfaces;
    using DataAccess.Spending;
    using DataAccess.Spending.Interfaces;

    using DataTransformers.Spending;
    using DataTransformers.Spending.Interfaces;

    using Helpers.Error;
    using Helpers.Error.Interfaces;

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
                        Dependency.OnComponent<IUserRepository, UserRepository>(),
                        Dependency.OnComponent<IErrorHelper, ErrorHelper>()));

            container.Register(
                Component.For<IBillOrchestrator>()
                    .ImplementedBy<BillOrchestrator>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IBillAssembler, BillAssembler>(),
                        Dependency.OnComponent<IBillRepository, BillRepository>(),
                        Dependency.OnComponent<IBillDataTransformer, BillDataTransformer>(),
                        Dependency.OnComponent<IErrorHelper, ErrorHelper>()));

            container.Register(
                Component.For<IChartOrchestrator>()
                    .ImplementedBy<ChartOrchestrator>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IBillDataTransformer, BillDataTransformer>(),
                        Dependency.OnComponent<IBillRepository, BillRepository>(),
                        Dependency.OnComponent<IChartAssembler, ChartAssembler>(),
                        Dependency.OnComponent<IExpenditureRepository, ExpenditureRepository>(),
                        Dependency.OnComponent<IExpenditureDataTransformer, ExpenditureDataTransformer>(),
                        Dependency.OnComponent<IErrorHelper, ErrorHelper>()));

            container.Register(
                Component.For<IExpenditureOrchestrator>()
                    .ImplementedBy<ExpenditureOrchestrator>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IExpenditureRepository, ExpenditureRepository>(),
                        Dependency.OnComponent<IExpenditureAssembler, ExpenditureAssembler>(),
                        Dependency.OnComponent<IErrorHelper, ErrorHelper>()));

            container.Register(
                Component.For<IGoalOrchestrator>()
                    .ImplementedBy<GoalOrchestrator>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IGoalAssembler, GoalAssembler>(),
                        Dependency.OnComponent<IGoalRepository, GoalRepository>(),
                        Dependency.OnComponent<IErrorHelper, ErrorHelper>()));
        }

        #endregion
    }
}