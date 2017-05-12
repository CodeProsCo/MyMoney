namespace MyMoney.Helpers.Views
{
    #region Usings

    using System.IO;
    using System.Web.Mvc;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    [UsedImplicitly]
    public class ViewHelper : IViewHelper
    {
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