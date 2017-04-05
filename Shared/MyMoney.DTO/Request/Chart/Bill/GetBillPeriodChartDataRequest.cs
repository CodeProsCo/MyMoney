namespace MyMoney.DTO.Request.Chart.Bill
{
    #region Usings

    using System;

    using Interfaces;

    #endregion

    /// <summary>
    ///     The HTTP GET request object for obtaining the data for the bill period chart.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Request.BaseRequest" />
    /// <seealso cref="MyMoney.DTO.Request.Interfaces.IGetRequest" />
    public class GetBillPeriodChartDataRequest : BaseRequest, IGetRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetBillPeriodChartDataRequest" /> class.
        /// </summary>
        public GetBillPeriodChartDataRequest()
            : base("chart/bill/period/{0}/{1}")
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
        /// <returns>The formatted uri.</returns>
        public string FormatRequestUri()
        {
            return string.Format(GetAction(), UserId, RequestReference);
        }

        #endregion
    }
}