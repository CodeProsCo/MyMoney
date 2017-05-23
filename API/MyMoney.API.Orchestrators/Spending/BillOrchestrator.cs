namespace MyMoney.API.Orchestrators.Spending
{
    #region Usings

    using System;
    using System.Threading.Tasks;

    using Assemblers.Spending.Interfaces;

    using DataAccess.Spending.Interfaces;

    using DataTransformers.Spending.Interfaces;

    using DTO.Request.Spending.Bill;
    using DTO.Response.Spending.Bill;

    using Helpers.Error.Interfaces;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     Handles actions regarding bills.
    /// </summary>
    /// <seealso cref="MyMoney.API.Orchestrators.Spending.Interfaces.IBillOrchestrator" />
    [UsedImplicitly]
    public class BillOrchestrator : BaseOrchestrator, IBillOrchestrator
    {
        #region Fields

        /// <summary>
        ///     The assembler
        /// </summary>
        private readonly IBillAssembler assembler;

        /// <summary>
        ///     The data transformer
        /// </summary>
        private readonly IBillDataTransformer dataTransformer;

        /// <summary>
        ///     The repository
        /// </summary>
        private readonly IBillRepository repository;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="BillOrchestrator" /> class.
        /// </summary>
        /// <param name="assembler">
        ///     The assembler.
        /// </param>
        /// <param name="repository">
        ///     The repository.
        /// </param>
        /// <param name="dataTransformer">
        ///     The data transformer.
        /// </param>
        /// <param name="errorHelper">
        ///     The error helper.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///     Exception thrown when either the assembler, repository or data transformer are null.
        /// </exception>
        public BillOrchestrator(
            IBillAssembler assembler,
            IBillRepository repository,
            IBillDataTransformer dataTransformer,
            IErrorHelper errorHelper)
            : base(errorHelper)
        {
            if (assembler == null)
            {
                throw new ArgumentNullException(nameof(assembler));
            }

            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (dataTransformer == null)
            {
                throw new ArgumentNullException(nameof(dataTransformer));
            }

            this.assembler = assembler;
            this.dataTransformer = dataTransformer;
            this.repository = repository;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Adds a bill.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<AddBillResponse> AddBill(AddBillRequest request)
        {
           return await Orchestrate(async delegate {
               var dataModel = assembler.NewBillDataModel(request.Bill);
               var bill = await repository.AddBill(dataModel);

               return assembler.NewAddBillResponse(bill, request.RequestReference);
           }, request.Username);
        }

        /// <summary>
        ///     Deletes a bill.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        public async Task<DeleteBillResponse> DeleteBill(DeleteBillRequest request)
        {
            return await Orchestrate(async delegate {
                var success = await repository.DeleteBill(request.BillId);

                return assembler.NewDeleteBillResponse(success, request.RequestReference);
            }, username);
        }

        /// <summary>
        ///     Edits a bill.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        public async Task<EditBillResponse> EditBill(EditBillRequest request)
        {
            return await Orchestrate(async delegate {
                var dataModel = assembler.NewBillDataModel(request.Bill);
                var model = await repository.EditBill(dataModel);

                return assembler.NewEditBillResponse(model, request.RequestReference);
            }, request.Username);
        }

        /// <summary>
        ///     Gets the bill.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        public async Task<GetBillResponse> GetBill(GetBillRequest request)
        {
            return await Orchestrate(async delegate {
                var bill = await repository.GetBill(request.BillId);

                return assembler.NewGetBillResponse(bill, request.RequestReference);
            }, request.Username);
        }

        /// <summary>
        ///     Gets a user's bill information.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        public async Task<GetBillsForUserResponse> GetBillsForUser(GetBillsForUserRequest request)
        {
            return await Orchestrate(async delegate {
                var bills = await repository.GetBillsForUser(request.UserId);

                return assembler.NewGetBillsForUserResponse(bills, request.RequestReference);
            }, request.Username);
        }

        /// <summary>
        ///     Gets the bills for the given user for the given month.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<GetBillsForUserForMonthResponse> GetBillsForUserForMonth(
            GetBillsForUserForMonthRequest request)
        {
            return await Orchestrate(async delegate {
                var bills = await repository.GetBillsForUser(request.UserId);
                var data = dataTransformer.GetOutgoingBillsForMonth(request.MonthNumber, bills);

                return assembler.NewGetBillsForUserForMonthResponse(data, request.RequestReference);
            }, request.Username);
        }

        #endregion
    }
}