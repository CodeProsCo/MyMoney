namespace MyMoney.DTO.Response.Spending
{
    using System.Collections.Generic;
    using System.Linq;

    using Proxies.Spending;

    public class GetBillInformationResponse : BaseResponse
    {
        public IList<BillProxy> Bills { get; set; }

        public int BillCount => Bills?.Count ?? 0;

        public double BillTotal => Bills?.Sum(x => x.Amount) ?? 0;
    }
}