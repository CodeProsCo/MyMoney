namespace MyMoney.Web.Areas.Spending
{
    #region Usings

    using System.Web.Mvc;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    /// Registers the routes for the "Spending" area.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.AreaRegistration" />
    [UsedImplicitly]
    public class SpendingAreaRegistration : AreaRegistration
    {
        #region Properties

        /// <summary>
        /// Gets the name of the area to register.
        /// </summary>
        public override string AreaName => "Spending";

        #endregion

        #region Methods

        /// <summary>
        /// Registers an area in an ASP.NET MVC application using the specified area's context information.
        /// </summary>
        /// <param name="context">Encapsulates the information that is required in order to register the area.</param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Spending_default",
                "Spending/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }

        #endregion
    }
}