namespace MyMoney.API.Orchestrators.Spending.Interfaces
{
    using System;
    using System.Threading.Tasks;

    using DTO.Response.Spending;

    public interface IBillOrchestrator
    {
        Task<GetBillInformationResponse> GetBillInformation(Guid userId);
    }
}
