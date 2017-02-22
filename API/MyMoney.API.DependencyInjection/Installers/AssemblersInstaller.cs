namespace MyMoney.DependencyInjection.API.Installers
{
    #region Usings

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using MyMoney.API.Assemblers.Authentication;
    using MyMoney.API.Assemblers.Authentication.Interfaces;

    #endregion

    /// <summary>
    ///     Installs dependencies for assemblers used in the API application.
    /// </summary>
    /// <seealso cref="Castle.MicroKernel.Registration.IWindsorInstaller" />
    public class AssemblersInstaller : IWindsorInstaller
    {
        #region  Public Methods

        /// <summary>
        ///     Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUserAssembler>().ImplementedBy<UserAssembler>().LifestylePerWebRequest());
        }

        #endregion
    }
}