namespace MyMoney.Web.Areas.Spending
{
    #region Usings

    using System.Web.Mvc;

    using JetBrains.Annotations;

    #endregion

    [UsedImplicitly]
    public class SpendingAreaRegistration : AreaRegistration
    {
        #region  Properties

        public override string AreaName => "Spending";

        #endregion

        #region  Public Methods

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