namespace MyMoney.Web.DependencyInjection.Installers
{
    #region Usings

    using Assemblers.Authentication;
    using Assemblers.Authentication.Interfaces;
    using Assemblers.Chart;
    using Assemblers.Chart.Interfaces;
    using Assemblers.Spending;
    using Assemblers.Spending.Interfaces;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    #endregion

    /// <summary>
    ///     Installs dependencies for assembler classes in the web application.
    /// </summary>
    /// <seealso cref="Castle.MicroKernel.Registration.IWindsorInstaller" />
    public class AssemblersInstaller : IWindsorInstaller
    {
        #region Methods

        /// <summary>
        ///     Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUserAssembler>().ImplementedBy<UserAssembler>().LifestylePerWebRequest());
            container.Register(Component.For<IBillAssembler>().ImplementedBy<BillAssembler>().LifestylePerWebRequest());
            container.Register(
                Component.For<IChartAssembler>().ImplementedBy<ChartAssembler>().LifestylePerWebRequest());
            container.Register(
                Component.For<IExpenditureAssembler>().ImplementedBy<ExpenditureAssembler>().LifestylePerWebRequest());
        }

        #endregion
    }
}