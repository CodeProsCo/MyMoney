namespace MyMoney.DTO.Request.Spending.Bill
{
    #region Usings

    using MyMoney.Proxies.Spending;

    #endregion

    /// <summary>
    ///     The <see cref="AddBillRequest" /> class is used when adding a bill to the database.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Request.BaseRequest" />
    public class AddBillRequest : BaseRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="AddBillRequest" /> class.
        /// </summary>
        public AddBillRequest()
            : base("spending/bills/add")
        {
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the bill.
        /// </summary>
        /// <value>
        ///     The bill.
        /// </value>
        public BillProxy Bill { get; set; }

        #endregion
    }
}