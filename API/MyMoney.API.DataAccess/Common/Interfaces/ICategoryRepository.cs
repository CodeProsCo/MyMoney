namespace MyMoney.API.DataAccess.Common.Interfaces
{
    #region Usings

    using System.Threading.Tasks;

    using DataModels.Common;

    #endregion

    /// <summary>
    /// Interface for the <see cref="CategoryRepository"/> class.
    /// </summary>
    public interface ICategoryRepository
    {
        #region  Public Methods

        /// <summary>
        /// Adds a category to the database.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        Task<CategoryDataModel> AddCategory(CategoryDataModel category);

        Task<bool> Exists(string name);

        Task<CategoryDataModel> GetCategory(string name);

        Task<CategoryDataModel> GetOrAdd(CategoryDataModel category);

        #endregion
    }
}