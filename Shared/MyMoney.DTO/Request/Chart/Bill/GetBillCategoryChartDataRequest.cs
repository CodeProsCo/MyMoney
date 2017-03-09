namespace MyMoney.DTO.Request.Chart.Bill
{
    #region Usings

    using System;

    using Interfaces;

    #endregion

    /// <summary>
    /// The HTTP GET request object for obtaining the bill category chart data.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Request.BaseRequest" />
    /// <seealso cref="MyMoney.DTO.Request.Interfaces.IGetRequest" />
    public class GetBillCategoryChartDataRequest : BaseRequest, IGetRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetBillCategoryChartDataRequest" /> class.
        /// </summary>
        public GetBillCategoryChartDataRequest()
            : base("chart/bill/category/{0}/{1}")
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
        ///     Formats the request URI.
        /// </summary>
        /// <returns>The formatted uri.</returns>
        public string FormatRequestUri()
        {
            return string.Format(GetAction(), UserId, RequestReference);
        }

        #endregion
    }
}