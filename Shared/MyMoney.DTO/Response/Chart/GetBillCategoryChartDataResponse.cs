namespace MyMoney.DTO.Response.Chart
{
    #region Usings

    using System.Collections.Generic;

    using Request.Chart.Bill;

    #endregion

    /// <summary>
    /// The response object for the <see cref="GetBillCategoryChartDataRequest"/> request.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class GetBillCategoryChartDataResponse : BaseResponse
    {
        #region  Properties

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public IList<KeyValuePair<string, int>> Data { get; set; }

        #endregion
    }
}