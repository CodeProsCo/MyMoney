namespace MyMoney.API.DataAccess.Authentication.Interfaces
{
    #region Usings

    using System;
    using System.Threading.Tasks;

    using MyMoney.DataModels.Authentication;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="UserRepository" /> class.
    /// </summary>
    public interface IUserRepository
    {
        #region Methods

        /// <summary>
        ///     Gets a user based on the given email address and password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>The user data model.</returns>
        Task<UserDataModel> GetUser(string email, string password);

        /// <summary>
        ///     Gets the user identifier by their email.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>The user identifier.</returns>
        Task<Guid> GetUserIdByEmail(string username);

        /// <summary>
        ///     Registers a user.
        /// </summary>
        /// <param name="model">The registration model.</param>
        /// <returns>The user data model.</returns>
        Task<UserDataModel> RegisterUser(UserDataModel model);

        #endregion
    }
}