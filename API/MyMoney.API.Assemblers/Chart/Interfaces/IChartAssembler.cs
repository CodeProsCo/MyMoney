namespace MyMoney.API.Assemblers.Chart.Interfaces
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using DTO.Response.Chart.Bill;

    #endregion

    public interface IChartAssembler
    {
        GetBillCategoryChartDataResponse NewGetBillCategoryChartDataResponse(IList<KeyValuePair<string, int>> data, Guid requestReference);

        GetBillPeriodChartDataResponse NewGetBillPeriodChartDataResponse(IList<KeyValuePair<string, int>> data, Guid requestReference);
    }
}