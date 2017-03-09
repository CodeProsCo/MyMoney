namespace MyMoney.Web.Orchestrators.Spending
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Assemblers.Spending.Interfaces;

    using DataAccess.Spending.Interfaces;

    using Helpers.Error;

    using Interfaces;

    using JetBrains.Annotations;

    using ViewModels.Spending.Bills;

    using Wrappers;

    #endregion

    /// <summary>
    ///     The bill orchestrator assembles and sends requests regarding bills and returns their responses.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Orchestrators.Spending.Interfaces.IBillOrchestrator" />
    [UsedImplicitly]
    public class BillOrchestrator : IBillOrchestrator
    {
        #region Fields

        /// <summary>
        ///     The assembler
        /// </summary>
        private readonly IBillAssembler assembler;

        /// <summary>
        ///     The data access
        /// </summary>
        private readonly IBillDataAccess dataAccess;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="BillOrchestrator" /> class.
        /// </summary>
        /// <param name="assembler">The assembler.</param>
        /// <param name="dataAccess">The data access.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     Exception thrown when the assembler or data access objects are null.
        /// </exception>
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

        /// <summary>
        ///     Builds and sends a request to add a bill to the database.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<OrchestratorResponseWrapper<BillViewModel>> AddBill(BillViewModel model, string username)
        {
            var response = new OrchestratorResponseWrapper<BillViewModel>();

            try
            {
                var request = assembler.NewAddBillRequest(model, username);
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

        /// <summary>
        ///     Builds and sends a request to delete a bill from the database.
        /// </summary>
        /// <param name="billId">The bill Id.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<OrchestratorResponseWrapper<bool>> DeleteBill(Guid billId, string username)
        {
            var response = new OrchestratorResponseWrapper<bool>();

            try
            {
                var request = assembler.NewDeleteBillRequest(billId, username);

                var apiResponse = await dataAccess.DeleteBill(request);

                if (!apiResponse.Success || !apiResponse.DeleteSuccess)
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

        /// <summary>
        ///     Builds and sends a request to edit a bill from the database.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
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

        /// <summary>
        ///     Builds and sends a request to obtain a bill from the database.
        /// </summary>
        /// <param name="billId">The bill Id.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
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

        /// <summary>
        ///     Builds and sends a request to obtain bills for a specific user from the database.
        /// </summary>
        /// <param name="userId">The user Id.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<OrchestratorResponseWrapper<ManageBillsViewModel>> GetBillsForUser(
            Guid userId, 
            string username)
        {
            var response = new OrchestratorResponseWrapper<ManageBillsViewModel>();

            try
            {
                var request = assembler.NewGetBillsForUserRequest(userId, username);
                var apiResponse = await dataAccess.GetBillsForUser(request);

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
                var err = ErrorHelper.Create(ex, username, GetType(), "GetBillsForUser");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        ///     Builds and sends a request to obtain bills for a specific user for a given month from the database.
        /// </summary>
        /// <param name="monthNumber">The month number.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<OrchestratorResponseWrapper<IList<KeyValuePair<DateTime, double>>>> GetBillsForUserForMonth(
            int monthNumber, 
            Guid userId, 
            string username)
        {
            var response = new OrchestratorResponseWrapper<IList<KeyValuePair<DateTime, double>>>();

            try
            {
                var request = assembler.NewGetBillsForUserForMonthRequest(monthNumber, userId, username);
                var apiResponse = await dataAccess.GetBillsForUserForMonth(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);

                    return response;
                }

                response.Model = apiResponse.Data;
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "GetBillsForUserForMonth");
                response.AddError(err);
            }

            return response;
        }

        #endregion
    }
}