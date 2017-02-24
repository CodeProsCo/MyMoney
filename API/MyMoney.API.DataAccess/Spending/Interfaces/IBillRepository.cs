using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.API.DataAccess.Spending.Interfaces
{
    using DataModels.Spending;

    public interface IBillRepository
    {
        Task<IList<BillDataModel>> BetBillsForUser(Guid userId);

        Task<BillDataModel> AddBill(BillDataModel dataModel);
    }
}
