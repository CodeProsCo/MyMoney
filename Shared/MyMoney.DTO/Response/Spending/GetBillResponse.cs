namespace MyMoney.DTO.Response.Spending
{
    #region Usings

    using Proxies.Spending;

    #endregion

    public class GetBillResponse : BaseResponse
    {
        #region  Properties

        public BillProxy Bill { get; set; }

        #endregion
    }
}