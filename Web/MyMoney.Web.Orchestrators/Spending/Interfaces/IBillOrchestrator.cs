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

        Task<OrchestratorResponseWrapper<BillViewModel>> AddBill(AddBillViewModel model, Guid userId);

        Task<OrchestratorResponseWrapper<ManageBillsViewModel>> GetBillInformation(Guid id);

        #endregion
    }
}