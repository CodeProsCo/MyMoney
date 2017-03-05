namespace MyMoney.DTO.Request.Spending
{
    #region Usings

    using System;

    using Interfaces;

    #endregion

    /// <summary>
    /// The<see cref="GetBillsForUserRequest"/> class is used for obtaining the list of bills for a user.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Request.BaseRequest" />
    /// <seealso cref="MyMoney.DTO.Request.Interfaces.IGetRequest" />
    public class GetBillsForUserRequest : BaseRequest, IGetRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetBillsForUserRequest" /> class.
        /// </summary>
        public GetBillsForUserRequest()
            : base("spending/bills/user/{0}/{1}/{2}")
        {
        }

        #endregion

        #region  Properties

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

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
            return string.Format(GetAction(), UserId, RequestReference, Username.Replace("@", ";").Replace(".", ","));
        }

        #endregion
    }
}