namespace MyMoney.Web.DataAccess.Saving
{
    #region Usings

    using System.Threading.Tasks;

    using MyMoney.DTO.Request.Saving.Goal;
    using MyMoney.DTO.Response.Saving.Goal;
    using MyMoney.Web.DataAccess.Saving.Interfaces;

    #endregion

    public class GoalDataAccess : BaseDataAccess, IGoalDataAccess
    {
        #region Methods

        public async Task<DeleteGoalResponse> DeleteGoal(DeleteGoalRequest request)
        {
            return await Delete<DeleteGoalResponse>(request.FormatRequestUri(), request.Username);
        }

        public async Task<EditGoalResponse> EditGoal(EditGoalRequest request)
        {
            return await Post<EditGoalResponse>(request);
        }

        public async Task<GetGoalResponse> GetGoal(GetGoalRequest request)
        {
            return await Get<GetGoalResponse>(request.FormatRequestUri(), request.Username);
        }

        public async Task<GetGoalsForUserResponse> GetGoalsForUser(GetGoalsForUserRequest request)
        {
            return await Get<GetGoalsForUserResponse>(request.GetAction(), request.Username);
        }

        #endregion
    }
}