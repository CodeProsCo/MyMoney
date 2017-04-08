namespace MyMoney.Web.Orchestrators.Saving.Interfaces
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ViewModels.Saving.Goal;

    using Wrappers;

    #endregion

    /// <summary>
    /// Interface for the <see cref="GoalOrchestrator"/> class.
    /// </summary>
    public interface IGoalOrchestrator
    {
        #region Methods

        /// <summary>
        /// Adds a goal to the database.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="username">The username.</param>
        /// <returns>The response object.</returns>
        Task<OrchestratorResponseWrapper<GoalViewModel>> AddGoal(GoalViewModel model, string username);

        /// <summary>
        /// Removes a goal from the database.
        /// </summary>
        /// <param name="goalId">The goal identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>The response object.</returns>
        Task<OrchestratorResponseWrapper<bool>> DeleteGoal(Guid goalId, string username);

        /// <summary>
        /// Modifies a goal.
        /// </summary>
        /// <param name="goal">The goal.</param>
        /// <param name="username">The username.</param>
        /// <returns>The response object.</returns>
        Task<OrchestratorResponseWrapper<GoalViewModel>> EditGoal(GoalViewModel goal, string username);

        /// <summary>
        /// Obtains a goal.
        /// </summary>
        /// <param name="goalId">The goal identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>The response object.</returns>
        Task<OrchestratorResponseWrapper<GoalViewModel>> GetGoal(Guid goalId, string username);

        /// <summary>
        /// Obtains a goal for the given user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>The response object.</returns>
        Task<OrchestratorResponseWrapper<ManageGoalsViewModel>> GetGoalsForUser(Guid userId, string username);

        #endregion
    }
}