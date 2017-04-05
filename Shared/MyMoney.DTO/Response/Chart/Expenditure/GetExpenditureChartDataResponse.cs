namespace MyMoney.DTO.Response.Chart.Expenditure
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using Request.Chart.Expenditure;

    #endregion

    /// <summary>
    /// The <see cref="GetExpenditureChartDataResponse"/> class is the response class for the <see cref="GetExpenditureChartDataRequest"/> request.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class GetExpenditureChartDataResponse : BaseResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public IList<KeyValuePair<DateTime, double>> Data { get; set; }

        #endregion
    }
}