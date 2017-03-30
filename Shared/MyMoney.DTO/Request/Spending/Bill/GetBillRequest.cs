namespace MyMoney.DTO.Request.Spending.Bill
{
    #region Usings

    using System;

    using MyMoney.DTO.Request.Interfaces;

    #endregion

    /// <summary>
    ///     The <see cref="GetBillRequest" /> class is used for obtaining a bill from the database.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Request.BaseRequest" />
    /// <seealso cref="MyMoney.DTO.Request.Interfaces.IGetRequest" />
    public class GetBillRequest : BaseRequest, IGetRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetBillRequest" /> class.
        /// </summary>
        public GetBillRequest()
            : base("spending/bills/get/{0}/{1}/")
        {
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the bill identifier.
        /// </summary>
        /// <value>
        ///     The bill identifier.
        /// </value>
        public Guid BillId { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Formats the request URI.
        /// </summary>
        /// <returns>
        ///     The formatted uri.
        /// </returns>
        public string FormatRequestUri()
        {
            return string.Format(GetAction(), BillId, RequestReference);
        }

        #endregion
    }
}