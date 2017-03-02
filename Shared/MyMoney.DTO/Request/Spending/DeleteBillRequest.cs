using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.DTO.Request.Spending
{
    public class DeleteBillRequest : BaseRequest
    {

        public DeleteBillRequest()
            : base("/spending/bills/delete")
        {
        }

        public Guid BillId { get; set; }
    }
}
