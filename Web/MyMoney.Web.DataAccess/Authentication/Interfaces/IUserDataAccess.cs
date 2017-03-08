namespace MyMoney.Web.DataAccess.Authentication.Interfaces
{
    #region Usings

    using System.Threading.Tasks;

    using DTO.Request.Authentication;
    using DTO.Response.Authentication;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="UserDataAccess" /> class.
    /// </summary>
    public interface IUserDataAccess
    {
        #region  Public Methods

        /// <summary>
        ///     Sends a request to obtain the claims identity information for the given user.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>The response object.</returns>
        Task<ValidateUserResponse> ValidateUser(ValidateUserRequest request);

        /// <summary>
        ///     Sends a request to register the given user.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>The response object.</returns>
        Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request);

        #endregion
    }
}