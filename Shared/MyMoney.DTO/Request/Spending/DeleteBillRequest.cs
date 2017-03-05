namespace MyMoney.DTO.Request.Spending
{
    #region Usings

    using System;

    using Interfaces;

    #endregion

    /// <summary>
    /// The <see cref="DeleteBillRequest"/> class is used for deleting a bill from the database.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Request.BaseRequest" />
    /// <seealso cref="MyMoney.DTO.Request.Interfaces.IDeleteRequest" />
    public class DeleteBillRequest : BaseRequest, IDeleteRequest
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteBillRequest"/> class.
        /// </summary>
        public DeleteBillRequest()
            : base("spending/bills/delete/{0}/{1}/{2}")
        {
        }

        #endregion

        #region  Properties

        /// <summary>
        /// Gets or sets the bill identifier.
        /// </summary>
        /// <value>
        /// The bill identifier.
        /// </value>
        public Guid BillId { get; set; }

        #endregion

        #region  Public Methods

        /// <summary>
        /// Formats the request URI.
        /// </summary>
        /// <returns>
        /// The formatted uri.
        /// </returns>
        public string FormatRequestUri()
        {
            return string.Format(GetAction(), BillId, RequestReference, Username.Replace("@", ";").Replace(".", ","));
        }

        #endregion
    }
}