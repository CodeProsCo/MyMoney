namespace MyMoney.API.Assemblers.Chart
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using DTO.Response.Chart.Bill;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     The <see cref="ChartAssembler" /> class creates response objects for use by the API.
    /// </summary>
    /// <seealso cref="MyMoney.API.Assemblers.Chart.Interfaces.IChartAssembler" />
    [UsedImplicitly]
    public class ChartAssembler : IChartAssembler
    {
        #region  Public Methods

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

        #endregion
    }
}