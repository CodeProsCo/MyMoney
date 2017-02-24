using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.DTO.Request.Spending
{
    using Proxies.Spending;

    public class AddBillRequest : BaseRequest
    {
        public AddBillRequest()
            : base("spending/bills/add")
        {
            
        }
        
        public BillProxy Bill { get; set; }
    }
}
