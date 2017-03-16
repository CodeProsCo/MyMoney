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

    [UsedImplicitly]
    public class CategoryRepository : ICategoryRepository
    {
        #region  Public Methods

        public async Task<CategoryDataModel> AddCategory(CategoryDataModel category)
        {
            using (var context = new DatabaseContext())
            {
                category.Id = Guid.NewGuid();

                var addedModel = context.Categories.Add(category);

                var rowsChanged = await context.SaveChangesAsync();

                return rowsChanged > 0 ? addedModel : null;
            }
        }

        public async Task<bool> Exists(string name)
        {
            using (var context = new DatabaseContext())
            {
                return
                    await
                    context.Categories.AnyAsync(
                        x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public async Task<CategoryDataModel> GetCategory(string name)
        {
            using (var context = new DatabaseContext())
            {
                return
                    await
                    context.Categories.FirstOrDefaultAsync(
                        x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        #endregion
    }
}