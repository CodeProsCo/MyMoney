namespace MyMoney.API.Orchestrators.Spending
{
    #region Usings

    using System;
    using System.Threading.Tasks;

    using Assemblers.Spending.Interfaces;

    using DataAccess.Spending.Interfaces;

    using DTO.Request.Spending.Expenditure;
    using DTO.Response.Spending.Expenditure;

    using Helpers.Error.Interfaces;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     The <see cref="ExpenditureOrchestrator" /> class handles CRUD operations for expenditures.
    /// </summary>
    /// <seealso cref="MyMoney.API.Orchestrators.Spending.Interfaces.IExpenditureOrchestrator" />
    [UsedImplicitly]
    public class ExpenditureOrchestrator : BaseOrchestrator, IExpenditureOrchestrator
    {
        #region Fields

        /// <summary>
        ///     The assembler
        /// </summary>
        private readonly IExpenditureAssembler assembler;

        /// <summary>
        ///     The repository
        /// </summary>
        private readonly IExpenditureRepository repository;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpenditureOrchestrator" /> class.
        /// </summary>
        /// <param name="repository">
        ///     The repository.
        /// </param>
        /// <param name="assembler">
        ///     The assembler.
        /// </param>
        /// <param name="errorHelper">
        ///     The error helper.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///     Exception thrown if the repository or assembler are null.
        /// </exception>
        public ExpenditureOrchestrator(
            IExpenditureRepository repository,
            IExpenditureAssembler assembler,
            IErrorHelper errorHelper)
            : base(errorHelper)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (assembler == null)
            {
                throw new ArgumentNullException(nameof(assembler));
            }

            this.repository = repository;
            this.assembler = assembler;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Adds an expenditure to the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<AddExpenditureResponse> AddExpenditure(AddExpenditureRequest request)
        {
            return await Orchestrate(async delegate {
                var dataModel = assembler.NewExpenditureDataModel(request.Expenditure);
                var newDataModel = await repository.AddExpenditure(dataModel);

                return assembler.NewAddExpenditureResponse(newDataModel, request.RequestReference);
            }, request);
        }

        /// <summary>
        ///     Removes an expenditure from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<DeleteExpenditureResponse> DeleteExpenditure(DeleteExpenditureRequest request)
        {
            return await Orchestrate(async delegate {
                var deleteSuccess = await repository.DeleteExpenditure(request.ExpenditureId);

                return assembler.NewDeleteExpenditureResponse(deleteSuccess, request.RequestReference);
            }, request);
        }

        /// <summary>
        ///     Updates an expenditure in the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<EditExpenditureResponse> EditExpenditure(EditExpenditureRequest request)
        {
            return await Orchestrate(async delegate {
                var dataModel = assembler.NewExpenditureDataModel(request.Expenditure);
                var newDataModel = await repository.EditExpenditure(dataModel);

                return assembler.NewEditExpenditureResponse(newDataModel, request.RequestReference);
            }, request);
        }

        /// <summary>
        ///     Obtains an expenditure from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<GetExpenditureResponse> GetExpenditure(GetExpenditureRequest request)
        {
            return await Orchestrate(async delegate {
                var expenditure = await repository.GetExpenditure(request.ExpenditureId);

                return assembler.NewGetExpenditureResponse(expenditure, request.RequestReference);
            }, request);
        }

        /// <summary>
        ///     Gets all the expenditures for a given user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<GetExpenditureForUserResponse> GetExpenditureForUser(GetExpenditureForUserRequest request)
        {
            return await Orchestrate(async delegate{
                var expenditure = await repository.GetExpenditureForUser(request.UserId);

                return assembler.NewGetExpenditureForUserResponse(expenditure, request.RequestReference);
            }, request);
        }

        /// <summary>
        ///     Gets the expenditures for a given user for month.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<GetExpenditureForUserForMonthResponse> GetExpenditureForUserForMonth(
            GetExpenditureForUserForMonthRequest request)
        {
            return await Orchestrate(async delegate {
                var expenditure = await repository.GetExpenditureForUserForMonth(request.UserId);

                return assembler.NewGetExpenditureForUserForMonthResponse(expenditure, request.RequestReference);
            }, request);
        }

        #endregion
    }
}