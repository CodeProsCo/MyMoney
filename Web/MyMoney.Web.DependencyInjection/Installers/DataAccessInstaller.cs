namespace MyMoney.Web.DependencyInjection.Installers
{
    #region Usings

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using MyMoney.Web.DataAccess.Authentication;
    using MyMoney.Web.DataAccess.Authentication.Interfaces;
    using MyMoney.Web.DataAccess.Chart;
    using MyMoney.Web.DataAccess.Chart.Interfaces;
    using MyMoney.Web.DataAccess.Spending;
    using MyMoney.Web.DataAccess.Spending.Interfaces;

    #endregion

    /// <summary>
    ///     Installs dependencies for the data access classes in the web application.
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
                Component.For<IUserDataAccess>().ImplementedBy<UserDataAccess>().LifestylePerWebRequest());

            container.Register(
                Component.For<IBillDataAccess>().ImplementedBy<BillDataAccess>().LifestylePerWebRequest());

            container.Register(
                Component.For<IChartDataAccess>().ImplementedBy<ChartDataAccess>().LifestylePerWebRequest());

            container.Register(
                Component.For<IExpenditureDataAccess>().ImplementedBy<ExpenditureDataAccess>().LifestylePerWebRequest());
        }

        #endregion
    }
}