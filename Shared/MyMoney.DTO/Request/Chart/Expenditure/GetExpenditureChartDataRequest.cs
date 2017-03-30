namespace MyMoney.DTO.Request.Chart.Expenditure
{
    #region Usings

    using System;

    using MyMoney.DTO.Request.Interfaces;

    #endregion

    /// <summary>
    /// The <see cref="GetExpenditureChartDataRequest"/> class is a HTTP GET request object for obtaining
    /// the expenditure chart data.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Request.BaseRequest" />
    /// <seealso cref="MyMoney.DTO.Request.Interfaces.IGetRequest" />
    public class GetExpenditureChartDataRequest : BaseRequest, IGetRequest
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GetExpenditureChartDataRequest"/> class.
        /// </summary>
        public GetExpenditureChartDataRequest()
            : base("chart/expenditure/month/{0}/{1}/{2}")
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the month.
        /// </summary>
        /// <value>
        /// The month.
        /// </value>
        public int Month { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Formats the request URI.
        /// </summary>
        /// <returns>
        /// The formatted uri.
        /// </returns>
        public string FormatRequestUri()
        {
            return string.Format(GetAction(), UserId, Month, RequestReference);
        }

        #endregion
    }
}