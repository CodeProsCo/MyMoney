namespace MyMoney.Web.Areas.Common
{
    #region Usings

    using System.Web.Mvc;

    #endregion

    /// <summary>
    /// Registers the routes for the "Common" area.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.AreaRegistration" />
    public class CommonAreaRegistration : AreaRegistration
    {
        #region Properties

        /// <summary>
        /// Gets the name of the area to register.
        /// </summary>
        public override string AreaName => "Common";

        #endregion

        #region Methods

        /// <summary>
        /// Registers an area in an ASP.NET MVC application using the specified area's context information.
        /// </summary>
        /// <param name="context">Encapsulates the information that is required in order to register the area.</param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Common_default",
                "Common/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }

        #endregion
    }
}