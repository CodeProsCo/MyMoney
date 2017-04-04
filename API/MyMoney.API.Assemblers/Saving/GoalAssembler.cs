namespace MyMoney.API.Assemblers.Saving
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using JetBrains.Annotations;

    using MyMoney.API.Assemblers.Saving.Interfaces;
    using MyMoney.DataModels.Saving;
    using MyMoney.DTO.Response.Saving.Goal;
    using MyMoney.Proxies.Saving;

    #endregion

    [UsedImplicitly]
    public class GoalAssembler : IGoalAssembler
    {
        #region Methods

        public AddGoalResponse NewAddGoalResponse(GoalDataModel addedModel, Guid requestReference)
        {
            if (addedModel == null)
            {
                throw new ArgumentNullException(nameof(addedModel));
            }

            if (requestReference.Equals(Guid.Empty))
            {
                throw new ArgumentNullException(nameof(requestReference));
            }

            return new AddGoalResponse { Goal = DataModelToProxy(addedModel), RequestReference = requestReference };
        }

        public DeleteGoalResponse NewDeleteGoalResponse(bool deleteSuccess, Guid requestReference)
        {
            if (requestReference.Equals(Guid.Empty))
            {
                throw new ArgumentNullException(nameof(requestReference));
            }

            return new DeleteGoalResponse { DeleteSuccess = deleteSuccess, RequestReference = requestReference };
        }

        public EditGoalResponse NewEditGoalResponse(GoalDataModel updatedDataModel, Guid requestReference)
        {
            if (updatedDataModel == null)
            {
                throw new ArgumentNullException(nameof(updatedDataModel));
            }

            if (requestReference.Equals(Guid.Empty))
            {
                throw new ArgumentNullException(nameof(requestReference));
            }

            return new EditGoalResponse
                       {
                           Goal = DataModelToProxy(updatedDataModel),
                           RequestReference = requestReference
                       };
        }

        public GetGoalResponse NewGetGoalResponse(GoalDataModel dataModel, Guid requestReference)
        {
            if (dataModel == null)
            {
                throw new ArgumentNullException(nameof(dataModel));
            }

            if (requestReference.Equals(Guid.Empty))
            {
                throw new ArgumentNullException(nameof(requestReference));
            }

            return new GetGoalResponse { Goal = DataModelToProxy(dataModel), RequestReference = requestReference };
        }

        public GetGoalsForUserResponse NewGetGoalsForUserResponse(IList<GoalDataModel> goals, Guid requestReference)
        {
            if (goals == null)
            {
                throw new ArgumentNullException(nameof(goals));
            }

            if (requestReference.Equals(Guid.Empty))
            {
                throw new ArgumentNullException(nameof(requestReference));
            }

            return new GetGoalsForUserResponse
                       {
                           Goals = goals.Select(DataModelToProxy).ToList(),
                           RequestReference = requestReference
                       };
        }

        public GoalDataModel NewGoalDataModel(GoalProxy proxy)
        {
            return new GoalDataModel
                       {
                           Amount = proxy.Amount,
                           Complete = proxy.Complete,
                           UserId = proxy.UserId,
                           EndDate = proxy.EndDate,
                           Name = proxy.Name,
                           Id = proxy.Id,
                           StartDate = proxy.StartDate
                       };
        }

        private GoalProxy DataModelToProxy(GoalDataModel dataModel)
        {
            return new GoalProxy
                       {
                           Amount = dataModel.Amount,
                           Complete = dataModel.Complete,
                           UserId = dataModel.UserId,
                           EndDate = dataModel.EndDate,
                           Name = dataModel.Name,
                           Id = dataModel.Id,
                           StartDate = dataModel.StartDate
                       };
        }

        #endregion
    }
}