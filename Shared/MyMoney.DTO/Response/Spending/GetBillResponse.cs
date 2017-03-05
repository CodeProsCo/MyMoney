namespace MyMoney.DTO.Response.Spending
{
    #region Usings

    using Proxies.Spending;

    using Request.Spending;

    #endregion

    /// <summary>
    /// The <see cref="GetBillResponse"/> class is the response object for a <see cref="GetBillRequest"/> request.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class GetBillResponse : BaseResponse
    {
        #region  Properties

        /// <summary>
        /// Gets or sets the bill.
        /// </summary>
        /// <value>
        /// The bill.
        /// </value>
        public BillProxy Bill { get; set; }

        #endregion
    }
}