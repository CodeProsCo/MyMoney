namespace MyMoney.Web.Attributes
{
    #region Usings

    using System.Reflection;
    using System.Web.Mvc;

    #endregion

    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        #region  Public Methods

        /// <summary>Determines whether the action method selection is valid for the specified controller context.</summary>
        /// <returns>true if the action method selection is valid for the specified controller context; otherwise, false.</returns>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="methodInfo">Information about the action method.</param>
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return controllerContext.RequestContext.HttpContext.Request.IsAjaxRequest();
        }

        #endregion
    }
}