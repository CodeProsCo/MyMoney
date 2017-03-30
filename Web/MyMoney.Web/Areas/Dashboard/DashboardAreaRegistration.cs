namespace MyMoney.Web.Areas.Dashboard
{
    #region Usings

    using System.Web.Mvc;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    /// Registers routes for the "Dashboard" area.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.AreaRegistration" />
    [UsedImplicitly]
    public class DashboardAreaRegistration : AreaRegistration
    {
        #region Properties

        /// <summary>
        /// Gets the name of the area to register.
        /// </summary>
        public override string AreaName => "Dashboard";

        #endregion

        #region Methods

        /// <summary>
        /// Registers an area in an ASP.NET MVC application using the specified area's context information.
        /// </summary>
        /// <param name="context">Encapsulates the information that is required in order to register the area.</param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Dashboard_default",
                "Dashboard/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }

        #endregion
    }
}