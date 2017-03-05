using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.DTO.Request.Spending
{
    using Interfaces;
    public class DeleteBillRequest : BaseRequest, IDeleteRequest
    {

        public DeleteBillRequest()
            : base("spending/bills/delete/{0}/{1}/{2}")
        {
        }

        public Guid BillId { get; set; }

        #region Implementation of IDeleteRequest

        public string FormatRequestUri()
        {
            return string.Format(GetAction(), BillId, RequestReference, Username.Replace("@", ";").Replace(".", ","));
        }

        #endregion
    }
}
