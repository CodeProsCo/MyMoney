using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.Helpers.Views
{
    using System.IO;
    using System.Web.Mvc;

    public static class ViewHelper
    {
        public static string RenderViewToString(string viewName, object model, ControllerContext context, ViewDataDictionary viewData, TempDataDictionary tempData)
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
