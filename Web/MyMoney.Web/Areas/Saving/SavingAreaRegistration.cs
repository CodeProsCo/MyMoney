namespace MyMoney.Web.Areas.Saving
{
    #region Usings

    using System.Web.Mvc;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    /// Registers the routes for the "saving" area.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.AreaRegistration" />
    [UsedImplicitly]
    public class SavingAreaRegistration : AreaRegistration
    {
        #region Properties

        /// <summary>
        /// Gets the name of the area to register.
        /// </summary>
        public override string AreaName => "Saving";

        #endregion

        #region Methods

        /// <summary>
        /// Registers an area in an ASP.NET MVC application using the specified area's context information.
        /// </summary>
        /// <param name="context">Encapsulates the information that is required in order to register the area.</param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Saving_default",
                "Saving/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }

        #endregion
    }
}