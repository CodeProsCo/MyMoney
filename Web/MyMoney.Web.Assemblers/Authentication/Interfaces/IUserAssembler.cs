namespace MyMoney.Web.Assemblers.Authentication.Interfaces
{
    #region Usings

    using System.Security.Claims;

    using DTO.Request.Authentication;
    using DTO.Response.Authentication;

    using ViewModels.Authentication.User;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="UserAssembler" /> class.
    /// </summary>
    public interface IUserAssembler
    {
        #region  Public Methods

        /// <summary>
        ///     Assembles an instance of the <see cref="ClaimsIdentity" /> class based on the given
        ///     <see cref="GetClaimForUserResponse" />.
        /// </summary>
        /// <param name="response">The response object.</param>
        /// <returns>The claims identity.</returns>
        ClaimsIdentity NewClaimsIdentity(GetClaimForUserResponse response);

        /// <summary>
        ///     Assembles an instance of the <see cref="GetClaimForUserRequest" /> class based on the given
        ///     <see cref="LoginViewModel" />.
        /// </summary>
        /// <param name="model">The login model.</param>
        /// <returns>The request object.</returns>
        GetClaimForUserRequest NewGetClaimForUserRequest(LoginViewModel model);

        /// <summary>
        ///     Assembles an instance of the <see cref="RegisterUserRequest" /> class based on the given
        ///     <see cref="RegisterViewModel" />.
        /// </summary>
        /// <param name="model">The register model.</param>
        /// <returns>The request object.</returns>
        RegisterUserRequest NewRegisterUserRequest(RegisterViewModel model);

        #endregion
    }
}