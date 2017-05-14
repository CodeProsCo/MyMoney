namespace MyMoney.API.DependencyInjection.Installers
{
    #region Usings

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using DataAccess;
    using DataAccess.Authentication;
    using DataAccess.Authentication.Interfaces;
    using DataAccess.Common;
    using DataAccess.Common.Interfaces;
    using DataAccess.Saving;
    using DataAccess.Saving.Interfaces;
    using DataAccess.Spending;
    using DataAccess.Spending.Interfaces;

    using Helpers.Security;
    using Helpers.Security.Interfaces;

    #endregion

    /// <summary>
    ///     Installs dependencies for the data access classes in the API.
    /// </summary>
    /// <seealso cref="Castle.MicroKernel.Registration.IWindsorInstaller" />
    public class DataAccessInstaller : IWindsorInstaller
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
                Component.For<IUserRepository>()
                    .ImplementedBy<UserRepository>()
                    .LifestylePerWebRequest()
                    .DependsOn(Dependency.OnComponent<IEncryptionHelper, EncryptionHelper>()));

            container.Register(
                Component.For<IBillRepository>()
                    .ImplementedBy<BillRepository>()
                    .LifestylePerWebRequest()
                    .DependsOn(Dependency.OnComponent<ICategoryRepository, CategoryRepository>()));

            container.Register(
                Component.For<ICategoryRepository>()
                    .ImplementedBy<CategoryRepository>()
                    .LifestylePerWebRequest());

            container.Register(
                Component.For<IExpenditureRepository>()
                    .ImplementedBy<ExpenditureRepository>()
                    .LifestylePerWebRequest()
                    .DependsOn(Dependency.OnComponent<ICategoryRepository, CategoryRepository>()));

            container.Register(
                Component.For<IGoalRepository>()
                    .ImplementedBy<GoalRepository>()
                    .LifestylePerWebRequest());
        }

        #endregion
    }
}