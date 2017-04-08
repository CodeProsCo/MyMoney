namespace MyMoney.Web.Assemblers.Saving
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DTO.Request.Saving.Goal;

    using Interfaces;

    using JetBrains.Annotations;

    using Proxies.Saving;

    using ViewModels.Saving.Goal;

    #endregion

    /// <summary>
    /// The <see cref="GoalAssembler"/> class creates proxies and request objects regarding goals.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Assemblers.Saving.Interfaces.IGoalAssembler" />
    [UsedImplicitly]
    public class GoalAssembler : IGoalAssembler
    {
        #region Methods

        /// <summary>
        /// Creates a new instance of the <see cref="AddGoalRequest" /> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        /// The request object.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Exception thrown if the model or username are null.
        /// </exception>
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

        /// <summary>
        /// Creates a new instance of the <see cref="DeleteGoalRequest" /> class.
        /// </summary>
        /// <param name="goalId">The goal identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        /// The request object.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Exception thrown if the goal identifier or username are empty.
        /// </exception>
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

        /// <summary>
        /// Creates a new instance of the <see cref="EditGoalRequest" /> class.
        /// </summary>
        /// <param name="goal">The goal.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        /// The request object.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Exception thrown if the model or username are null.
        /// </exception>
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

        /// <summary>
        /// Creates a new instance of the <see cref="GetGoalRequest" /> class.
        /// </summary>
        /// <param name="goalId">The goal identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        /// The request object.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Exception thrown if the goal identifier or username are empty.
        /// </exception>
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

        /// <summary>
        /// Creates a new instance of the <see cref="GetGoalsForUserRequest" /> class.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        /// The request object.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Exception thrown if the user identifier or username are empty.
        /// </exception>
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

        /// <summary>
        /// Creates a new instance of the <see cref="GoalViewModel" /> class.
        /// </summary>
        /// <param name="proxy">The proxy.</param>
        /// <returns>
        /// The view model.
        /// </returns>
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

        /// <summary>
        /// Creates a new instance of the <see cref="GoalViewModel" /> class.
        /// </summary>
        /// <param name="goals">The goals.</param>
        /// <returns>
        /// The list of view models.
        /// </returns>
        public IList<GoalViewModel> ProxyToViewModel(IEnumerable<GoalProxy> goals)
        {
            return goals.Select(ProxyToViewModel).ToList();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="GoalProxy"/> class.
        /// </summary>
        /// <param name="goal">The goal.</param>
        /// <returns>The goal proxy.</returns>
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

        public ManageGoalsViewModel NewManageGoalsViewModel(IList<GoalProxy> goals)
        {
            var addModel = new AddGoalViewModel
            {
                Goal =
                    new GoalViewModel
                    {
                        Amount = 0,
                        Complete = false,
                        EndDate = DateTime.Now.AddMonths(6),
                        Name = string.Empty,
                        Id = Guid.Empty,
                        StartDate = DateTime.Now
                    }
            };

            var editModel = new EditGoalViewModel { Goal = new GoalViewModel() };

            var retVal = new ManageGoalsViewModel
            {
                AddGoal = addModel,
                EditGoal = editModel,
                Goals = goals.Select(ProxyToViewModel).ToList()
            };

            return retVal;
        }

        #endregion
    }
}