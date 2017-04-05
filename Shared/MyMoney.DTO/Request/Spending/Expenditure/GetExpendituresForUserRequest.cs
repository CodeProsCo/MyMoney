namespace MyMoney.DTO.Request.Spending.Expenditure
{
    #region Usings

    using System;

    using Interfaces;

    #endregion

    /// <summary>
    ///     The<see cref="GetExpendituresForUserRequest" /> class is used for obtaining the list of expenditures for a user.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Request.BaseRequest" />
    /// <seealso cref="MyMoney.DTO.Request.Interfaces.IGetRequest" />
    public class GetExpendituresForUserRequest : BaseRequest, IGetRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetExpendituresForUserRequest" /> class.
        /// </summary>
        public GetExpendituresForUserRequest()
            : base("spending/expenditures/user/{0}/{1}/")
        {
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the user identifier.
        /// </summary>
        /// <value>
        ///     The user identifier.
        /// </value>
        public Guid UserId { get; set; }

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
            return string.Format(GetAction(), UserId, RequestReference);
        }

        #endregion
    }
}