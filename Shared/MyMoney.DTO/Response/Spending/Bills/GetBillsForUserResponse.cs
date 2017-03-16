namespace MyMoney.DTO.Response.Spending.Bills
{
    #region Usings

    using System.Collections.Generic;
    using System.Linq;

    using Proxies.Spending;

    #endregion

    public class GetBillsForUserResponse : BaseResponse
    {
        #region  Properties

        public int BillCount => Bills?.Count ?? 0;

        public IList<BillProxy> Bills { get; set; }

        public double BillTotal => Bills?.Sum(x => x.Amount) ?? 0;

        #endregion
    }
}