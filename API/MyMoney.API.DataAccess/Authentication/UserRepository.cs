namespace MyMoney.API.DataAccess.Authentication
{
    #region Usings

    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    using DataModels.Authentication;

    using Helpers.Security;

    using Interfaces;

    using JetBrains.Annotations;

    using Resources;

    #endregion

    /// <summary>
    ///     Handles data access regarding users.
    /// </summary>
    /// <seealso cref="MyMoney.API.DataAccess.Authentication.Interfaces.IUserRepository" />
    [UsedImplicitly]
    public class UserRepository : IUserRepository
    {
        #region Fields
        #endregion

        #region Methods

        /// <summary>
        ///     Gets a user based on the given email address and password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        ///     The user data model.
        /// </returns>
        public async Task<UserDataModel> GetUser(string email, string password)
        {
            using (var context = new DatabaseContext())
            {
                var result = await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.EmailAddress == email);

                if (result == null)
                {
                    throw new Exception(Authentication.Error_UsernameOrPasswordInvalid);
                }

                if (EncryptionHelper.ValidatePassword(password, result.Salt, result.Hash, result.Iterations))
                {
                    return result;
                }

                throw new Exception(Authentication.Error_UsernameOrPasswordInvalid);
            }
        }

        /// <summary>
        ///     Gets the user identifier by their email.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The user identifier.
        /// </returns>
        /// <exception cref="System.Exception">
        ///     Exception thrown if the user is not found.
        /// </exception>
        public async Task<Guid> GetUserIdByEmail(string username)
        {
            using (var context = new DatabaseContext())
            {
                var result =
                await context.Users.AsNoTracking()
                    .Where(x => x.EmailAddress == username)
                    .Select(x => x.Id)
                    .SingleOrDefaultAsync();

                if (result == null || result == Guid.Empty)
                {
                    throw new Exception(Authentication.Error_CouldNotFindUser);
                }

                return result;
            }
        }

        /// <summary>
        ///     Registers a user.
        /// </summary>
        /// <param name="model">The registration model.</param>
        /// <returns>
        ///     The user data model.
        /// </returns>
        public async Task<UserDataModel> RegisterUser(UserDataModel model)
        {
            using (var context = new DatabaseContext())
            {
                model.Id = Guid.NewGuid();
                model.CreationTime = DateTime.Now;

                var result = context.Users.Add(model);

                var rowsChanged = await context.SaveChangesAsync();

                return rowsChanged > 0 ? result : null;
            }
        }

        #endregion
    }
}