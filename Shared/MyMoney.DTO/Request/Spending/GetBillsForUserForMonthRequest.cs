using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.DTO.Request.Spending
{
    using Interfaces;
    public class GetBillsForUserForMonthRequest : BaseRequest, IGetRequest
    {

        public GetBillsForUserForMonthRequest()
            : base("spending/bills/get/{0}/month/{1}")
        {
        }

        #region Implementation of IGetRequest

        /// <summary>
        /// Formats the request URI.
        /// </summary>
        /// <returns>The formatted uri.</returns>
        public string FormatRequestUri()
        {
            return string.Format(GetAction(), UserId, MonthNumber);
        }

        public int MonthNumber { get; set; }

        public Guid UserId { get; set; }

        #endregion
    }
}
