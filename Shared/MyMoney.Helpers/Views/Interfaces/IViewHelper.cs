using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.Helpers.Views.Interfaces
{
    using System.Web.Mvc;

    public interface IViewHelper
    {
        string RenderViewToString(
            string viewName,
            object model,
            ControllerContext context,
            ViewDataDictionary viewData,
            TempDataDictionary tempData);
    }
}
