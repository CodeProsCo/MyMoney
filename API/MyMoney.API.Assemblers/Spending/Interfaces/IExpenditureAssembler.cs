namespace MyMoney.API.Assemblers.Spending.Interfaces
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using DataModels.Spending;

    using DTO.Response.Spending.Expenditure;

    using Proxies.Spending;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="ExpenditureAssembler" /> class.
    /// </summary>
    public interface IExpenditureAssembler
    {
        #region Methods

        /// <summary>
        ///     Creates a new instance of the <see cref="AddExpenditureResponse" /> class.
        /// </summary>
        /// <param name="expenditure">The expenditure.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        AddExpenditureResponse NewAddExpenditureResponse(ExpenditureDataModel expenditure, Guid requestReference);

        /// <summary>
        ///     Creates an instance of the <see cref="DeleteExpenditureResponse" /> class.
        /// </summary>
        /// <param name="success">The success indicator.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        DeleteExpenditureResponse NewDeleteExpenditureResponse(bool success, Guid requestReference);

        /// <summary>
        ///     Creates an instance of the <see cref="EditExpenditureResponse" /> class.
        /// </summary>
        /// <param name="model">The data model.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        EditExpenditureResponse NewEditExpenditureResponse(ExpenditureDataModel model, Guid requestReference);

        /// <summary>
        ///     Creates an instance of the <see cref="ExpenditureDataModel" /> class.
        /// </summary>
        /// <param name="expenditure">The expenditure proxy.</param>
        /// <returns>The expenditure data model.</returns>
        ExpenditureDataModel NewExpenditureDataModel(ExpenditureProxy expenditure);

        /// <summary>
        ///     Creates an instance of the <see cref="GetExpenditureResponse" /> class.
        /// </summary>
        /// <param name="expenditure">The expenditure.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        GetExpenditureResponse NewGetExpenditureResponse(ExpenditureDataModel expenditure, Guid requestReference);

        /// <summary>
        ///     Creates an instance of the <see cref="GetExpenditureForUserForMonthResponse" /> class.
        /// </summary>
        /// <param name="data">The expenditure data.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        GetExpenditureForUserForMonthResponse NewGetExpendituresForUserForMonthResponse(
            IEnumerable<ExpenditureDataModel> data,
            Guid requestReference);

        /// <summary>
        ///     Creates an instance of the <see cref="GetExpenditureForUserResponse" /> class.
        /// </summary>
        /// <param name="expenditures">The expenditures.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        GetExpenditureForUserResponse NewGetExpendituresForUserResponse(
            IList<ExpenditureDataModel> expenditures,
            Guid requestReference);

        #endregion
    }
}