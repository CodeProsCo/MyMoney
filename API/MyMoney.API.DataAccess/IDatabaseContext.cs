namespace MyMoney.API.DataAccess
{
    #region Usings

    using System.Data.Entity;
    using System.Threading.Tasks;

    using JetBrains.Annotations;

    using MyMoney.DataModels.Authentication;
    using MyMoney.DataModels.Common;
    using MyMoney.DataModels.Saving;
    using MyMoney.DataModels.Spending;

    #endregion

    /// <summary>
    /// The interface for the <see cref="DatabaseContext"/> class.
    /// </summary>
    public interface IDatabaseContext
    {
        #region Properties

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
        /// Gets or sets the goals.
        /// </summary>
        /// <value>
        /// The goals.
        /// </value>
        DbSet<GoalDataModel> Goals { get; [UsedImplicitly] set; }

        /// <summary>
        ///     Gets or sets the users.
        /// </summary>
        /// <value>
        ///     The users.
        /// </value>
        DbSet<UserDataModel> Users { get; [UsedImplicitly] set; }

        #endregion

        #region Methods

        /// <summary>
        /// Saves the changes asynchronously.
        /// </summary>
        /// <returns>The number of rows changed.</returns>
        Task<int> SaveChangesAsync();

        #endregion
    }
}