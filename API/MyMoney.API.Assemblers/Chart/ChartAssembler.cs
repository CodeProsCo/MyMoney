namespace MyMoney.API.Assemblers.Chart
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using DTO.Response.Chart.Bill;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    [UsedImplicitly]
    public class ChartAssembler : IChartAssembler
    {
        #region Implementation of IChartAssembler

        public GetBillCategoryChartDataResponse NewGetBillCategoryChartDataResponse(IList<KeyValuePair<string, int>> data, Guid requestReference)
        {
            return new GetBillCategoryChartDataResponse { Data = data, RequestReference = requestReference };
        }

        public GetBillPeriodChartDataResponse NewGetBillPeriodChartDataResponse(IList<KeyValuePair<string, int>> data, Guid requestReference)
        {
            return new GetBillPeriodChartDataResponse { Data = data, RequestReference = requestReference };
        }

        #endregion
    }
}