namespace MyMoney.Web.DataAccess.Spending
{
    #region Usings

    using System.Threading.Tasks;

    using DTO.Request.Spending;
    using DTO.Request.Spending.Bill;
    using DTO.Response.Spending;
    using DTO.Response.Spending.Bills;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     The <see cref="BillDataAccess" /> class sends requests to the API for information regarding bills.
    /// </summary>
    /// <seealso cref="MyMoney.Web.DataAccess.BaseDataAccess" />
    /// <seealso cref="MyMoney.Web.DataAccess.Spending.Interfaces.IBillDataAccess" />
    [UsedImplicitly]
    public class BillDataAccess : BaseDataAccess, IBillDataAccess
    {
        #region  Public Methods

        /// <summary>
        ///     Sends an HTTP POST request to add a bill to the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<AddBillResponse> AddBill(AddBillRequest request)
        {
            return await Post<AddBillResponse>(request);
        }

        /// <summary>
        ///     Sends an HTTP DELETE request to remove a bill from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<DeleteBillResponse> DeleteBill(DeleteBillRequest request)
        {
            return await Delete<DeleteBillResponse>(request.FormatRequestUri(), request.Username);
        }

        /// <summary>
        ///     Sends an HTTP POST request to edit a bill from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<EditBillResponse> EditBill(EditBillRequest request)
        {
            return await Post<EditBillResponse>(request);
        }

        /// <summary>
        ///     Sends an HTTP GET request to obtain a bill from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<GetBillResponse> GetBill(GetBillRequest request)
        {
            return await Get<GetBillResponse>(request.FormatRequestUri(), request.Username);
        }

        /// <summary>
        ///     Sends an HTTP GET request to obtain a user's bills from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<GetBillsForUserResponse> GetBillsForUser(GetBillsForUserRequest request)
        {
            return await Get<GetBillsForUserResponse>(request.FormatRequestUri(), request.Username);
        }

        /// <summary>
        ///     Sends an HTTP GET request to obtain a user's bills for a given month from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<GetBillsForUserForMonthResponse> GetBillsForUserForMonth(
            GetBillsForUserForMonthRequest request)
        {
            return await Get<GetBillsForUserForMonthResponse>(request.FormatRequestUri(), request.Username);
        }

        #endregion
    }
}