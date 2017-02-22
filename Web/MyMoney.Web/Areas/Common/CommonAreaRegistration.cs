namespace MyMoney.Web.Areas.Common
{
    #region Usings

    using System.Web.Mvc;

    #endregion

    public class CommonAreaRegistration : AreaRegistration
    {
        #region  Properties

        public override string AreaName => "Common";

        #endregion

        #region  Public Methods

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