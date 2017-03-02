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

                if (!context.Categories.Any(x => x.Name == dataModel.Category.Name))
                {
                    dataModel.Category.Id = Guid.NewGuid();
                    var categoryModel = context.Categories.Add(dataModel.Category);

                    dataModel.Category = categoryModel;
                    dataModel.CategoryId = dataModel.Category.Id;
                }
                else
                {
                    dataModel.Category =
                        await context.Categories.FirstOrDefaultAsync(x => x.Name == dataModel.Category.Name);

                    dataModel.CategoryId = dataModel.Category.Id;
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

        public async Task<bool> DeleteBill(Guid billId)
        {
            using (var context = new DatabaseContext())
            {
                var toDelete = await context.Bills.FirstOrDefaultAsync(x => x.Id.Equals(billId));

                if (toDelete == null)
                {
                    throw new Exception(Resources.Bills.Error_CouldNotFindBill);
                }

                context.Bills.Remove(toDelete);

                var rows = await context.SaveChangesAsync();

                return rows > 0;
            }
        }

        public async Task<BillDataModel> EditBill(BillDataModel bill)
        {
            using (var context = new DatabaseContext())
            {
                var toEdit = await context.Bills.FirstOrDefaultAsync(x => x.Id.Equals(bill.Id));

                if (toEdit == null)
                {
                    throw new Exception(Resources.Bills.Error_CouldNotFindBill);
                }

                context.Bills.Remove(toEdit);
                context.Bills.Add(bill);

                var rows = await context.SaveChangesAsync();

                if (rows > 0)
                {
                    return bill;
                }
            }

            return null;
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