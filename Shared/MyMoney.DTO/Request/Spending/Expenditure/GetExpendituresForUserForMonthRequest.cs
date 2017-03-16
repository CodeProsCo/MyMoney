namespace MyMoney.DTO.Request.Spending.Expenditure
{
    #region Usings

    using System;

    using Interfaces;

    #endregion

    /// <summary>
    ///     The HTTP GET response object for obtaining a user's monthly expenditures from the API.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Request.BaseRequest" />
    /// <seealso cref="MyMoney.DTO.Request.Interfaces.IGetRequest" />
    public class GetExpendituresForUserForMonthRequest : BaseRequest, IGetRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetExpendituresForUserForMonthRequest" /> class.
        /// </summary>
        public GetExpendituresForUserForMonthRequest()
            : base("spending/expenditures/get/{0}/month/{1}/{2}")
        {
        }

        #endregion

        #region  Properties

        /// <summary>
        ///     Gets or sets the month number.
        /// </summary>
        /// <value>
        ///     The month number.
        /// </value>
        public int MonthNumber { get; set; }

        /// <summary>
        ///     Gets or sets the user identifier.
        /// </summary>
        /// <value>
        ///     The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        #endregion

        #region  Public Methods

        /// <summary>
        ///     Formats the request URI.
        /// </summary>
        /// <returns>The formatted uri.</returns>
        public string FormatRequestUri()
        {
            return string.Format(GetAction(), UserId, MonthNumber, RequestReference);
        }

        #endregion
    }
}