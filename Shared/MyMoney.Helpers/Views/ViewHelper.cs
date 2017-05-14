namespace MyMoney.Helpers.Views
{
    #region Usings

    using System.IO;
    using System.Web.Mvc;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    /// The view helper contains methods to help developers manipulate views.
    /// </summary>
    /// <seealso cref="MyMoney.Helpers.Views.Interfaces.IViewHelper" />
    [UsedImplicitly]
    public class ViewHelper : IViewHelper
    {
        /// <summary>
        /// Renders the given view to a <see cref="string" />.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="model">The model.</param>
        /// <param name="context">The context.</param>
        /// <param name="viewData">The view data.</param>
        /// <param name="tempData">The temporary data.</param>
        /// <returns>
        /// The rendered view as a <see cref="string" />
        /// </returns>
        public string RenderViewToString(
            string viewName,
            object model,
            ControllerContext context,
            ViewDataDictionary viewData,
            TempDataDictionary tempData)
        {
            viewData.Model = model;

            using (var writer = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(context, viewName);
                var viewContext = new ViewContext(context, viewResult.View, viewData, tempData, writer);

                viewResult.View.Render(viewContext, writer);
                return writer.GetStringBuilder().ToString();
            }
        }
    }
}