namespace MyMoney.Helpers.Views.Interfaces
{
    #region Usings

    using System.Web.Mvc;

    #endregion

    /// <summary>
    ///     The interface for the <see cref="ViewHelper" /> class.
    /// </summary>
    public interface IViewHelper
    {
        #region Methods

        /// <summary>
        ///     Renders the given view to a <see cref="string" />.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="model">The model.</param>
        /// <param name="context">The context.</param>
        /// <param name="viewData">The view data.</param>
        /// <param name="tempData">The temporary data.</param>
        /// <returns>The rendered view as a <see cref="string" /></returns>
        string RenderViewToString(
            string viewName,
            object model,
            ControllerContext context,
            ViewDataDictionary viewData,
            TempDataDictionary tempData);

        #endregion
    }
}