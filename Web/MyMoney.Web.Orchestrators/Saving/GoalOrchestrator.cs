namespace MyMoney.Web.Orchestrators.Saving
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Assemblers.Saving.Interfaces;

    using DataAccess.Saving.Interfaces;

    using Helpers.Error;

    using Interfaces;

    using JetBrains.Annotations;

    using ViewModels.Saving.Goal;

    using Wrappers;

    #endregion

    [UsedImplicitly]
    public class GoalOrchestrator : IGoalOrchestrator
    {
        #region Fields

        private IGoalAssembler assembler;

        private IGoalDataAccess dataAccess;

        #endregion

        #region Constructor

        public GoalOrchestrator(IGoalDataAccess dataAccess, IGoalAssembler assembler)
        {
            if (dataAccess == null)
            {
                throw new ArgumentNullException(nameof(dataAccess));
            }

            if (assembler == null)
            {
                throw new ArgumentNullException(nameof(assembler));
            }

            this.dataAccess = dataAccess;
            this.assembler = assembler;
        }

        #endregion

        #region Methods

        public async Task<OrchestratorResponseWrapper<GoalViewModel>> AddGoal(GoalViewModel model, string username)
        {
            var response = new OrchestratorResponseWrapper<GoalViewModel>();

            try
            {
                var request = assembler.NewAddGoalRequest(model, username);
                var apiResponse = await dataAccess.AddGoal(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);
                }
                else
                {
                    response.Model = assembler.ProxyToViewModel(apiResponse.Goal);
                }

                response.AddWarnings(apiResponse.Warnings);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "AddGoal");
                response.AddError(err);
            }

            return response;
        }

        public async Task<OrchestratorResponseWrapper<bool>> DelteGoal(Guid goalId, string username)
        {
            var response = new OrchestratorResponseWrapper<bool>();

            try
            {
                var request = assembler.NewDeleteGoalRequest(goalId, username);
                var apiResponse = await dataAccess.DeleteGoal(request);

                response.AddErrors(apiResponse.Errors);
                response.AddWarnings(apiResponse.Warnings);

                response.Model = apiResponse.DeleteSuccess || apiResponse.Success;
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "DeleteGoal");
                response.AddError(err);
            }

            return response;
        }

        public async Task<OrchestratorResponseWrapper<GoalViewModel>> EditGoal(GoalViewModel goal, string username)
        {
            var response = new OrchestratorResponseWrapper<GoalViewModel>();

            try
            {
                var request = assembler.NewEditGoalRequest(goal, username);
                var apiResponse = await dataAccess.EditGoal(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);
                }
                else
                {
                    response.Model = assembler.ProxyToViewModel(apiResponse.Goal);
                }

                response.AddWarnings(apiResponse.Warnings);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "EditGoal");
                response.AddError(err);
            }

            return response;
        }

        public async Task<OrchestratorResponseWrapper<GoalViewModel>> GetGoal(Guid goalId, string username)
        {
            var response = new OrchestratorResponseWrapper<GoalViewModel>();

            try
            {
                var request = assembler.NewGetGoalRequest(goalId, username);
                var apiResponse = await dataAccess.GetGoal(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);
                }
                else
                {
                    response.Model = assembler.ProxyToViewModel(apiResponse.Goal);
                }

                response.AddWarnings(apiResponse.Warnings);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "GetGoal");
                response.AddError(err);
            }

            return response;
        }

        public async Task<OrchestratorResponseWrapper<IList<GoalViewModel>>> GetGoalsForUser(
            Guid userId,
            string username)
        {
            var response = new OrchestratorResponseWrapper<IList<GoalViewModel>>();

            try
            {
                var request = assembler.NewGetGoalsForUserRequest(userId, username);
                var apiResponse = await dataAccess.GetGoalsForUser(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);
                }
                else
                {
                    response.Model = assembler.ProxyToViewModel(apiResponse.Goals);
                }

                response.AddWarnings(apiResponse.Warnings);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "GetGoalsForUser");
                response.AddError(err);
            }

            return response;
        }

        #endregion
    }
}