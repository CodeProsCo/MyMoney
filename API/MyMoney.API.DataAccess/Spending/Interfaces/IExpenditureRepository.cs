namespace MyMoney.API.DataAccess.Spending.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DataModels.Spending;

    public interface IExpenditureRepository
    {
        Task<IList<ExpenditureDataModel>> GetExpendituresForUser(Guid userId);

        Task<ExpenditureDataModel> GetExpenditure(Guid expenditureId);

        Task<ExpenditureDataModel> AddExpenditure(ExpenditureDataModel dataModel);

        Task<bool> DeleteExpenditure(Guid expenditureId);

        Task<ExpenditureDataModel> EditExpenditure(ExpenditureDataModel expenditure);
    }
}