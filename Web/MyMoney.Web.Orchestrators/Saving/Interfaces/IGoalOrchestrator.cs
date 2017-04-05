namespace MyMoney.Web.Orchestrators.Saving.Interfaces
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ViewModels.Saving.Goal;

    using Wrappers;

    #endregion

    public interface IGoalOrchestrator
    {
        #region Methods

        Task<OrchestratorResponseWrapper<GoalViewModel>> AddGoal(GoalViewModel model, string username);

        Task<OrchestratorResponseWrapper<bool>> DelteGoal(Guid goalId, string username);

        Task<OrchestratorResponseWrapper<GoalViewModel>> EditGoal(GoalViewModel goal, string username);

        Task<OrchestratorResponseWrapper<GoalViewModel>> GetGoal(Guid goalId, string username);

        Task<OrchestratorResponseWrapper<IList<GoalViewModel>>> GetGoalsForUser(Guid userId, string username);

        #endregion
    }
}