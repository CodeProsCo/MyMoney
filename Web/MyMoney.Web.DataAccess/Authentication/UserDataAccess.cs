namespace MyMoney.Web.DataAccess.Authentication
{
    #region Usings

    using System.Threading.Tasks;

    using DTO.Request.Authentication;
    using DTO.Response.Authentication;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     Handles API requests regarding authentication and users.
    /// </summary>
    /// <seealso cref="MyMoney.Web.DataAccess.BaseDataAccess" />
    /// <seealso cref="MyMoney.Web.DataAccess.Authentication.Interfaces.IUserDataAccess" />
    [UsedImplicitly]
    public class UserDataAccess : BaseDataAccess, IUserDataAccess
    {
        #region  Public Methods

        /// <summary>
        ///     Sends a request to obtain the claims identity information for the given user.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<ValidateUserResponse> ValidateUser(ValidateUserRequest request)
        {
            return await Post<ValidateUserResponse>(request);
        }

        /// <summary>
        ///     Sends a request to register the given user.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request)
        {
            return await Post<RegisterUserResponse>(request);
        }

        #endregion
    }
}