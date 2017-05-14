namespace MyMoney.API.DataAccess.Common
{
    #region Usings

    using System;
    using System.Data.Entity;
    using System.Threading.Tasks;

    using DataModels.Common;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     The <see cref="CategoryRepository" /> class performs CRUD operations on the database for
    ///     <see cref="CategoryDataModel" /> instances.
    /// </summary>
    /// <seealso cref="MyMoney.API.DataAccess.Common.Interfaces.ICategoryRepository" />
    [UsedImplicitly]
    public class CategoryRepository : ICategoryRepository
    {
        #region Fields
        #endregion

        #region Methods

        /// <summary>
        ///     Checks the database if a given category exists. If not, it is added to the database. Otherwise, it is returned from
        ///     the database.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>
        ///     The category data model.
        /// </returns>
        public async Task<CategoryDataModel> GetOrAdd(CategoryDataModel category)
        {
            using (var context = new DatabaseContext())
            {
                if (await Exists(category.Name))
                {
                    return await GetCategory(category.Name);
                }

                return await AddCategory(category);
            }
        }

        /// <summary>
        ///     Adds the given category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>The newly added category.</returns>
        private async Task<CategoryDataModel> AddCategory(CategoryDataModel category)
        {
            using (var context = new DatabaseContext())
            {
                category.Id = Guid.NewGuid();
                category.CreationTime = DateTime.Now;

                var addedModel = context.Categories.Add(category);

                var rowsChanged = await context.SaveChangesAsync();

                return rowsChanged > 0 ? addedModel : null;
            }
        }

        /// <summary>
        ///     Asserts if a category with the given name exists in the database.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>If it exists, true. Otherwise, false.</returns>
        private async Task<bool> Exists(string name)
        {
            using (var context = new DatabaseContext())
            {
                if (await context.Categories.CountAsync() > 0)
                {
                    return await context.Categories.AsNoTracking().AnyAsync(x => x.Name == name);
                }

                return false;
            }
        }

        /// <summary>
        ///     Gets a category with the given name from the database..
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        ///     The category data model.
        /// </returns>
        private async Task<CategoryDataModel> GetCategory(string name)
        {
            using (var context = new DatabaseContext())
            {
                return await context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);
            }
        }

        #endregion
    }
}