namespace MyMoney.DTO.Response.Spending.Bill
{
    #region Usings

    using System.Collections.Generic;
    using System.Linq;

    using MyMoney.Proxies.Spending;

    #endregion

    /// <summary>
    /// The <see cref="GetBillsForUserResponse"/> class is the 
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class GetBillsForUserResponse : BaseResponse
    {
        #region Properties

        /// <summary>
        /// Gets the bill count.
        /// </summary>
        /// <value>
        /// The bill count.
        /// </value>
        public int BillCount => Bills?.Count ?? 0;

        /// <summary>
        /// Gets or sets the bills.
        /// </summary>
        /// <value>
        /// The bills.
        /// </value>
        public IList<BillProxy> Bills { get; set; }

        /// <summary>
        /// Gets the bill total.
        /// </summary>
        /// <value>
        /// The bill total.
        /// </value>
        public double BillTotal => Bills?.Sum(x => x.Amount) ?? 0;

        #endregion
    }
}