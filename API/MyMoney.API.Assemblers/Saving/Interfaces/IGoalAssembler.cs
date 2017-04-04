namespace MyMoney.API.Assemblers.Saving.Interfaces
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using MyMoney.DataModels.Saving;
    using MyMoney.DTO.Response.Saving.Goal;
    using MyMoney.Proxies.Saving;

    #endregion

    /// <summary>
    /// Interface for the <see cref="GoalAssembler"/> class.
    /// </summary>
    public interface IGoalAssembler
    {
        #region Methods

        /// <summary>
        /// Creates a new instance of the <see cref="AddGoalResponse"/> class.
        /// </summary>
        /// <param name="addedModel">The added model.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object</returns>
        AddGoalResponse NewAddGoalResponse(GoalDataModel addedModel, Guid requestReference);

        /// <summary>
        /// Creates a new instance of the <see cref="DeleteGoalResponse"/> class.
        /// </summary>
        /// <param name="deleteSuccess">if set to <c>true</c> [delete success].</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        DeleteGoalResponse NewDeleteGoalResponse(bool deleteSuccess, Guid requestReference);

        /// <summary>
        /// Creates a new instance of the <see cref="EditGoalResponse"/> class.
        /// </summary>
        /// <param name="updatedDataModel">The updated data model.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        EditGoalResponse NewEditGoalResponse(GoalDataModel updatedDataModel, Guid requestReference);

        /// <summary>
        /// Creates a new instance of the <see cref="GetGoalResponse"/> class.
        /// </summary>
        /// <param name="dataModel">The data model.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        GetGoalResponse NewGetGoalResponse(GoalDataModel dataModel, Guid requestReference);

        /// <summary>
        /// Creates a new instance of the <see cref="GetGoalResponse"/> class.
        /// </summary>
        /// <param name="goals">The goals.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        GetGoalsForUserResponse NewGetGoalsForUserResponse(IList<GoalDataModel> goals, Guid requestReference);

        /// <summary>
        /// Creates a new instance of the <see cref="GoalDataModel"/> class.
        /// </summary>
        /// <param name="proxy">The proxy.</param>
        /// <returns>The data model.</returns>
        GoalDataModel NewGoalDataModel(GoalProxy proxy);

        #endregion
    }
}