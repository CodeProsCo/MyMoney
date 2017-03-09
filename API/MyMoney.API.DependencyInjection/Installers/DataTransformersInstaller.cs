namespace MyMoney.API.DependencyInjection.Installers
{
    #region Usings

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using DataTransformers.Spending;
    using DataTransformers.Spending.Interfaces;

    #endregion

    /// <summary>
    ///     The IOC installer for data transformation classes.
    /// </summary>
    /// <seealso cref="Castle.MicroKernel.Registration.IWindsorInstaller" />
    public class DataTransformersInstaller : IWindsorInstaller
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
                Component.For<IBillDataTransformer>().ImplementedBy<BillDataTransformer>().LifestylePerWebRequest());
        }

        #endregion
    }
}