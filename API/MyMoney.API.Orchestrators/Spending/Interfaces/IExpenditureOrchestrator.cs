namespace MyMoney.API.Orchestrators.Spending.Interfaces
{
    #region Usings

    using System.Threading.Tasks;

    using DTO.Request.Spending.Expenditure;
    using DTO.Response.Spending.Expenditure;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="ExpenditureOrchestrator" /> class.
    /// </summary>
    public interface IExpenditureOrchestrator
    {
        #region Methods

        /// <summary>
        ///     Adds an expenditure to the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="username">The username.</param>
        /// <returns>The response object.</returns>
        Task<AddExpenditureResponse> AddExpenditure(AddExpenditureRequest request, string username);

        /// <summary>
        ///     Removes an expenditure from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<DeleteExpenditureResponse> DeleteExpenditure(DeleteExpenditureRequest request);

        /// <summary>
        ///     Updates an expenditure in the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<EditExpenditureResponse> EditExpenditure(EditExpenditureRequest request);

        /// <summary>
        ///     Obtains an expenditure from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<GetExpenditureResponse> GetExpenditure(GetExpenditureRequest request);

        /// <summary>
        ///     Gets all the expenditures for a given user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<GetExpenditureForUserResponse> GetExpendituresForUser(GetExpenditureForUserRequest request);

        /// <summary>
        ///     Gets the expenditures for a given user for month.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<GetExpendituresForUserForMonthResponse> GetExpendituresForUserForMonth(
            GetExpenditureForUserForMonthRequest request);

        #endregion
    }
}