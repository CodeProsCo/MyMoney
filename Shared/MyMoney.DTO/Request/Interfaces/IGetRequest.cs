using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.DTO.Request.Interfaces
{
    using System.Security.Cryptography.X509Certificates;

    public interface IGetRequest
    {
        string FormatRequestUri();
    }
}
