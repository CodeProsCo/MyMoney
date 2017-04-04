namespace MyMoney.API.Orchestrators.Saving
{
    #region Usings

    using System;
    using System.Threading.Tasks;

    using MyMoney.API.Assemblers.Saving.Interfaces;
    using MyMoney.API.DataAccess.Saving.Interfaces;
    using MyMoney.API.Orchestrators.Saving.Interfaces;
    using MyMoney.DTO.Request.Saving.Goal;
    using MyMoney.DTO.Response.Saving.Goal;
    using MyMoney.Helpers.Error;

    #endregion

    public class GoalOrchestrator : IGoalOrchestrator
    {
        private IGoalAssembler assembler;

        private IGoalRepository repository;

        public GoalOrchestrator(IGoalAssembler assembler, IGoalRepository repository)
        {
            if (assembler == null)
            {
                throw new ArgumentNullException(nameof(assembler));
            }

            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            this.assembler = assembler;
            this.repository = repository;
        }

        #region Methods

        public async Task<AddGoalResponse> AddGoal(AddGoalRequest request, string requestUsername)
        {
            var response = new AddGoalResponse();

            try
            {
                var dataModel = assembler.NewGoalDataModel(request.Goal);
                var addedModel = await repository.AddGoal(dataModel);

                response = assembler.NewAddGoalResponse(addedModel, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, requestUsername, GetType(), "AddGoal");
                response.AddError(err);
            }

            return response;
        }

        public async Task<DeleteGoalResponse> DeleteGoal(DeleteGoalRequest request)
        {
            var response = new DeleteGoalResponse();

            try
            {
                var deleteSuccess = await repository.DeleteGoal(request.GoalId);

                response = assembler.NewDeleteGoalResponse(deleteSuccess, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, request.Username, GetType(), "DeleteGoal");
                response.AddError(err);
            }

            return response;
        }

        public async Task<EditGoalResponse> EditGoal(EditGoalRequest request)
        {
            var response = new EditGoalResponse();

            try
            {
                var dataModel = assembler.NewGoalDataModel(request.Goal);
                var updatedDataModel = await repository.EditGoal(dataModel);

                response = assembler.NewEditGoalResponse(updatedDataModel, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, request.Username, GetType(), "EditGoal");
                response.AddError(err);
            }

            return response;
        }

        public async Task<GetGoalResponse> GetGoal(GetGoalRequest request)
        {
            var response = new GetGoalResponse();

            try
            {
                var dataModel = await repository.GetGoal(request.GoalId);

                response = assembler.NewGetGoalResponse(dataModel, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, request.Username, GetType(), "GetGoal");
                response.AddError(err);
            }

            return response;
        }

        public async Task<GetGoalsForUserResponse> GetGoalsForUser(GetGoalsForUserRequest request)
        {
            var response = new GetGoalsForUserResponse();

            try
            {
                var goals = await repository.GetGoalsForUser(request.UserId);
                response = assembler.NewGetGoalsForUserResponse(goals, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, request.Username, GetType(), "GetGoalsForUser");
                response.AddError(err);
            }

            return response;
        }

        #endregion
    }
}