namespace MyMoney.DTO.Response.Spending
{
    #region Usings

    using Proxies.Spending;

    #endregion

    public class AddBillResponse : BaseResponse
    {
        #region  Properties

        public BillProxy Bill { get; set; }

        #endregion
    }
}