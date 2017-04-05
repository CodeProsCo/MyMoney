namespace MyMoney.API.Orchestrators.Saving
{
    #region Usings

    using System;
    using System.Threading.Tasks;

    using Assemblers.Saving.Interfaces;

    using DataAccess.Saving.Interfaces;

    using DTO.Request.Saving.Goal;
    using DTO.Response.Saving.Goal;

    using Helpers.Error;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    /// The <see cref="GoalOrchestrator"/> responds to requests regarding goals.
    /// </summary>
    /// <seealso cref="MyMoney.API.Orchestrators.Saving.Interfaces.IGoalOrchestrator" />
    [UsedImplicitly]
    public class GoalOrchestrator : IGoalOrchestrator
    {
        #region Fields

        /// <summary>
        /// The assembler
        /// </summary>
        private IGoalAssembler assembler;

        /// <summary>
        /// The repository
        /// </summary>
        private IGoalRepository repository;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GoalOrchestrator"/> class.
        /// </summary>
        /// <param name="assembler">The assembler.</param>
        /// <param name="repository">The repository.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Exception thrown if the assembler or repository are null.
        /// </exception>
        public GoalOrchestrator(IGoalAssembler assembler, IGoalRepository repository)
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

        #region Methods

        /// <summary>
        /// Adds a goal to the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="requestUsername">The request username.</param>
        /// <returns>
        /// The response object.
        /// </returns>
        public async Task<AddGoalResponse> AddGoal(AddGoalRequest request, string requestUsername)
        {
            var response = new AddGoalResponse();

            try
            {
                var dataModel = assembler.NewGoalDataModel(request.Goal);
                var addedModel = await repository.AddGoal(dataModel);

                response = assembler.NewAddGoalResponse(addedModel, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, requestUsername, GetType(), "AddGoal");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        /// Deletes a goal from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The response object.
        /// </returns>
        public async Task<DeleteGoalResponse> DeleteGoal(DeleteGoalRequest request)
        {
            var response = new DeleteGoalResponse();

            try
            {
                var deleteSuccess = await repository.DeleteGoal(request.GoalId);

                response = assembler.NewDeleteGoalResponse(deleteSuccess, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, request.Username, GetType(), "DeleteGoal");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        /// Updates a goal within the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The response object.
        /// </returns>
        public async Task<EditGoalResponse> EditGoal(EditGoalRequest request)
        {
            var response = new EditGoalResponse();

            try
            {
                var dataModel = assembler.NewGoalDataModel(request.Goal);
                var updatedDataModel = await repository.EditGoal(dataModel);

                response = assembler.NewEditGoalResponse(updatedDataModel, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, request.Username, GetType(), "EditGoal");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        /// Obtains a goal from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The response object.
        /// </returns>
        public async Task<GetGoalResponse> GetGoal(GetGoalRequest request)
        {
            var response = new GetGoalResponse();

            try
            {
                var dataModel = await repository.GetGoal(request.GoalId);

                response = assembler.NewGetGoalResponse(dataModel, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, request.Username, GetType(), "GetGoal");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        /// Gets the goals for a specific user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The response object.
        /// </returns>
        public async Task<GetGoalsForUserResponse> GetGoalsForUser(GetGoalsForUserRequest request)
        {
            var response = new GetGoalsForUserResponse();

            try
            {
                var goals = await repository.GetGoalsForUser(request.UserId);
                response = assembler.NewGetGoalsForUserResponse(goals, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, request.Username, GetType(), "GetGoalsForUser");
                response.AddError(err);
            }

            return response;
        }

        #endregion
    }
}