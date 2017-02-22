namespace MyMoney.API.Orchestrators.Authentication.Interfaces
{
    #region Usings

    using System.Threading.Tasks;

    using DTO.Request.Authentication;
    using DTO.Response.Authentication;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="UserOrchestrator" /> class.
    /// </summary>
    public interface IUserOrchestrator
    {
        #region  Public Methods

        /// <summary>
        ///     Gets the claim for the given user.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>The response object.</returns>
        Task<GetClaimForUserResponse> GetClaimForUser(GetClaimForUserRequest request);

        Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request);

        #endregion
    }
}