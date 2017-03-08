using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.DTO.Response.Spending
{
    using Proxies.Spending;

    public class GetBillsForUserForMonthResponse : BaseResponse
    {
        public IList<KeyValuePair<int, IList<BillProxy>>> Bills { get; set; }
    }
}
