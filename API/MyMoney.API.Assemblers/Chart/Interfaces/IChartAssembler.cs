namespace MyMoney.API.Assemblers.Chart.Interfaces
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using DTO.Response.Chart.Bill;

    #endregion

    /// <summary>
    /// Interface for the <see cref="ChartAssembler"/> class.
    /// </summary>
    public interface IChartAssembler
    {
        /// <summary>
        /// Creates an instance of the <see cref="GetBillCategoryChartDataResponse"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        GetBillCategoryChartDataResponse NewGetBillCategoryChartDataResponse(IList<KeyValuePair<string, int>> data, Guid requestReference);

        /// <summary>
        /// Creates an instance of the <see cref="GetBillPeriodChartDataResponse"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        GetBillPeriodChartDataResponse NewGetBillPeriodChartDataResponse(IList<KeyValuePair<string, int>> data, Guid requestReference);
    }
}