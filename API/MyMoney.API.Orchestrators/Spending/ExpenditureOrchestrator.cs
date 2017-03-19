namespace MyMoney.API.Orchestrators.Spending
{
    #region Usings

    using System;
    using System.Threading.Tasks;

    using Assemblers.Spending.Interfaces;

    using DataAccess.Spending.Interfaces;

    using DTO.Request.Spending.Expenditure;
    using DTO.Response.Spending.Expenditure;

    using Helpers.Error;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     The <see cref="ExpenditureOrchestrator" /> class handles CRUD operations for expenditures.
    /// </summary>
    /// <seealso cref="MyMoney.API.Orchestrators.Spending.Interfaces.IExpenditureOrchestrator" />
    [UsedImplicitly]
    public class ExpenditureOrchestrator : IExpenditureOrchestrator
    {
        #region Fields

        /// <summary>
        /// The assembler
        /// </summary>
        private readonly IExpenditureAssembler assembler;

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IExpenditureRepository repository;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenditureOrchestrator"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="assembler">The assembler.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Exception thrown if the repository or assembler are null.
        /// </exception>
        public ExpenditureOrchestrator(IExpenditureRepository repository, IExpenditureAssembler assembler)
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

        #region  Public Methods

        /// <summary>
        ///     Adds an expenditure to the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<AddExpenditureResponse> AddExpenditure(AddExpenditureRequest request, string username)
        {
            var response = new AddExpenditureResponse();

            try
            {
                var dataModel = assembler.NewExpenditureDataModel(request.Expenditure);
                var newDataModel = await repository.AddExpenditure(dataModel);

                response = assembler.NewAddExpenditureResponse(newDataModel, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "AddExpenditure");
                response.AddError(err);
            }

            return response;
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
            var response = new DeleteExpenditureResponse();

            try
            {
                var deleteSuccess = await repository.DeleteExpenditure(request.ExpenditureId);

                response = assembler.NewDeleteExpenditureResponse(deleteSuccess, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, request.Username, GetType(), "DeleteExpenditure");
                response.AddError(err);
            }

            return response;
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
            var response = new EditExpenditureResponse();

            try
            {
                var dataModel = assembler.NewExpenditureDataModel(request.Expenditure);
                var newDataModel = await repository.EditExpenditure(dataModel);

                response = assembler.NewEditExpenditureResponse(newDataModel, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, request.Username, GetType(), "EditExpenditure");
                response.AddError(err);
            }

            return response;
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
            var response = new GetExpenditureResponse();

            try
            {
                var expenditure = await repository.GetExpenditure(request.ExpenditureId);

                response = assembler.NewGetExpenditureResponse(expenditure, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, request.Username, GetType(), "GetExpenditure");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        ///     Gets all the expenditures for a given user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<GetExpendituresForUserResponse> GetExpendituresForUser(GetExpendituresForUserRequest request)
        {
            var response = new GetExpendituresForUserResponse();

            try
            {
                var expenditures = await repository.GetExpendituresForUser(request.UserId);

                response = assembler.NewGetExpendituresForUserResponse(expenditures, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, request.Username, GetType(), "GetExpendituresForUser");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        ///     Gets the expenditures for a given user for month.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<GetExpendituresForUserForMonthResponse> GetExpendituresForUserForMonth(
            GetExpendituresForUserForMonthRequest request)
        {
            var response = new GetExpendituresForUserForMonthResponse();

            try
            {
                var expenditures = await repository.GetExpendituresForUserForMonth(request.UserId);

                response = assembler.NewGetExpendituresForUserForMonthResponse(expenditures, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, request.Username, GetType(), "GetExpendituresForUserForMonth");
                response.AddError(err);
            }

            return response;
        }

        #endregion
    }
}