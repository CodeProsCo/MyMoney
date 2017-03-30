namespace MyMoney.API.Assemblers.Chart
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using JetBrains.Annotations;

    using MyMoney.API.Assemblers.Chart.Interfaces;
    using MyMoney.DTO.Response.Chart.Bill;
    using MyMoney.DTO.Response.Chart.Expenditure;

    #endregion

    /// <summary>
    ///     The <see cref="ChartAssembler" /> class creates response objects for use by the API.
    /// </summary>
    /// <seealso cref="MyMoney.API.Assemblers.Chart.Interfaces.IChartAssembler" />
    [UsedImplicitly]
    public class ChartAssembler : IChartAssembler
    {
        #region Methods

        /// <summary>
        ///     Creates an instance of the <see cref="GetBillCategoryChartDataResponse" /> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public GetBillCategoryChartDataResponse NewGetBillCategoryChartDataResponse(
            IList<KeyValuePair<string, int>> data,
            Guid requestReference)
        {
            return new GetBillCategoryChartDataResponse { Data = data, RequestReference = requestReference };
        }

        /// <summary>
        ///     Creates an instance of the <see cref="GetBillPeriodChartDataResponse" /> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public GetBillPeriodChartDataResponse NewGetBillPeriodChartDataResponse(
            IList<KeyValuePair<string, int>> data,
            Guid requestReference)
        {
            return new GetBillPeriodChartDataResponse { Data = data, RequestReference = requestReference };
        }

        /// <summary>
        /// News the get expenditure chart data response.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="requestRequestReference">The request request reference.</param>
        /// <returns>The response object.</returns>
        public GetExpenditureChartDataResponse NewGetExpenditureChartDataResponse(
            IList<KeyValuePair<DateTime, double>> data,
            Guid requestRequestReference)
        {
            return new GetExpenditureChartDataResponse { Data = data, RequestReference = requestRequestReference };
        }

        #endregion
    }
}