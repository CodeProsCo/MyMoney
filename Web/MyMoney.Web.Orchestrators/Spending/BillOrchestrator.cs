namespace MyMoney.Web.Orchestrators.Spending
{
    #region Usings

    using System;
    using System.Threading.Tasks;

    using Assemblers.Spending.Interfaces;

    using DataAccess.Spending.Interfaces;

    using Interfaces;

    using ViewModels.Spending.Bills;

    using Wrappers;

    #endregion

    public class BillOrchestrator : IBillOrchestrator
    {
        #region Fields

        private readonly IBillAssembler assembler;

        private readonly IBillDataAccess dataAccess;

        #endregion

        #region Constructor

        public BillOrchestrator(IBillAssembler assembler, IBillDataAccess dataAccess)
        {
            if (assembler == null)
            {
                throw new ArgumentNullException(nameof(assembler));
            }

            if (dataAccess == null)
            {
                throw new ArgumentNullException(nameof(dataAccess));
            }

            this.assembler = assembler;
            this.dataAccess = dataAccess;
        }

        #endregion

        #region  Public Methods

        public async Task<OrchestratorResponseWrapper<BillViewModel>> AddBill(AddBillViewModel model)
        {
            return null;
        }

        public async Task<OrchestratorResponseWrapper<ManageBillsViewModel>> GetBillInformation(Guid userId)
        {
            var response = new OrchestratorResponseWrapper<ManageBillsViewModel>();

            try
            {
                var request = assembler.NewGetBillInformationRequest(userId);
                var apiResponse = await dataAccess.GetBillInformation(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);

                    return response;
                }

                response.AddWarnings(apiResponse.Warnings);

                response.Model = assembler.NewManageBillsViewModel(apiResponse);
            }
            catch (Exception ex)
            {
                response.AddError(ex);
            }

            return response;
        }

        #endregion
    }
}