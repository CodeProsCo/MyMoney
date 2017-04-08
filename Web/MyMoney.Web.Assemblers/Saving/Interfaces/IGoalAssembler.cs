namespace MyMoney.Web.Assemblers.Saving.Interfaces
{
    using System;
    using System.Collections.Generic;

    using DTO.Request.Saving.Goal;

    using Proxies.Saving;

    using ViewModels.Saving.Goal;

    /// <summary>
    /// Interface for the <see cref="GoalAssembler"/> class.
    /// </summary>
    public interface IGoalAssembler
    {
        /// <summary>
        /// Creates a new instance of the <see cref="GetGoalRequest"/> class.
        /// </summary>
        /// <param name="goalId">The goal identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>The request object.</returns>
        GetGoalRequest NewGetGoalRequest(Guid goalId, string username);

        /// <summary>
        /// Creates a new instance of the <see cref="GoalViewModel"/> class.
        /// </summary>
        /// <param name="proxy">The proxy.</param>
        /// <returns>The view model.</returns>
        GoalViewModel ProxyToViewModel(GoalProxy proxy);

        /// <summary>
        /// Creates a new instance of the <see cref="DeleteGoalRequest"/> class.
        /// </summary>
        /// <param name="goalId">The goal identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>The request object.</returns>
        DeleteGoalRequest NewDeleteGoalRequest(Guid goalId, string username);

        /// <summary>
        /// Creates a new instance of the <see cref="EditGoalRequest"/> class.
        /// </summary>
        /// <param name="goal">The goal.</param>
        /// <param name="username">The username.</param>
        /// <returns>The request object.</returns>
        EditGoalRequest NewEditGoalRequest(GoalViewModel goal, string username);

        /// <summary>
        /// Creates a new instance of the <see cref="GetGoalsForUserRequest"/> class.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>The request object.</returns>
        GetGoalsForUserRequest NewGetGoalsForUserRequest(Guid userId, string username);

        /// <summary>
        /// Creates a new instance of the <see cref="GoalViewModel"/> class.
        /// </summary>
        /// <param name="goals">The goals.</param>
        /// <returns>The list of view models.</returns>
        IList<GoalViewModel> ProxyToViewModel(IEnumerable<GoalProxy> goals);

        /// <summary>
        /// Creates a new instance of the <see cref="AddGoalRequest"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="username">The username.</param>
        /// <returns>The request object.</returns>
        AddGoalRequest NewAddGoalRequest(GoalViewModel model, string username);
    }
}