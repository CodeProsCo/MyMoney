namespace MyMoney.API.DataAccess.Common.Interfaces
{
    #region Usings

    using System.Threading.Tasks;

    using MyMoney.DataModels.Common;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="CategoryRepository" /> class.
    /// </summary>
    public interface ICategoryRepository
    {
        #region Methods

        /// <summary>
        ///     Checks the database if a given category exists. If not, it is added to the database. Otherwise, it is returned from
        ///     the database.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>The category data model.</returns>
        Task<CategoryDataModel> GetOrAdd(CategoryDataModel category);

        #endregion
    }
}