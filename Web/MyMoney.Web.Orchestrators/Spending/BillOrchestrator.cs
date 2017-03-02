namespace MyMoney.Web.Orchestrators.Spending
{
    #region Usings

    using System;
    using System.Threading.Tasks;

    using Assemblers.Spending.Interfaces;

    using DataAccess.Spending.Interfaces;

    using Helpers.Error;

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

        public async Task<OrchestratorResponseWrapper<BillViewModel>> AddBill(BillViewModel model, string username)
        {
            var response = new OrchestratorResponseWrapper<BillViewModel>();

            try
            {
                var request = assembler.NewAddBillRequest(model);
                var apiResponse = await dataAccess.AddBill(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);

                    return response;
                }

                response.AddWarnings(apiResponse.Warnings);

                response.Model = assembler.NewBillViewModel(apiResponse);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "AddBill");
                response.AddError(err);
            }

            return response;
        }

        public async Task<OrchestratorResponseWrapper<BillViewModel>> GetBill(Guid billId, string username)
        {
            var response = new OrchestratorResponseWrapper<BillViewModel>();

            try
            {
                var request = assembler.NewGetBillRequest(billId, username);

                var apiResponse = await dataAccess.GetBill(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);

                    return response;
                }

                response.AddWarnings(apiResponse.Warnings);

                response.Model = assembler.NewBillViewModel(apiResponse);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "GetBill");
                response.AddError(err);
            }

            return response;
        }

        public async Task<OrchestratorResponseWrapper<ManageBillsViewModel>> GetBillInformation(
            Guid userId, 
            string username)
        {
            var response = new OrchestratorResponseWrapper<ManageBillsViewModel>();

            try
            {
                var request = assembler.NewGetBillInformationRequest(userId, username);
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
                var err = ErrorHelper.Create(ex, username, GetType(), "GetBillInformation");
                response.AddError(err);
            }

            return response;
        }

        public async Task<OrchestratorResponseWrapper<bool>> DeleteBill(Guid billId, string username)
        {
            var response = new OrchestratorResponseWrapper<bool>();

            try
            {
                var request = assembler.NewDeleteBillRequest(billId, username);

                var apiResponse = await dataAccess.DeleteBill(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);

                    return response;
                }

                response.AddWarnings(apiResponse.Warnings);

                response.Model = apiResponse.Success;
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "DeleteBill");
                response.AddError(err);
            }

            return response;
        }

        public async Task<OrchestratorResponseWrapper<BillViewModel>> EditBill(BillViewModel model, string username)
        {
            var response = new OrchestratorResponseWrapper<BillViewModel>();

            try
            {
                var request = assembler.NewEditBillRequest(model, username);
                var apiResponse = await dataAccess.EditBill(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);

                    return response;
                }

                response.AddWarnings(apiResponse.Warnings);

                response.Model = assembler.NewBillViewModel(apiResponse);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "EditBill");
                response.AddError(err);
            }

            return response;
        }

        #endregion
    }
}