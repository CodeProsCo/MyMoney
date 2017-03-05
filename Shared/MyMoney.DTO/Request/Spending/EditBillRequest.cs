namespace MyMoney.DTO.Request.Spending
{
    #region Usings

    using Proxies.Spending;

    #endregion

    /// <summary>
    /// The <see cref="EditBillRequest"/> class is used for editing a bill in the database.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Request.BaseRequest" />
    public class EditBillRequest : BaseRequest
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="EditBillRequest"/> class.
        /// </summary>
        public EditBillRequest()
            : base("spending/bills/edit")
        {
        }

        #endregion

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