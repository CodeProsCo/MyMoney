namespace MyMoney.API.Assemblers.Chart.Interfaces
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using DTO.Response.Chart.Bill;
    using DTO.Response.Chart.Expenditure;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="ChartAssembler" /> class.
    /// </summary>
    public interface IChartAssembler
    {
        #region Methods

        /// <summary>
        ///     Creates an instance of the <see cref="GetBillCategoryChartDataResponse" /> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        GetBillCategoryChartDataResponse NewGetBillCategoryChartDataResponse(
            IList<KeyValuePair<string, int>> data,
            Guid requestReference);

        /// <summary>
        ///     Creates an instance of the <see cref="GetBillPeriodChartDataResponse" /> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        GetBillPeriodChartDataResponse NewGetBillPeriodChartDataResponse(
            IList<KeyValuePair<string, int>> data,
            Guid requestReference);

        /// <summary>
        /// Creates an instance of the <see cref="GetExpenditureChartDataResponse"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="requestRequestReference">The request request reference.</param>
        /// <returns>The response object.</returns>
        GetExpenditureChartDataResponse NewGetExpenditureChartDataResponse(
            IList<KeyValuePair<DateTime, double>> data,
            Guid requestRequestReference);

        #endregion
    }
}