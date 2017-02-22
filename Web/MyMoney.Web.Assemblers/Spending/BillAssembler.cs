namespace MyMoney.Web.Assemblers.Spending
{
    #region Usings

    using System;

    using DTO.Request.Spending;
    using DTO.Response.Spending;

    using Interfaces;

    using JetBrains.Annotations;

    using ViewModels.Spending.Bills;

    #endregion

    /// <summary>
    /// Assembles requests and view models regarding bills.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Assemblers.Spending.Interfaces.IBillAssembler" />
    [UsedImplicitly]
    public class BillAssembler : IBillAssembler
    {
        #region  Public Methods

        /// <summary>
        /// Assembles an instance of the <see cref="GetBillInformationRequest" /> class based on the given
        /// <see cref="Guid" />.
        /// </summary>
        /// <param name="id">The user's email address.</param>
        /// <returns>
        /// The request object.
        /// </returns>
        public GetBillInformationRequest NewGetBillInformationRequest(Guid id)
        {
            return new GetBillInformationRequest { UserId = id };
        }

        /// <summary>
        /// Assembles an instance of the <see cref="ManageBillsViewModel" /> class based on the given
        /// <see cref="GetBillInformationResponse" />.
        /// </summary>
        /// <param name="apiResponse">The response object.</param>
        /// <returns>
        /// The view model.
        /// </returns>
        public ManageBillsViewModel NewManageBillsViewModel(GetBillInformationResponse apiResponse)
        {
            return new ManageBillsViewModel();
        }

        #endregion
    }
}