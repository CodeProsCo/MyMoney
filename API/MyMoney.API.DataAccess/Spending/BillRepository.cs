namespace MyMoney.API.DataAccess.Spending
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    using Common.Interfaces;

    using DataModels.Spending;

    using Interfaces;

    using JetBrains.Annotations;

    using Resources;

    #endregion

    /// <summary>
    ///     The <see cref="BillRepository" /> class performs CRUD operations regarding bills.
    /// </summary>
    /// <seealso cref="MyMoney.API.DataAccess.Spending.Interfaces.IBillRepository" />
    [UsedImplicitly]
    public class BillRepository : IBillRepository
    {
        #region Fields

        /// <summary>
        ///     The category repository
        /// </summary>
        private readonly ICategoryRepository categoryRepository;
        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="BillRepository" /> class.
        /// </summary>
        /// <param name="categoryRepository">The category repository.</param>
        /// <param name="context">The database context.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     Exception thrown when the category repository, or context are null.
        /// </exception>
        public BillRepository(ICategoryRepository categoryRepository)
        {
            if (categoryRepository == null)
            {
                throw new ArgumentNullException(nameof(categoryRepository));
            }

            this.categoryRepository = categoryRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Adds a bill to the database.
        /// </summary>
        /// <param name="dataModel">The data model.</param>
        /// <returns>
        ///     The bill data model.
        /// </returns>
        public async Task<BillDataModel> AddBill(BillDataModel dataModel)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                dataModel.Id = Guid.NewGuid();

                var category = await categoryRepository.GetOrAdd(dataModel.Category);

                dataModel.Category = category;
                dataModel.CategoryId = category.Id;

                dataModel.CreationTime = DateTime.Now;
                context.Bills.Add(dataModel);

                var rows = await context.SaveChangesAsync();

                return rows > 0 ? dataModel : null;
            }
        }

        /// <summary>
        ///     Deletes a bill from the database.
        /// </summary>
        /// <param name="billId">The bill identifier.</param>
        /// <returns>If successful, true. Otherwise, false.</returns>
        public async Task<bool> DeleteBill(Guid billId)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var toDelete = await GetBill(billId);

                if (toDelete == null)
                {
                    throw new Exception(Bill.Error_CouldNotFindBill);
                }

                toDelete = context.Bills.Attach(toDelete);
                context.Bills.Remove(toDelete);

                var rows = await context.SaveChangesAsync();

                return rows > 0;
            }
        }

        /// <summary>
        ///     Edits a bill in the database.
        /// </summary>
        /// <param name="bill">The edited bill.</param>
        /// <returns>The updated bill data model.</returns>
        public async Task<BillDataModel> EditBill(BillDataModel bill)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var toEdit = await GetBill(bill.Id);

                if (toEdit == null)
                {
                    throw new Exception(Bill.Error_CouldNotFindBill);
                }

                bill.CreationTime = toEdit.CreationTime;

                var category = await categoryRepository.GetOrAdd(bill.Category);

                bill.Category = category;
                bill.CategoryId = category.Id;

                context.Bills.Attach(bill);
                context.Entry(bill).State = EntityState.Modified;

                var rows = await context.SaveChangesAsync();

                return rows > 0 ? bill : null;
            }
        }

        /// <summary>
        ///     Obtains a bill from the database.
        /// </summary>
        /// <param name="billId">The bill identifier.</param>
        /// <returns>
        ///     The bill data model.
        /// </returns>
        /// <exception cref="System.Exception">
        ///     Exception thrown if the bill is not found.
        /// </exception>
        public async Task<BillDataModel> GetBill(Guid billId)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var bill =
                await context.Bills.Include(x => x.Category)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id.Equals(billId));

                if (bill == null)
                {
                    throw new Exception(Bill.Error_CouldNotFindBill);
                }

                return bill;
            }
        }

        /// <summary>
        ///     Gets the bills for the given user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        ///     The list of bills.
        /// </returns>
        public async Task<IList<BillDataModel>> GetBillsForUser(Guid userId)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return
                await context.Bills.Include(x => x.Category)
                    .AsNoTracking()
                    .Where(x => x.UserId.Equals(userId))
                    .ToListAsync();
            }
        }

        #endregion
    }
}