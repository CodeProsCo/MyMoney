namespace MyMoney.API.Orchestrators.Spending.Interfaces
{
    using System;
    using System.Threading.Tasks;

    using DTO.Request.Spending;
    using DTO.Response.Spending;

    public interface IBillOrchestrator
    {
        Task<GetBillInformationResponse> GetBillInformation(GetBillInformationRequest request);

        Task<AddBillResponse> AddBill(AddBillRequest request);
    }
}
