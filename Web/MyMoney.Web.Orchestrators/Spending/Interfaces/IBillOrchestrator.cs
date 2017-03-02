namespace MyMoney.Web.Orchestrators.Spending.Interfaces
{
    #region Usings

    using System;
    using System.Threading.Tasks;

    using ViewModels.Spending.Bills;

    using Wrappers;

    #endregion

    public interface IBillOrchestrator
    {
        #region  Public Methods

        Task<OrchestratorResponseWrapper<BillViewModel>> AddBill(BillViewModel model, string username);

        Task<OrchestratorResponseWrapper<BillViewModel>> GetBill(Guid billId, string value);

        Task<OrchestratorResponseWrapper<ManageBillsViewModel>> GetBillInformation(Guid id, string username);

        #endregion

        Task<OrchestratorResponseWrapper<bool>> DeleteBill(Guid billId, string username);

        Task<OrchestratorResponseWrapper<BillViewModel>> EditBill(BillViewModel model, string username);
    }
}