namespace MyMoney.Web.DataAccess.Saving.Interfaces
{
    #region Usings

    using System.Threading.Tasks;

    using MyMoney.DTO.Request.Saving.Goal;
    using MyMoney.DTO.Response.Saving.Goal;

    #endregion

    public interface IGoalDataAccess
    {
        #region Methods

        Task<DeleteGoalResponse> DeleteGoal(DeleteGoalRequest request);

        Task<EditGoalResponse> EditGoal(EditGoalRequest request);

        Task<GetGoalResponse> GetGoal(GetGoalRequest request);

        Task<GetGoalsForUserResponse> GetGoalsForUser(GetGoalsForUserRequest request);

        #endregion
    }
}