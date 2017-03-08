namespace MyMoney.API.Orchestrators.Spending
{
    #region Usings

    using System;
    using System.Threading.Tasks;

    using Assemblers.Spending.Interfaces;

    using DataAccess.Spending.Interfaces;

    using DTO.Request.Spending;
    using DTO.Response.Spending;

    using Helpers.Error;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     Handles actions regarding bills.
    /// </summary>
    /// <seealso cref="MyMoney.API.Orchestrators.Spending.Interfaces.IBillOrchestrator" />
    [UsedImplicitly]
    public class BillOrchestrator : IBillOrchestrator
    {
        #region Fields

        /// <summary>
        ///     The assembler
        /// </summary>
        private readonly IBillAssembler assembler;

        /// <summary>
        ///     The repository
        /// </summary>
        private readonly IBillRepository repository;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="BillOrchestrator" /> class.
        /// </summary>
        /// <param name="assembler">The assembler.</param>
        /// <param name="repository">The repository.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     Exception thrown when either the assembler or repository are null.
        /// </exception>
        public BillOrchestrator(IBillAssembler assembler, IBillRepository repository)
        {
            if (assembler == null)
            {
                throw new ArgumentNullException(nameof(assembler));
            }

            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            this.assembler = assembler;
            this.repository = repository;
        }

        #endregion

        #region  Public Methods

        /// <summary>
        ///     Adds a bill.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<AddBillResponse> AddBill(AddBillRequest request, string username)
        {
            var response = new AddBillResponse();

            try
            {
                var dataModel = assembler.NewBillDataModel(request.Bill);
                var bills = await repository.AddBill(dataModel);

                response = assembler.NewAddBillResponse(bills, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "AddBill");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        /// Deletes a bill.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        public async Task<DeleteBillResponse> DeleteBill(DeleteBillRequest request)
        {
            var response = new DeleteBillResponse();

            try
            {
                var success = await repository.DeleteBill(request.BillId);

                response = assembler.NewDeleteBillResponse(success, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(
                    ex, 
                    request.Username, 
                    GetType(), 
                    "DeleteBill");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        /// Edits a bill.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        public async Task<EditBillResponse> EditBill(EditBillRequest request)
        {
            var response = new EditBillResponse();

            try
            {
                var dataModel = assembler.NewBillDataModel(request.Bill);

                var model = await repository.EditBill(dataModel);

                response = assembler.NewEditBillResponse(model, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(
                    ex, 
                    request.Username, 
                    GetType(), 
                    "EditBill");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        ///     Gets the bill.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        public async Task<GetBillResponse> GetBill(GetBillRequest request)
        {
            var response = new GetBillResponse();

            try
            {
                var bill = await repository.GetBill(request.BillId);

                response = assembler.NewGetBillResponse(bill, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(
                    ex, 
                    request.Username, 
                    GetType(), 
                    "GetBill");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        ///     Gets a user's bill information.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        public async Task<GetBillsForUserResponse> GetBillsForUser(GetBillsForUserRequest request)
        {
            var response = new GetBillsForUserResponse();

            try
            {
                var bills = await repository.GetBillsForUser(request.UserId);

                response = assembler.NewGetBillsForUserResponse(bills, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(
                    ex, 
                    request.Username, 
                    GetType(), 
                    "GetBillsForUser");
                response.AddError(err);
            }

            return response;
        }

        #endregion
    }
}