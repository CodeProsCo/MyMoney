namespace MyMoney.Web.DataAccess.Saving.Interfaces
{
    #region Usings

    using System.Threading.Tasks;

    using DTO.Request.Saving.Goal;
    using DTO.Response.Saving.Goal;

    #endregion

    /// <summary>
    /// Interface for the <see cref="GoalDataAccess"/> class.
    /// </summary>
    public interface IGoalDataAccess
    {
        #region Methods

        /// <summary>
        /// Sends an HTTP POST request to add a goal to the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<AddGoalResponse> AddGoal(AddGoalRequest request);

        /// <summary>
        /// Sends an HTTP DELETE request to remove a goal from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<DeleteGoalResponse> DeleteGoal(DeleteGoalRequest request);

        /// <summary>
        /// Sends an HTTP POST request to modify a goal in the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<EditGoalResponse> EditGoal(EditGoalRequest request);

        /// <summary>
        /// Sends an HTTP GET request to obtain a goal from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<GetGoalResponse> GetGoal(GetGoalRequest request);

        /// <summary>
        /// Sends an HTTP GET request to obtain all the goals for a given user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<GetGoalsForUserResponse> GetGoalsForUser(GetGoalsForUserRequest request);

        #endregion
    }
}