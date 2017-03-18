namespace MyMoney.API.Orchestrators.Spending.Interfaces
{
    #region Usings

    using System.Threading.Tasks;

    using DTO.Request.Spending.Expenditure;
    using DTO.Response.Spending.Expenditure;

    #endregion

    public interface IExpenditureOrchestrator
    {
        #region  Public Methods

        Task<AddExpenditureResponse> AddExpenditure(AddExpenditureRequest request, string username);

        Task<DeleteExpenditureResponse> DeleteExpenditure(DeleteExpenditureRequest request);

        Task<EditExpenditureResponse> EditExpenditure(EditExpenditureRequest request);

        Task<GetExpenditureResponse> GetExpenditure(GetExpenditureRequest request);

        Task<GetExpendituresForUserResponse> GetExpendituresForUser(GetExpendituresForUserRequest request);

        Task<GetExpendituresForUserForMonthResponse> GetExpendituresForUserForMonth(
            GetExpendituresForUserForMonthRequest request);

        #endregion
    }
}