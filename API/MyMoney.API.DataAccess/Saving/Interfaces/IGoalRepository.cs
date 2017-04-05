namespace MyMoney.API.DataAccess.Saving.Interfaces
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DataModels.Saving;

    #endregion

    /// <summary>
    /// Interface for the <see cref="GoalRepository"/> class.
    /// </summary>
    public interface IGoalRepository
    {
        #region Methods

        /// <summary>
        /// Adds a goal to the database.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The newly added goal.</returns>
        Task<GoalDataModel> AddGoal(GoalDataModel model);

        /// <summary>
        /// Deletes a goal from the database.
        /// </summary>
        /// <param name="goalId">The goal identifier.</param>
        /// <returns>If true, deletion was successful. False if not.</returns>
        Task<bool> DeleteGoal(Guid goalId);

        /// <summary>
        /// Updates a goal in the database.
        /// </summary>
        /// <param name="model">The updated model.</param>
        /// <returns>The updated data model.</returns>
        Task<GoalDataModel> EditGoal(GoalDataModel model);

        /// <summary>
        /// Obtains a goal from the database with the given identifier.
        /// </summary>
        /// <param name="goalId">The goal identifier.</param>
        /// <returns>The goal.</returns>
        Task<GoalDataModel> GetGoal(Guid goalId);

        /// <summary>
        /// Gets all goals for a given user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The list of goals.</returns>
        Task<IList<GoalDataModel>> GetGoalsForUser(Guid userId);

        #endregion
    }
}