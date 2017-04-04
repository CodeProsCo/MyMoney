namespace MyMoney.API.Orchestrators.Saving.Interfaces
{
    #region Usings

    using System.Threading.Tasks;

    using MyMoney.DTO.Request.Saving.Goal;
    using MyMoney.DTO.Response.Saving.Goal;

    #endregion

    public interface IGoalOrchestrator
    {
        #region Methods

        Task<AddGoalResponse> AddGoal(AddGoalRequest request, string requestUsername);

        Task<DeleteGoalResponse> DeleteGoal(DeleteGoalRequest request);

        Task<EditGoalResponse> EditGoal(EditGoalRequest request);

        Task<GetGoalResponse> GetGoal(GetGoalRequest request);

        Task<GetGoalsForUserResponse> GetGoalsForUser(GetGoalsForUserRequest request);

        #endregion
    }
}