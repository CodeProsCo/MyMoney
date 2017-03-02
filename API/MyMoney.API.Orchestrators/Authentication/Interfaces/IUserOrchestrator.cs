namespace MyMoney.API.Orchestrators.Authentication.Interfaces
{
    using System;
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
        /// Registers a user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request);

        Task<GetClaimForUserResponse> GetClaimForUser(string username, string password, Guid requestRef);

        #endregion
    }
}