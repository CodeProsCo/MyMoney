namespace MyMoney.Web.Orchestrators.Spending
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using JetBrains.Annotations;

    using MyMoney.Helpers.Error;
    using MyMoney.ViewModels.Spending.Expenditure;
    using MyMoney.Web.Assemblers.Spending.Interfaces;
    using MyMoney.Web.DataAccess.Spending.Interfaces;
    using MyMoney.Web.Orchestrators.Spending.Interfaces;
    using MyMoney.Wrappers;

    #endregion

    /// <summary>
    ///     The expenditure orchestrator assembles and sends requests regarding expenditure and returns their responses.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Orchestrators.Spending.Interfaces.IExpenditureOrchestrator" />
    [UsedImplicitly]
    public class ExpenditureOrchestrator : IExpenditureOrchestrator
    {
        #region Fields

        /// <summary>
        ///     The assembler
        /// </summary>
        private readonly IExpenditureAssembler assembler;

        /// <summary>
        ///     The data access
        /// </summary>
        private readonly IExpenditureDataAccess dataAccess;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpenditureOrchestrator" /> class.
        /// </summary>
        /// <param name="assembler">The assembler.</param>
        /// <param name="dataAccess">The data access.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     Exception thrown when the assembler or data access objects are null.
        /// </exception>
        public ExpenditureOrchestrator(IExpenditureAssembler assembler, IExpenditureDataAccess dataAccess)
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

        #region Methods

        /// <summary>
        ///     Builds and sends a request to add a expenditure to the database.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<OrchestratorResponseWrapper<ExpenditureViewModel>> AddExpenditure(
            ExpenditureViewModel model,
            string username)
        {
            var response = new OrchestratorResponseWrapper<ExpenditureViewModel>();

            try
            {
                var request = assembler.NewAddExpenditureRequest(model, username);
                var apiResponse = await dataAccess.AddExpenditure(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);

                    return response;
                }

                response.AddWarnings(apiResponse.Warnings);

                response.Model = assembler.NewExpenditureViewModel(apiResponse);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "AddExpenditure");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        ///     Builds and sends a request to delete a expenditure from the database.
        /// </summary>
        /// <param name="expenditureId">The expenditure Id.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<OrchestratorResponseWrapper<bool>> DeleteExpenditure(Guid expenditureId, string username)
        {
            var response = new OrchestratorResponseWrapper<bool>();

            try
            {
                var request = assembler.NewDeleteExpenditureRequest(expenditureId, username);

                var apiResponse = await dataAccess.DeleteExpenditure(request);

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
                var err = ErrorHelper.Create(ex, username, GetType(), "DeleteExpenditure");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        ///     Builds and sends a request to edit a expenditure from the database.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<OrchestratorResponseWrapper<ExpenditureViewModel>> EditExpenditure(
            ExpenditureViewModel model,
            string username)
        {
            var response = new OrchestratorResponseWrapper<ExpenditureViewModel>();

            try
            {
                var request = assembler.NewEditExpenditureRequest(model, username);
                var apiResponse = await dataAccess.EditExpenditure(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);

                    return response;
                }

                response.AddWarnings(apiResponse.Warnings);

                response.Model = assembler.NewExpenditureViewModel(apiResponse);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "EditExpenditure");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        ///     Builds and sends a request to obtain a expenditure from the database.
        /// </summary>
        /// <param name="expenditureId">The expenditure Id.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<OrchestratorResponseWrapper<ExpenditureViewModel>> GetExpenditure(
            Guid expenditureId,
            string username)
        {
            var response = new OrchestratorResponseWrapper<ExpenditureViewModel>();

            try
            {
                var request = assembler.NewGetExpenditureRequest(expenditureId, username);

                var apiResponse = await dataAccess.GetExpenditure(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);

                    return response;
                }

                response.AddWarnings(apiResponse.Warnings);

                response.Model = assembler.NewExpenditureViewModel(apiResponse);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "GetExpenditure");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        ///     Builds and sends a request to obtain expenditure for a specific user from the database.
        /// </summary>
        /// <param name="userId">The user Id.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<OrchestratorResponseWrapper<TrackExpenditureViewModel>> GetExpenditureForUser(
            Guid userId,
            string username)
        {
            var response = new OrchestratorResponseWrapper<TrackExpenditureViewModel>();

            try
            {
                var request = assembler.NewGetExpenditureForUserRequest(userId, username);
                var apiResponse = await dataAccess.GetExpendituresForUser(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);

                    return response;
                }

                response.AddWarnings(apiResponse.Warnings);

                response.Model = assembler.NewTrackExpenditureViewModel(apiResponse);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "GetExpenditureForUser");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        ///     Builds and sends a request to obtain expenditure for a specific user for a given month from the database.
        /// </summary>
        /// <param name="monthNumber">The month number.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<OrchestratorResponseWrapper<IList<ExpenditureViewModel>>> GetExpenditureForUserForMonth(
            int monthNumber,
            Guid userId,
            string username)
        {
            var response = new OrchestratorResponseWrapper<IList<ExpenditureViewModel>>();

            try
            {
                var request = assembler.NewGetExpenditureForUserForMonthRequest(monthNumber, userId, username);
                var apiResponse = await dataAccess.GetExpendituresForUserForMonth(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);

                    return response;
                }

                response.Model = assembler.NewExpenditureViewModelList(apiResponse);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "GetExpenditureForUserForMonth");
                response.AddError(err);
            }

            return response;
        }

        #endregion
    }
}