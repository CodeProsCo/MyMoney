namespace MyMoney.API.Orchestrators.Spending.Interfaces
{
    #region Usings

    #region Usings

    using System.Threading.Tasks;

    using DTO.Request.Spending;
    using DTO.Response.Spending;

    #endregion

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
        /// Deletes a bill.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<DeleteBillResponse> DeleteBill(DeleteBillRequest request);

        /// <summary>
        /// Edits a bill.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<EditBillResponse> EditBill(EditBillRequest request);

        /// <summary>
        ///     Gets the bill.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<GetBillResponse> GetBill(GetBillRequest request);

        /// <summary>
        ///     Gets a user's bill information.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<GetBillsForUserResponse> GetBillsForUser(GetBillsForUserRequest request);

        #endregion
    }
}