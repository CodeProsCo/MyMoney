namespace MyMoney.API.Assemblers.Spending
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DataModels.Common;
    using DataModels.Spending;

    using DTO.Response.Spending;

    using Interfaces;

    using JetBrains.Annotations;

    using Proxies.Common;
    using Proxies.Spending;

    #endregion

    /// <summary>
    ///     Assembles responses, proxies and data models regarding bills.
    /// </summary>
    /// <seealso cref="MyMoney.API.Assemblers.Spending.Interfaces.IBillAssembler" />
    [UsedImplicitly]
    public class BillAssembler : IBillAssembler
    {
        #region  Public Methods

        /// <summary>
        ///     Creates a new instance of the <see cref="AddBillResponse" /> class.
        /// </summary>
        /// <param name="bill">The bill.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        public AddBillResponse NewAddBillResponse(BillDataModel bill, Guid requestReference)
        {
            return new AddBillResponse { Bill = BillDataModelToProxy(bill), RequestReference = requestReference };
        }

        /// <summary>
        ///     Creates a new bill data model.
        /// </summary>
        /// <param name="bill">The bill proxy.</param>
        /// <returns>The data model.</returns>
        public BillDataModel NewBillDataModel(BillProxy bill)
        {
            return BillProxyToDataModel(bill);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="GetBillInformationResponse"/> class.
        /// </summary>
        /// <param name="bills">The bills.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        public GetBillInformationResponse NewGetBillInformationResponse(
            IList<BillDataModel> bills,
            Guid requestReference)
        {
            return new GetBillInformationResponse
            {
                RequestReference = requestReference,
                Bills = bills.Select(BillDataModelToProxy).ToList()
            };
        }

        /// <summary>
        /// Creates a new instance of the <see cref="GetBillResponse"/>class.
        /// </summary>
        /// <param name="bill">The bill.</param>
        /// <param name="requestReference">The request reference.</param>
        /// <returns>The response object.</returns>
        public GetBillResponse NewGetBillResponse(BillDataModel bill, Guid requestReference)
        {
            return new GetBillResponse { RequestReference = requestReference, Bill = BillDataModelToProxy(bill) };
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Converts a bill data model to a proxy.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The proxy.</returns>
        private static BillProxy BillDataModelToProxy(BillDataModel model)
        {
            return new BillProxy
            {
                Amount = model.Amount,
                Category = new CategoryProxy
                {
                    CategoryId = model.Category.Id,
                    Name = model.Category.Name
                },
                CategoryId = model.CategoryId,
                Id = model.Id,
                Name = model.Name,
                ReocurringPeriod = model.ReocurringPeriod,
                StartDate = model.StartDate,
                UserId = model.UserId
            };
        }

        /// <summary>
        /// Converts a bill proxy to a data model.
        /// </summary>
        /// <param name="proxy">The proxy.</param>
        /// <returns>The data model.</returns>
        private static BillDataModel BillProxyToDataModel(BillProxy proxy)
        {
            return new BillDataModel
            {
                Amount = proxy.Amount,
                Category = new CategoryDataModel
                {
                    Id = proxy.Category.CategoryId,
                    Name = proxy.Category.Name
                },
                CategoryId = proxy.CategoryId,
                Id = proxy.Id,
                Name = proxy.Name,
                ReocurringPeriod = proxy.ReocurringPeriod,
                StartDate = proxy.StartDate,
                UserId = proxy.UserId
            };
        }

        #endregion
    }
}