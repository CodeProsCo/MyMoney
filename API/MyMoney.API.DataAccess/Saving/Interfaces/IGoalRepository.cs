namespace MyMoney.API.DataAccess.Saving.Interfaces
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyMoney.DataModels.Saving;

    #endregion

    public interface IGoalRepository
    {
        #region Methods

        Task<bool> DeleteGoal(Guid goalId);

        Task<GoalDataModel> EditGoal(GoalDataModel model);

        Task<GoalDataModel> GetGoal(Guid goalId);

        Task<IList<GoalDataModel>> GetGoalsForUser(Guid userId);

        Task<GoalDataModel> AddGoal(GoalDataModel model);

        #endregion
    }
}