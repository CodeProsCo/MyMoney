namespace MyMoney.Web.Assemblers.Saving
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DTO.Request.Saving.Goal;

    using Interfaces;

    using Proxies.Saving;

    using ViewModels.Saving.Goal;

    #endregion

    public class GoalAssembler : IGoalAssembler
    {
        #region Methods

        public AddGoalRequest NewAddGoalRequest(GoalViewModel model, string username)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            return new AddGoalRequest { Goal = ViewModelToProxy(model), Username = username };
        }

        public DeleteGoalRequest NewDeleteGoalRequest(Guid goalId, string username)
        {
            if (goalId.Equals(Guid.Empty))
            {
                throw new ArgumentNullException(nameof(goalId));
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            return new DeleteGoalRequest { GoalId = goalId, Username = username };
        }

        public EditGoalRequest NewEditGoalRequest(GoalViewModel goal, string username)
        {
            if (goal == null)
            {
                throw new ArgumentNullException(nameof(goal));
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            return new EditGoalRequest { Goal = ViewModelToProxy(goal), Username = username };
        }

        public GetGoalRequest NewGetGoalRequest(Guid goalId, string username)
        {
            if (goalId.Equals(Guid.Empty))
            {
                throw new ArgumentNullException(nameof(goalId));
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            return new GetGoalRequest { GoalId = goalId, Username = username };
        }

        public GetGoalsForUserRequest NewGetGoalsForUserRequest(Guid userId, string username)
        {
            if (userId.Equals(Guid.Empty))
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            return new GetGoalsForUserRequest { UserId = userId, Username = username };
        }

        public GoalViewModel ProxyToViewModel(GoalProxy proxy)
        {
            return new GoalViewModel
            {
                Id = proxy.Id,
                UserId = proxy.UserId,
                Amount = proxy.Amount,
                Complete = proxy.Complete,
                StartDate = proxy.StartDate,
                Name = proxy.Name,
                EndDate = proxy.EndDate
            };
        }

        public IList<GoalViewModel> ProxyToViewModel(IList<GoalProxy> goals)
        {
            return goals.Select(ProxyToViewModel).ToList();
        }

        private static GoalProxy ViewModelToProxy(GoalViewModel goal)
        {
            return new GoalProxy
            {
                Amount = goal.Amount,
                Complete = goal.Complete,
                EndDate = goal.EndDate,
                Id = goal.Id,
                Name = goal.Name,
                StartDate = goal.StartDate,
                UserId = goal.UserId
            };
        }

        #endregion
    }
}