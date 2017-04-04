namespace MyMoney.API.Orchestrators.Saving.Interfaces
{
    #region Usings

    using System.Threading.Tasks;

    using MyMoney.DTO.Request.Saving.Goal;
    using MyMoney.DTO.Response.Saving.Goal;

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
        /// <param name="request">The request.</param>
        /// <param name="requestUsername">The request username.</param>
        /// <returns>The response object.</returns>
        Task<AddGoalResponse> AddGoal(AddGoalRequest request, string requestUsername);

        /// <summary>
        /// Deletes a goal from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<DeleteGoalResponse> DeleteGoal(DeleteGoalRequest request);

        /// <summary>
        /// Updates a goal within the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<EditGoalResponse> EditGoal(EditGoalRequest request);

        /// <summary>
        /// Obtains a goal from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<GetGoalResponse> GetGoal(GetGoalRequest request);

        /// <summary>
        /// Gets the goals for a specific user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<GetGoalsForUserResponse> GetGoalsForUser(GetGoalsForUserRequest request);

        #endregion
    }
}