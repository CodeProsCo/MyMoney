namespace MyMoney.Web.Assemblers.Saving.Interfaces
{
    using System;
    using System.Collections.Generic;

    using DTO.Request.Saving.Goal;

    using Proxies.Saving;

    using ViewModels.Saving.Goal;

    public interface IGoalAssembler
    {
        GetGoalRequest NewGetGoalRequest(Guid goalId, string username);

        GoalViewModel ProxyToViewModel(GoalProxy proxy);

        DeleteGoalRequest NewDeleteGoalRequest(Guid goalId, string username);

        EditGoalRequest NewEditGoalRequest(GoalViewModel goal, string username);

        GetGoalsForUserRequest NewGetGoalsForUserRequest(Guid userId, string username);

        IList<GoalViewModel> ProxyToViewModel(IList<GoalProxy> goals);

        AddGoalRequest NewAddGoalRequest(GoalViewModel model, string username);
    }
}