namespace MyMoney.API.DataAccess.Authentication.Interfaces
{
    #region Usings

    using System;
    using System.Threading.Tasks;

    using DataModels.Authentication;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="UserRepository" /> class.
    /// </summary>
    public interface IUserRepository
    {
        #region  Public Methods

        /// <summary>
        ///     Gets a user based on the given email address and password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>The user data model.</returns>
        Task<UserDataModel> GetUser(string email, string password);

        /// <summary>
        ///     Registers a user.
        /// </summary>
        /// <param name="model">The registration model.</param>
        /// <returns>The user data model.</returns>
        Task<UserDataModel> RegisterUser(UserDataModel model);

        #endregion

        Task<Guid> GetUserIdByEmail(string username);
    }
}