namespace MyMoney.API.DataAccess
{
    #region Usings

    using System.Data.Entity;

    using DataModels.Authentication;
    using DataModels.Common;
    using DataModels.Spending;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     The <see cref="DatabaseContext" /> class represents the structure of the database and its tables.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class DatabaseContext : DbContext
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="DatabaseContext" /> class.
        /// </summary>
        public DatabaseContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<DatabaseContext>(null);
        }

        #endregion

        #region  Properties

        /// <summary>
        ///     Gets or sets the bills.
        /// </summary>
        /// <value>
        ///     The bills.
        /// </value>
        public DbSet<BillDataModel> Bills { get; [UsedImplicitly] set; }

        /// <summary>
        ///     Gets or sets the categories.
        /// </summary>
        /// <value>
        ///     The categories.
        /// </value>
        public DbSet<CategoryDataModel> Categories { get; [UsedImplicitly] set; }

        /// <summary>
        ///     Gets or sets the users.
        /// </summary>
        /// <value>
        ///     The users.
        /// </value>
        public DbSet<UserDataModel> Users { get; [UsedImplicitly] set; }

        /// <summary>
        /// Gets or sets the expenditures.
        /// </summary>
        /// <value>
        /// The expenditures.
        /// </value>
        public DbSet<ExpenditureDataModel> Expenditures { get; [UsedImplicitly] set; }

        #endregion

        #region Private Methods

        /// <summary>
        ///     This method is called when the model for a derived context has been initialized, but
        ///     before the model has been locked down and used to initialize the context.  The default
        ///     implementation of this method does nothing, but it can be overridden in a derived class
        ///     such that the model can be further configured before it is locked down.
        /// </summary>
        /// <remarks>
        ///     Typically, this method is called only once when the first instance of a derived context
        ///     is created.  The model for that context is then cached and is for all further instances of
        ///     the context in the app domain.  This caching can be disabled by setting the ModelCaching
        ///     property on the given ModelBuilder, but note that this can seriously degrade performance.
        ///     More control over caching is provided through use of the DBModelBuilder and DBContextFactory
        ///     classes directly.
        /// </remarks>
        /// <param name="modelBuilder"> The builder that defines the model for the context being created. </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillDataModel>().HasRequired(x => x.Category);
            modelBuilder.Entity<ExpenditureDataModel>().HasRequired(x => x.Category);

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}