namespace MyMoney.Web.Areas.Dashboard
{
    #region Usings

    using System.Web.Mvc;

    using JetBrains.Annotations;

    #endregion

    [UsedImplicitly]
    public class DashboardAreaRegistration : AreaRegistration
    {
        #region  Properties

        public override string AreaName => "Dashboard";

        #endregion

        #region  Public Methods

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