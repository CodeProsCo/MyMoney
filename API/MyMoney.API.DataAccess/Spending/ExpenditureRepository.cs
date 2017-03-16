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
    /// The <see cref="ExpenditureRepository"/> class performs CRUD actions on <see cref="ExpenditureDataModel"/> instances.
    /// </summary>
    /// <seealso cref="MyMoney.API.DataAccess.Spending.Interfaces.IExpenditureRepository" />
    [UsedImplicitly]
    public class ExpenditureRepository : IExpenditureRepository
    {
        #region Fields

        /// <summary>
        /// The category repository
        /// </summary>
        private readonly ICategoryRepository categoryRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenditureRepository"/> class.
        /// </summary>
        /// <param name="categoryRepository">The category repository.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Exception thrown if the category repository is null.
        /// </exception>
        public ExpenditureRepository(ICategoryRepository categoryRepository)
        {
            if (categoryRepository == null)
            {
                throw new ArgumentNullException(nameof(categoryRepository));
            }

            this.categoryRepository = categoryRepository;
        }

        #endregion

        #region  Public Methods

        /// <summary>
        ///     Adds a expenditure to the database.
        /// </summary>
        /// <param name="dataModel">The data model.</param>
        /// <returns>
        ///     The expenditure data model.
        /// </returns>
        public async Task<ExpenditureDataModel> AddExpenditure(ExpenditureDataModel dataModel)
        {
            using (var context = new DatabaseContext())
            {
                dataModel.Id = Guid.NewGuid();

                var category = await categoryRepository.GetOrAdd(dataModel.Category);

                dataModel.Category = category;
                dataModel.CategoryId = category.Id;

                context.Expenditures.Add(dataModel);

                var rows = await context.SaveChangesAsync();

                if (rows > 0)
                {
                    return dataModel;
                }
            }

            return null;
        }

        /// <summary>
        ///     Deletes a expenditure from the database.
        /// </summary>
        /// <param name="expenditureId">The expenditure identifier.</param>
        /// <returns>If successful, true. Otherwise, false.</returns>
        public async Task<bool> DeleteExpenditure(Guid expenditureId)
        {
            using (var context = new DatabaseContext())
            {
                var toDelete = await GetExpenditure(expenditureId);

                if (toDelete == null)
                {
                    throw new Exception(Expenditure.Error_CouldNotFindExpenditure);
                }

                toDelete = context.Expenditures.Attach(toDelete);
                context.Expenditures.Remove(toDelete);

                var rows = await context.SaveChangesAsync();

                return rows > 0;
            }
        }

        /// <summary>
        ///     Edits a expenditure in the database.
        /// </summary>
        /// <param name="expenditure">The edited expenditure.</param>
        /// <returns>The updated expenditure data model.</returns>
        public async Task<ExpenditureDataModel> EditExpenditure(ExpenditureDataModel expenditure)
        {
            using (var context = new DatabaseContext())
            {
                var toEdit = await GetExpenditure(expenditure.Id);

                if (toEdit == null)
                {
                    throw new Exception(Expenditure.Error_CouldNotFindExpenditure);
                }

                toEdit = context.Expenditures.Attach(toEdit);
                context.Expenditures.Remove(toEdit);

                var category = await categoryRepository.GetOrAdd(expenditure.Category);

                expenditure.Category = category;
                expenditure.CategoryId = category.Id;

                context.Expenditures.Add(expenditure);

                var rows = await context.SaveChangesAsync();

                if (rows > 0)
                {
                    return expenditure;
                }
            }

            return null;
        }

        /// <summary>
        /// Obtains an expenditure from the database.
        /// </summary>
        /// <param name="expenditureId">The expenditure identifier.</param>
        /// <returns>
        /// The expenditure.
        /// </returns>
        public async Task<ExpenditureDataModel> GetExpenditure(Guid expenditureId)
        {
            using (var context = new DatabaseContext())
            {
                return
                    await
                    context.Expenditures.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id.Equals(expenditureId));
            }
        }

        /// <summary>
        /// Gets the expenditures for the given user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// The list of expenditures.
        /// </returns>
        public async Task<IList<ExpenditureDataModel>> GetExpendituresForUser(Guid userId)
        {
            using (var context = new DatabaseContext())
            {
                return
                    await
                    context.Expenditures.Include(x => x.Category).Where(x => x.UserId.Equals(userId)).ToListAsync();
            }
        }

        #endregion
    }
}