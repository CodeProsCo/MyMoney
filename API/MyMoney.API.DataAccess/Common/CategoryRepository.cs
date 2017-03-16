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
                category.CreationTime = DateTime.Now;

                var addedModel = context.Categories.Add(category);

                var rowsChanged = await context.SaveChangesAsync();

                return rowsChanged > 0 ? addedModel : null;
            }
        }

        public async Task<bool> Exists(string name)
        {
            using (var context = new DatabaseContext())
            {
                if (await context.Categories.CountAsync() > 0)
                {
                    return
                     await
                     context.Categories.AnyAsync(
                         x => x.Name == name);
                }

                return false;
            }
        }

        public async Task<CategoryDataModel> GetCategory(string name)
        {
            using (var context = new DatabaseContext())
            {
                return
                    await
                    context.Categories.FirstOrDefaultAsync(
                        x => x.Name == name);
            }
        }

        public async Task<CategoryDataModel> GetOrAdd(CategoryDataModel category)
        {
            if (await Exists(category.Name))
            {
                return await GetCategory(category.Name);
            }

            return await AddCategory(category);
        }

        #endregion
    }
}