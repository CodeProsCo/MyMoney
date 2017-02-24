using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.API.DataAccess.Spending
{
    using System.Data.Entity;

    using DataModels.Spending;

    using Interfaces;

    public class BillRepository : IBillRepository
    {
        #region Implementation of IBillRepository

        public async Task<IList<BillDataModel>> BetBillsForUser(Guid userId)
        {
            using (var context = new DatabaseContext())
            {
                return await context.Bills.Include(x => x.Category).Where(x => x.UserId.Equals(userId)).ToListAsync();
            }
        }

        public async Task<BillDataModel> AddBill(BillDataModel dataModel)
        {
            using (var context = new DatabaseContext())
            {
                dataModel.Id = Guid.NewGuid();

                context.Bills.Add(dataModel);

                var rows = await context.SaveChangesAsync();

                if (rows > 0)
                {
                    return dataModel;
                }
            }

            return null;
        }

        #endregion
    }
}

