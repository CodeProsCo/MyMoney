using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.Helpers.Error.Interfaces
{
    using Wrappers;

    public interface IErrorHelper
    {
        ResponseErrorWrapper Create(Exception ex, string username, Type className, string methodName);

        ResponseErrorWrapper Create(string message, string username, Type className, string methodName);



    }
}
