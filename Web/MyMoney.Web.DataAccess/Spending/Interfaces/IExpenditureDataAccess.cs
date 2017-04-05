namespace MyMoney.Web.DataAccess.Spending.Interfaces
{
    #region Usings

    using System.Threading.Tasks;

    using DTO.Request.Spending.Expenditure;
    using DTO.Response.Spending.Expenditure;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="ExpenditureDataAccess" /> class.
    /// </summary>
    public interface IExpenditureDataAccess
    {
        #region Methods

        /// <summary>
        ///     Sends an HTTP POST request to add a expenditure to the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<AddExpenditureResponse> AddExpenditure(AddExpenditureRequest request);

        /// <summary>
        ///     Sends an HTTP DELETE request to remove a expenditure from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<DeleteExpenditureResponse> DeleteExpenditure(DeleteExpenditureRequest request);

        /// <summary>
        ///     Sends an HTTP POST request to edit a expenditure from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<EditExpenditureResponse> EditExpenditure(EditExpenditureRequest request);

        /// <summary>
        ///     Sends an HTTP GET request to obtain a expenditure from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<GetExpenditureResponse> GetExpenditure(GetExpenditureRequest request);

        /// <summary>
        ///     Sends an HTTP GET request to obtain a user's expenditure from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<GetExpendituresForUserResponse> GetExpendituresForUser(GetExpendituresForUserRequest request);

        /// <summary>
        ///     Sends an HTTP GET request to obtain a user's expenditure for a given month from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<GetExpendituresForUserForMonthResponse> GetExpendituresForUserForMonth(
            GetExpendituresForUserForMonthRequest request);

        #endregion
    }
}