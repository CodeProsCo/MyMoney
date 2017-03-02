namespace MyMoney.API.Orchestrators.Spending.Interfaces
{
    using System;
    #region Usings

    using System.Threading.Tasks;

    using DTO.Request.Spending;
    using DTO.Response.Spending;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="BillOrchestrator" /> class.
    /// </summary>
    public interface IBillOrchestrator
    {
        #region  Public Methods

        /// <summary>
        ///     Adds a bill.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="username">The username.</param>
        /// <returns>The response object.</returns>
        Task<AddBillResponse> AddBill(AddBillRequest request, string username);

        /// <summary>
        /// Gets the bill.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The response object.</returns>
        Task<GetBillResponse> GetBill(GetBillRequest request);

        #endregion

        /// <summary>
        ///     Gets a user's bill information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The response object.</returns>
        Task<GetBillInformationResponse> GetBillInformation(GetBillInformationRequest request);

        Task<DeleteBillResponse> DeleteBill(DeleteBillRequest request);

        Task<EditBillResponse> EditBill(EditBillRequest request);
    }
}