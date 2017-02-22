namespace MyMoney.API.DataAccess
{
    #region Usings

    using System.Data.Entity;

    using DataModels.Authentication.User;

    #endregion

    /// <summary>
    /// The <see cref="DatabaseContext"/> class represents the structure of the database and its tables.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class DatabaseContext : DbContext
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseContext"/> class.
        /// </summary>
        public DatabaseContext()
            : base("DefaultConnection")
        {
        }

        #endregion

        #region  Properties

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public DbSet<UserDataModel> Users { get; set; }

        #endregion
    }
}