namespace MyMoney.API.Assemblers.Spending
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using JetBrains.Annotations;

    using MyMoney.API.Assemblers.Spending.Interfaces;
    using MyMoney.DataModels.Common;
    using MyMoney.DataModels.Spending;
    using MyMoney.DTO.Response.Spending.Expenditure;
    using MyMoney.Proxies.Common;
    using MyMoney.Proxies.Spending;

    #endregion

    /// <summary>
    ///     Creates instances of response objects, data models and proxies regarding expenditures.
    /// </summary>
    /// <seealso cref="MyMoney.API.Assemblers.Spending.Interfaces.IExpenditureAssembler" />
    [UsedImplicitly]
    public class ExpenditureAssembler : IExpenditureAssembler
    {
        #region Methods

        /// <summary>
        ///     Creates a new instance of the <see cref="AddExpenditureResponse" /> class.
        /// </summary>
        /// <param name="expenditure">The expenditure.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        public AddExpenditureResponse NewAddExpenditureResponse(ExpenditureDataModel expenditure, Guid requestReference)
        {
            return new AddExpenditureResponse
                       {
                           Expenditure = ExpenditureDataModelToProxy(expenditure),
                           RequestReference = requestReference
                       };
        }

        /// <summary>
        ///     Creates an instance of the <see cref="DeleteExpenditureResponse" /> class.
        /// </summary>
        /// <param name="success">The success indicator.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public DeleteExpenditureResponse NewDeleteExpenditureResponse(bool success, Guid requestReference)
        {
            return new DeleteExpenditureResponse { DeleteSuccess = success, RequestReference = requestReference };
        }

        /// <summary>
        ///     Creates an instance of the <see cref="EditExpenditureResponse" /> class.
        /// </summary>
        /// <param name="model">The data model.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public EditExpenditureResponse NewEditExpenditureResponse(ExpenditureDataModel model, Guid requestReference)
        {
            return new EditExpenditureResponse
                       {
                           Expenditure = ExpenditureDataModelToProxy(model),
                           RequestReference = requestReference
                       };
        }

        /// <summary>
        ///     Creates a new expenditure data model.
        /// </summary>
        /// <param name="expenditure">The expenditure proxy.</param>
        /// <returns>The data model.</returns>
        public ExpenditureDataModel NewExpenditureDataModel(ExpenditureProxy expenditure)
        {
            return ExpenditureProxyToDataModel(expenditure);
        }

        /// <summary>
        ///     Creates a new instance of the <see cref="GetExpenditureResponse" />class.
        /// </summary>
        /// <param name="expenditure">The expenditure.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        public GetExpenditureResponse NewGetExpenditureResponse(ExpenditureDataModel expenditure, Guid requestReference)
        {
            return new GetExpenditureResponse
                       {
                           RequestReference = requestReference,
                           Expenditure = ExpenditureDataModelToProxy(expenditure)
                       };
        }

        /// <summary>
        ///     Creates an instance of the <see cref="GetExpendituresForUserForMonthResponse" /> class.
        /// </summary>
        /// <param name="data">The expenditure data.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public GetExpendituresForUserForMonthResponse NewGetExpendituresForUserForMonthResponse(
            IEnumerable<ExpenditureDataModel> data,
            Guid requestReference)
        {
            return new GetExpendituresForUserForMonthResponse
                       {
                           Data = data.Select(ExpenditureDataModelToProxy),
                           RequestReference = requestReference
                       };
        }

        /// <summary>
        ///     Creates a new instance of the <see cref="GetExpendituresForUserResponse" /> class.
        /// </summary>
        /// <param name="expenditures">The expenditures.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        public GetExpendituresForUserResponse NewGetExpendituresForUserResponse(
            IList<ExpenditureDataModel> expenditures,
            Guid requestReference)
        {
            return new GetExpendituresForUserResponse
                       {
                           RequestReference = requestReference,
                           Expenditures =
                               expenditures.Select(ExpenditureDataModelToProxy).ToList()
                       };
        }

        /// <summary>
        ///     Converts a expenditure data model to a proxy.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The proxy.</returns>
        private static ExpenditureProxy ExpenditureDataModelToProxy(ExpenditureDataModel model)
        {
            return new ExpenditureProxy
                       {
                           Amount = model.Amount,
                           Category =
                               new CategoryProxy { Id = model.Category.Id, Name = model.Category.Name },
                           CategoryId = model.CategoryId,
                           Id = model.Id,
                           Description = model.Description,
                           DateOccurred = model.DateOccurred,
                           UserId = model.UserId
                       };
        }

        /// <summary>
        ///     Converts a expenditure proxy to a data model.
        /// </summary>
        /// <param name="proxy">The proxy.</param>
        /// <returns>The data model.</returns>
        private static ExpenditureDataModel ExpenditureProxyToDataModel(ExpenditureProxy proxy)
        {
            return new ExpenditureDataModel
                       {
                           Amount = proxy.Amount,
                           Category =
                               new CategoryDataModel
                                   {
                                       Id = proxy.Category.Id,
                                       Name = proxy.Category.Name
                                   },
                           CategoryId = proxy.CategoryId,
                           Id = proxy.Id,
                           Description = proxy.Description,
                           DateOccurred = proxy.DateOccurred,
                           UserId = proxy.UserId
                       };
        }

        #endregion
    }
}