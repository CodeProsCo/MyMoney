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

    using Resources;

    #endregion

    /// <summary>
    /// The <see cref="BillRepository"/> class performs CRUD operations regarding bills.
    /// </summary>
    /// <seealso cref="MyMoney.API.DataAccess.Spending.Interfaces.IBillRepository" />
    [UsedImplicitly]
    public class BillRepository : IBillRepository
    {
        #region  Public Methods

        /// <summary>
        /// Adds a bill to the database.
        /// </summary>
        /// <param name="dataModel">The data model.</param>
        /// <returns>
        /// The bill data model.
        /// </returns>
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

        /// <summary>
        /// Deletes a bill from the database.
        /// </summary>
        /// <param name="billId">The bill identifier.</param>
        /// <returns>If successful, true. Otherwise, false.</returns>
        public async Task<bool> DeleteBill(Guid billId)
        {
            using (var context = new DatabaseContext())
            {
                var toDelete = await GetBill(billId);

                context.Bills.Remove(toDelete);

                var rows = await context.SaveChangesAsync();

                return rows > 0;
            }
        }

        /// <summary>
        /// Edits a bill in the database.
        /// </summary>
        /// <param name="bill">The edited bill.</param>
        /// <returns>The updated bill data model.</returns>
        public async Task<BillDataModel> EditBill(BillDataModel bill)
        {
            using (var context = new DatabaseContext())
            {
                var toEdit = await GetBill(bill.Id);

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

        /// <summary>
        /// Obtains a bill from the database.
        /// </summary>
        /// <param name="billId">The bill identifier.</param>
        /// <returns>
        /// The bill data model.
        /// </returns>
        /// <exception cref="System.Exception">
        /// Exception thrown if the bill is not found.
        /// </exception>
        public async Task<BillDataModel> GetBill(Guid billId)
        {
            using (var context = new DatabaseContext())
            {
                var bill = await context.Bills.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id.Equals(billId));

                if (bill == null)
                {
                    throw new Exception(Bills.Error_CouldNotFindBill);
                }

                return bill;
            }
        }

        /// <summary>
        /// Gets the bills for the given user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// The list of bills.
        /// </returns>
        public async Task<IList<BillDataModel>> GetBillsForUser(Guid userId)
        {
            using (var context = new DatabaseContext())
            {
                return await context.Bills.Include(x => x.Category).Where(x => x.UserId.Equals(userId)).ToListAsync();
            }
        }

        #endregion
    }
}