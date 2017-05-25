namespace MyMoney.API.Orchestrators.Saving
{
    #region Usings

    using System;
    using System.Threading.Tasks;

    using Assemblers.Saving.Interfaces;

    using DataAccess.Saving.Interfaces;

    using DTO.Request.Saving.Goal;
    using DTO.Response.Saving.Goal;

    using Helpers.Error.Interfaces;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     The <see cref="GoalOrchestrator" /> responds to requests regarding goals.
    /// </summary>
    /// <seealso cref="MyMoney.API.Orchestrators.Saving.Interfaces.IGoalOrchestrator" />
    [UsedImplicitly]
    public class GoalOrchestrator : BaseOrchestrator, IGoalOrchestrator
    {
        #region Fields

        /// <summary>
        ///     The assembler
        /// </summary>
        private readonly IGoalAssembler assembler;

        /// <summary>
        ///     The repository
        /// </summary>
        private readonly IGoalRepository repository;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GoalOrchestrator"/> class.
        /// </summary>
        /// <param name="assembler">
        /// The assembler.
        /// </param>
        /// <param name="repository">
        /// The repository.
        /// </param>
        /// <param name="errorHelper">
        /// The error helper.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Exception thrown if the assembler or repository are null.
        /// </exception>
        public GoalOrchestrator(IGoalAssembler assembler, IGoalRepository repository, IErrorHelper errorHelper) : base(errorHelper)
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
        ///     Adds a goal to the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<AddGoalResponse> AddGoal(AddGoalRequest request)
        {
            return await Orchestrate(async delegate {
                var dataModel = assembler.NewGoalDataModel(request.Goal);
                var addedModel = await repository.AddGoal(dataModel);

                return assembler.NewAddGoalResponse(addedModel, request.RequestReference);
            }, request);
        }


        /// <summary>
        ///     Modifies a goal in the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<EditGoalResponse> EditGoal(EditGoalRequest request)
        {
            return await Orchestrate(async delegate {
                var dataModel = assembler.NewGoalDataModel(request.Goal);
                var editedModel = await repository.Edit(dataModel);

                return assembler.NewEditGoalResponse(editedModel, request.RequestReference);
            }, request);
        }

        /// <summary>
        ///     Deletes a goal from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<DeleteGoalResponse> DeleteGoal(DeleteGoalRequest request)
        {
            return await Orchestrate(async delegate {
                var deleteSuccess = await repository.DeleteGoal(request.GoalId);

                return assembler.NewDeleteGoalResponse(deleteSuccess, request.RequestReference);
            }, request);
        }

        /// <summary>
        ///     Obtains a goal from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<GetGoalResponse> GetGoal(GetGoalRequest request)
        {
            return await Orchestrate(async delegate {
                var dataModel = await repository.GetGoal(request.GoalId);

                return assembler.NewGetGoalResponse(dataModel, request.RequestReference);
            }, request);
        }

        /// <summary>
        ///     Gets the goals for a specific user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<GetGoalsForUserResponse> GetGoalsForUser(GetGoalsForUserRequest request)
        {
            return await Orchestrate(async delegate {
                var goals = await repository.GetGoalsForUser(request.UserId);
                
                return assembler.NewGetGoalsForUserResponse(goals, request.RequestReference);
            }, request);
        }

        #endregion
    }
}