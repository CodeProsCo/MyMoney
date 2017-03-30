namespace MyMoney.Web.Attributes
{
    #region Usings

    using System.Reflection;
    using System.Web.Mvc;

    #endregion

    /// <summary>
    ///     The <see cref="AjaxOnlyAttribute" /> attribute validates a request and ensures that it is using AJAX.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.ActionMethodSelectorAttribute" />
    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        #region Methods

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