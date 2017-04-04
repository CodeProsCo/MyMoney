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

    /// <summary>
    /// The <see cref="GoalAssembler"/> class creates DTOs, proxies and data models regarding goals.
    /// </summary>
    /// <seealso cref="MyMoney.API.Assemblers.Saving.Interfaces.IGoalAssembler" />
    [UsedImplicitly]
    public class GoalAssembler : IGoalAssembler
    {
        #region Methods

        /// <summary>
        /// Creates a new instance of the <see cref="AddGoalResponse" /> class.
        /// </summary>
        /// <param name="addedModel">The added model.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>
        /// The response object
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Exception thrown if the data model or request reference are null or empty.
        /// </exception>
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

        /// <summary>
        /// Creates a new instance of the <see cref="DeleteGoalResponse" /> class.
        /// </summary>
        /// <param name="deleteSuccess">if set to <c>true</c> [delete success].</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>
        /// The response object.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Exception thrown if the request reference is empty.
        /// </exception>
        public DeleteGoalResponse NewDeleteGoalResponse(bool deleteSuccess, Guid requestReference)
        {
            if (requestReference.Equals(Guid.Empty))
            {
                throw new ArgumentNullException(nameof(requestReference));
            }

            return new DeleteGoalResponse { DeleteSuccess = deleteSuccess, RequestReference = requestReference };
        }

        /// <summary>
        /// Creates a new instance of the <see cref="EditGoalResponse" /> class.
        /// </summary>
        /// <param name="updatedDataModel">The updated data model.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>
        /// The response object.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Exception thrown if the data model or request reference are null or empty.
        /// </exception>
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

        /// <summary>
        /// Creates a new instance of the <see cref="GetGoalResponse" /> class.
        /// </summary>
        /// <param name="dataModel">The data model.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response objet.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Exception thrown if the data model or request reference are null or empty.
        /// </exception>
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

        /// <summary>
        /// Creates a new instance of the <see cref="GetGoalResponse" /> class.
        /// </summary>
        /// <param name="goals">The goals.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>
        /// The response object.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Exception thrown if the list of goals is null or the request reference is empty.
        /// </exception>
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

        /// <summary>
        /// Creates a new instance of the <see cref="GoalDataModel" /> class.
        /// </summary>
        /// <param name="proxy">The proxy.</param>
        /// <returns>
        /// The data model.
        /// </returns>
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

        /// <summary>
        /// Converts an instance of the <see cref="GoalDataModel"/> class, to a <see cref="GoalProxy"/> instance.
        /// </summary>
        /// <param name="dataModel">The data model.</param>
        /// <returns>The proxy.</returns>
        private static GoalProxy DataModelToProxy(GoalDataModel dataModel)
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