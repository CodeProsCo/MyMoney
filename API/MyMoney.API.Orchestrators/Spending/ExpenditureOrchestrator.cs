namespace MyMoney.API.Orchestrators.Spending
{
    #region Usings

    using System.Threading.Tasks;

    using DTO.Request.Spending.Expenditure;
    using DTO.Response.Spending.Expenditure;

    using Interfaces;

    #endregion

    public class ExpenditureOrchestrator : IExpenditureOrchestrator
    {
        #region  Public Methods

        public async Task<AddExpenditureResponse> AddExpenditure(AddExpenditureRequest request, string username)
        {
            return null;
        }

        public async Task<DeleteExpenditureResponse> DeleteExpenditure(DeleteExpenditureRequest request)
        {
            return null;
        }

        public async Task<EditExpenditureResponse> EditExpenditure(EditExpenditureRequest request)
        {
            return null;
        }

        public async Task<GetExpenditureResponse> GetExpenditure(GetExpenditureRequest request)
        {
            return null;
        }

        public async Task<GetExpendituresForUserResponse> GetExpendituresForUser(GetExpendituresForUserRequest request)
        {
            return null;
        }

        public async Task<GetExpendituresForUserForMonthResponse> GetExpendituresForUserForMonth(
            GetExpendituresForUserForMonthRequest request)
        {
            return null;
        }

        #endregion
    }
}