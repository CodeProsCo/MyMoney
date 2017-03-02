namespace MyMoney.DTO.Request.Spending
{
    #region Usings

    using Proxies.Spending;

    #endregion

    public class AddBillRequest : BaseRequest
    {
        #region Constructor

        public AddBillRequest()
            : base("spending/bills/add")
        {
        }

        #endregion

        #region  Properties

        public BillProxy Bill { get; set; }

        #endregion
    }
}