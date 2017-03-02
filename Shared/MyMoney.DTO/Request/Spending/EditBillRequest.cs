using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.DTO.Request.Spending
{
    using Proxies.Spending;

    public class EditBillRequest : BaseRequest
    {
        public EditBillRequest()
            : base("/spending/bills/edit")
        {
            
        }

        public BillProxy Bill { get; set; }
    }
}
