namespace MyMoney.Web.DataAccess.Spending
{
    #region Usings

    using System.Threading.Tasks;

    using DTO.Request.Spending.Expenditure;
    using DTO.Response.Spending.Expenditure;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     The <see cref="ExpenditureDataAccess" /> class sends requests to the API for information regarding expenditure.
    /// </summary>
    /// <seealso cref="MyMoney.Web.DataAccess.BaseDataAccess" />
    /// <seealso cref="MyMoney.Web.DataAccess.Spending.Interfaces.IExpenditureDataAccess" />
    [UsedImplicitly]
    public class ExpenditureDataAccess : BaseDataAccess, IExpenditureDataAccess
    {
        #region  Public Methods

        /// <summary>
        ///     Sends an HTTP POST request to add a expenditure to the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<AddExpenditureResponse> AddExpenditure(AddExpenditureRequest request)
        {
            return await Post<AddExpenditureResponse>(request);
        }

        /// <summary>
        ///     Sends an HTTP DELETE request to remove a expenditure from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<DeleteExpenditureResponse> DeleteExpenditure(DeleteExpenditureRequest request)
        {
            return await Delete<DeleteExpenditureResponse>(request.FormatRequestUri(), request.Username);
        }

        /// <summary>
        ///     Sends an HTTP POST request to edit a expenditure from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<EditExpenditureResponse> EditExpenditure(EditExpenditureRequest request)
        {
            return await Post<EditExpenditureResponse>(request);
        }

        /// <summary>
        ///     Sends an HTTP GET request to obtain a expenditure from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<GetExpenditureResponse> GetExpenditure(GetExpenditureRequest request)
        {
            return await Get<GetExpenditureResponse>(request.FormatRequestUri(), request.Username);
        }

        /// <summary>
        ///     Sends an HTTP GET request to obtain a user's expenditure from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<GetExpendituresForUserResponse> GetExpendituresForUser(GetExpendituresForUserRequest request)
        {
            return await Get<GetExpendituresForUserResponse>(request.FormatRequestUri(), request.Username);
        }

        /// <summary>
        ///     Sends an HTTP GET request to obtain a user's expenditure for a given month from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<GetExpendituresForUserForMonthResponse> GetExpendituresForUserForMonth(
            GetExpendituresForUserForMonthRequest request)
        {
            return await Get<GetExpendituresForUserForMonthResponse>(request.FormatRequestUri(), request.Username);
        }

        #endregion
    }
}