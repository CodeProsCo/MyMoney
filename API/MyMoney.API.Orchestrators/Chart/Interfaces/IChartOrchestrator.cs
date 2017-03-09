namespace MyMoney.API.Orchestrators.Chart.Interfaces
{
    #region Usings

    using System.Threading.Tasks;

    using DTO.Request.Chart.Bill;
    using DTO.Response.Chart.Bill;

    #endregion

    public interface IChartOrchestrator
    {
        #region  Public Methods

        Task<GetBillCategoryChartDataResponse> GetBillCategoryChartData(GetBillCategoryChartDataRequest request);

        Task<GetBillPeriodChartDataResponse> GetBillPeriodChartData(GetBillPeriodChartDataRequest request);

        #endregion
    }
}