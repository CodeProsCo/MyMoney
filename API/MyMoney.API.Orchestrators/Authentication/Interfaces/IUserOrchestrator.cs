namespace MyMoney.API.Orchestrators.Authentication.Interfaces
{
    #region Usings

    #region Usings

    using System.Threading.Tasks;

    using DTO.Request.Authentication;
    using DTO.Response.Authentication;

    #endregion

    #endregion

    /// <summary>
    ///     Interface for the <see cref="UserOrchestrator" /> class.
    /// </summary>
    public interface IUserOrchestrator
    {
        #region  Public Methods

        /// <summary>
        /// Obtains a claim for the given user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<ValidateUserResponse> ValidateUser(ValidateUserRequest request);

        /// <summary>
        ///     Registers a user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request);

        #endregion
    }
}