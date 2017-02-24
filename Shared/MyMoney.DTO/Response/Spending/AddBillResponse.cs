using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.DTO.Response.Spending
{
    using Proxies.Spending;

    public class AddBillResponse : BaseResponse
    {
        public BillProxy Bill { get; set; }
    }
}
