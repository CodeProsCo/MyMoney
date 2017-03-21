namespace MyMoney.API.DataAccess.Authentication
{
    #region Usings

    using System;
    using System.Data.Entity;
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
        /// <summary>
        /// The context
        /// </summary>
        public readonly IDatabaseContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Exception thrown if the database context is null.
        /// </exception>
        public UserRepository(IDatabaseContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            this.context = context;
        }

        #region  Public Methods

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
                var result = await context.Users.FirstOrDefaultAsync(x => x.EmailAddress == email);

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
                var result = await context.Users.FirstOrDefaultAsync(x => x.EmailAddress == username);

                if (result == null)
                {
                    throw new Exception(Authentication.Error_CouldNotFindUser);
                }

                return result.Id;
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
                model.Id = Guid.NewGuid();

                var result = context.Users.Add(model);

                var rowsChanged = await context.SaveChangesAsync();

                return rowsChanged > 0 ? result : null;
        }

        #endregion
    }
}