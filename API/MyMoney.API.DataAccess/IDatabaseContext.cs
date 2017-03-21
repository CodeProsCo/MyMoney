
namespace MyMoney.API.DataAccess
{
    using System.Data.Entity;
    using System.Threading.Tasks;

    using DataModels.Authentication;
    using DataModels.Common;
    using DataModels.Spending;

    using JetBrains.Annotations;

    public interface IDatabaseContext
    {
        Task<int> SaveChangesAsync();

        /// <summary>
        ///     Gets or sets the bills.
        /// </summary>
        /// <value>
        ///     The bills.
        /// </value>
        DbSet<BillDataModel> Bills { get; [UsedImplicitly] set; }

        /// <summary>
        ///     Gets or sets the categories.
        /// </summary>
        /// <value>
        ///     The categories.
        /// </value>
        DbSet<CategoryDataModel> Categories { get; [UsedImplicitly] set; }

        /// <summary>
        ///     Gets or sets the expenditures.
        /// </summary>
        /// <value>
        ///     The expenditures.
        /// </value>
        DbSet<ExpenditureDataModel> Expenditures { get; [UsedImplicitly] set; }

        /// <summary>
        ///     Gets or sets the users.
        /// </summary>
        /// <value>
        ///     The users.
        /// </value>
        DbSet<UserDataModel> Users { get; [UsedImplicitly] set; }
    }
}