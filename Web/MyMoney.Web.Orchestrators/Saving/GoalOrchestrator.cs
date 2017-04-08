namespace MyMoney.Web.Orchestrators.Saving
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Assemblers.Saving.Interfaces;

    using DataAccess.Saving.Interfaces;

    using Helpers.Error;

    using Interfaces;

    using JetBrains.Annotations;

    using ViewModels.Saving.Goal;

    using Wrappers;

    #endregion

    /// <summary>
    /// The <see cref="GoalOrchestrator"/> class performs actions regarding goals.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Orchestrators.Saving.Interfaces.IGoalOrchestrator" />
    [UsedImplicitly]
    public class GoalOrchestrator : IGoalOrchestrator
    {
        #region Fields

        /// <summary>
        /// The assembler
        /// </summary>
        private readonly IGoalAssembler assembler;

        /// <summary>
        /// The data access
        /// </summary>
        private readonly IGoalDataAccess dataAccess;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GoalOrchestrator"/> class.
        /// </summary>
        /// <param name="dataAccess">The data access.</param>
        /// <param name="assembler">The assembler.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Exception thrown if that data access or assembler are null.
        /// </exception>
        public GoalOrchestrator(IGoalDataAccess dataAccess, IGoalAssembler assembler)
        {
            if (dataAccess == null)
            {
                throw new ArgumentNullException(nameof(dataAccess));
            }

            if (assembler == null)
            {
                throw new ArgumentNullException(nameof(assembler));
            }

            this.dataAccess = dataAccess;
            this.assembler = assembler;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a goal to the database.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        /// The response object.
        /// </returns>
        public async Task<OrchestratorResponseWrapper<GoalViewModel>> AddGoal(GoalViewModel model, string username)
        {
            var response = new OrchestratorResponseWrapper<GoalViewModel>();

            try
            {
                var request = assembler.NewAddGoalRequest(model, username);
                var apiResponse = await dataAccess.AddGoal(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);
                }
                else
                {
                    response.Model = assembler.ProxyToViewModel(apiResponse.Goal);
                }

                response.AddWarnings(apiResponse.Warnings);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "AddGoal");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        /// Removes a goal from the database.
        /// </summary>
        /// <param name="goalId">The goal identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        /// The response object.
        /// </returns>
        public async Task<OrchestratorResponseWrapper<bool>> DeleteGoal(Guid goalId, string username)
        {
            var response = new OrchestratorResponseWrapper<bool>();

            try
            {
                var request = assembler.NewDeleteGoalRequest(goalId, username);
                var apiResponse = await dataAccess.DeleteGoal(request);

                response.AddErrors(apiResponse.Errors);
                response.AddWarnings(apiResponse.Warnings);

                response.Model = apiResponse.DeleteSuccess || apiResponse.Success;
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "DeleteGoal");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        /// Modifies a goal.
        /// </summary>
        /// <param name="goal">The goal.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        /// The response object.
        /// </returns>
        public async Task<OrchestratorResponseWrapper<GoalViewModel>> EditGoal(GoalViewModel goal, string username)
        {
            var response = new OrchestratorResponseWrapper<GoalViewModel>();

            try
            {
                var request = assembler.NewEditGoalRequest(goal, username);
                var apiResponse = await dataAccess.EditGoal(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);
                }
                else
                {
                    response.Model = assembler.ProxyToViewModel(apiResponse.Goal);
                }

                response.AddWarnings(apiResponse.Warnings);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "EditGoal");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        /// Obtains a goal.
        /// </summary>
        /// <param name="goalId">The goal identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        /// The response object.
        /// </returns>
        public async Task<OrchestratorResponseWrapper<GoalViewModel>> GetGoal(Guid goalId, string username)
        {
            var response = new OrchestratorResponseWrapper<GoalViewModel>();

            try
            {
                var request = assembler.NewGetGoalRequest(goalId, username);
                var apiResponse = await dataAccess.GetGoal(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);
                }
                else
                {
                    response.Model = assembler.ProxyToViewModel(apiResponse.Goal);
                }

                response.AddWarnings(apiResponse.Warnings);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "GetGoal");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        /// Obtains a goal for the given user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        /// The response object.
        /// </returns>
        public async Task<OrchestratorResponseWrapper<ManageGoalsViewModel>> GetGoalsForUser(
            Guid userId,
            string username)
        {
            var response = new OrchestratorResponseWrapper<ManageGoalsViewModel>();

            try
            {
                var request = assembler.NewGetGoalsForUserRequest(userId, username);
                var apiResponse = await dataAccess.GetGoalsForUser(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);
                }
                else
                {
                    response.Model = assembler.NewManageGoalsViewModel(apiResponse.Goals);
                }

                response.AddWarnings(apiResponse.Warnings);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "GetGoalsForUser");
                response.AddError(err);
            }

            return response;
        }

        #endregion
    }
}