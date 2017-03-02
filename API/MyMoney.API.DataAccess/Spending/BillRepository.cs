namespace MyMoney.API.DataAccess.Spending
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    using DataModels.Spending;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    [UsedImplicitly]
    public class BillRepository : IBillRepository
    {
        #region  Public Methods

        public async Task<BillDataModel> AddBill(BillDataModel dataModel)
        {
            using (var context = new DatabaseContext())
            {
                dataModel.Id = Guid.NewGuid();

                var categoryModel =
                    await
                    context.Categories.FirstOrDefaultAsync(
                        x => string.Equals(x.Name, dataModel.Category.Name, StringComparison.InvariantCultureIgnoreCase)); 

                if (categoryModel != null)
                {
                    dataModel.CategoryId = categoryModel.Id;
                }

                context.Bills.Add(dataModel);

                var rows = await context.SaveChangesAsync();

                if (rows > 0)
                {
                    return dataModel;
                }
            }

            return null;
        }

        public async Task<IList<BillDataModel>> GetBillsForUser(Guid userId)
        {
            using (var context = new DatabaseContext())
            {
                return await context.Bills.Include(x => x.Category).Where(x => x.UserId.Equals(userId)).ToListAsync();
            }
        }

        public async Task<BillDataModel> GetBill(Guid billId)
        {
            using (var context = new DatabaseContext())
            {
                var bill = await context.Bills.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id.Equals(billId));

                if (bill == null)
                {
                    throw new Exception(Resources.Bills.Error_CouldNotFindBill);
                }

                return bill;
            }
        }

        #endregion
    }
}