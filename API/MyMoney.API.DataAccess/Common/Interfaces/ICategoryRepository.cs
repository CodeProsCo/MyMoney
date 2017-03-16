namespace MyMoney.API.DataAccess.Common.Interfaces
{
    #region Usings

    using System.Threading.Tasks;

    using DataModels.Common;

    #endregion

    public interface ICategoryRepository
    {
        #region  Public Methods

        Task<CategoryDataModel> AddCategory(CategoryDataModel category);

        Task<bool> Exists(string name);

        Task<CategoryDataModel> GetCategory(string name);

        #endregion
    }
}