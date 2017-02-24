namespace MyMoney.API.DataAccess.Authentication
{
    #region Usings

    using System.Data.Entity;
    using System.Threading.Tasks;

    using DataModels.Authentication;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     Handles data access regarding users.
    /// </summary>
    /// <seealso cref="MyMoney.API.DataAccess.Authentication.Interfaces.IUserRepository" />
    [UsedImplicitly]
    public class UserRepository : IUserRepository
    {
        #region  Public Methods

        /// <summary>
        /// Gets a user based on the given email address and password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// The user data model.
        /// </returns>
        public async Task<UserDataModel> GetUser(string email, string password)
        {
            using (var context = new DatabaseContext())
            {
                var result =
                    await context.Users.FirstOrDefaultAsync(x => x.EmailAddress == email && x.Password == password);

                return result;
            }
        }

        /// <summary>
        /// Registers a user.
        /// </summary>
        /// <param name="model">The registration model.</param>
        /// <returns>
        /// The user data model.
        /// </returns>
        public async Task<UserDataModel> RegisterUser(UserDataModel model)
        {
            using (var context = new DatabaseContext())
            {
                var result = context.Users.Add(model);

                var rowsChanged = await context.SaveChangesAsync();

                return rowsChanged > 0 ? result : null;
            }
        }

        #endregion
    }
}