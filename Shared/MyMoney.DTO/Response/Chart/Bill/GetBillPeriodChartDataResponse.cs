namespace MyMoney.DTO.Response.Chart.Bill
{
    #region Usings

    using System.Collections.Generic;

    using MyMoney.DTO.Request.Chart.Bill;

    #endregion

    /// <summary>
    ///     The response object for the <see cref="GetBillPeriodChartDataRequest" /> request.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class GetBillPeriodChartDataResponse : BaseResponse
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the data.
        /// </summary>
        /// <value>
        ///     The data.
        /// </value>
        public IList<KeyValuePair<string, int>> Data { get; set; }

        #endregion
    }
}