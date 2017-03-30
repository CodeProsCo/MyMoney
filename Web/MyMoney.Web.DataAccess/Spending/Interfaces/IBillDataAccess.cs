namespace MyMoney.Web.DataAccess.Spending.Interfaces
{
    #region Usings

    using System.Threading.Tasks;

    using MyMoney.DTO.Request.Spending.Bill;
    using MyMoney.DTO.Response.Spending.Bills;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="BillDataAccess" /> class.
    /// </summary>
    public interface IBillDataAccess
    {
        #region Methods

        /// <summary>
        ///     Sends an HTTP POST request to add a bill to the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<AddBillResponse> AddBill(AddBillRequest request);

        /// <summary>
        ///     Sends an HTTP DELETE request to remove a bill from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<DeleteBillResponse> DeleteBill(DeleteBillRequest request);

        /// <summary>
        ///     Sends an HTTP POST request to edit a bill from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<EditBillResponse> EditBill(EditBillRequest request);

        /// <summary>
        ///     Sends an HTTP GET request to obtain a bill from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<GetBillResponse> GetBill(GetBillRequest request);

        /// <summary>
        ///     Sends an HTTP GET request to obtain a user's bills from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<GetBillsForUserResponse> GetBillsForUser(GetBillsForUserRequest request);

        /// <summary>
        ///     Sends an HTTP GET request to obtain a user's bills for a given month from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<GetBillsForUserForMonthResponse> GetBillsForUserForMonth(GetBillsForUserForMonthRequest request);

        #endregion
    }
}