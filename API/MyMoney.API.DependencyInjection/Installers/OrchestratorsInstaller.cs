﻿namespace MyMoney.API.DependencyInjection.Installers
{
    #region Usings

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using DataTransformers.Spending.Bills;
    using DataTransformers.Spending.Bills.Interfaces;

    using MyMoney.API.Assemblers.Authentication;
    using MyMoney.API.Assemblers.Authentication.Interfaces;
    using MyMoney.API.Assemblers.Spending;
    using MyMoney.API.Assemblers.Spending.Interfaces;
    using MyMoney.API.DataAccess.Authentication;
    using MyMoney.API.DataAccess.Authentication.Interfaces;
    using MyMoney.API.DataAccess.Spending;
    using MyMoney.API.DataAccess.Spending.Interfaces;
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

            container.Register(
                Component.For<IBillOrchestrator>()
                    .ImplementedBy<BillOrchestrator>()
                    .LifestylePerWebRequest()
                    .DependsOn(
                        Dependency.OnComponent<IBillAssembler, BillAssembler>(), 
                        Dependency.OnComponent<IBillRepository, BillRepository>(),
                        Dependency.OnComponent<IBillDataTransformer, BillDataTransformer>()));
        }

        #endregion
    }
}