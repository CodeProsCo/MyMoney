namespace MyMoney.Web.Assemblers.Authentication
{
    #region Usings

    using System;
    using System.Security.Claims;

    using DTO.Request.Authentication;
    using DTO.Response.Authentication;

    using Interfaces;

    using JetBrains.Annotations;

    using ViewModels.Authentication.User;

    #endregion

    /// <summary>
    ///     Assembles objects regarding users.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Assemblers.Authentication.Interfaces.IUserAssembler" />
    [UsedImplicitly]
    public class UserAssembler : IUserAssembler
    {
        #region  Public Methods

        /// <summary>
        ///     Assembles an instance of the <see cref="ClaimsIdentity" /> class based on the given
        ///     <see cref="ValidateUserResponse" />.
        /// </summary>
        /// <param name="response">The response object.</param>
        /// <returns>
        ///     The claims identity.
        /// </returns>
        public ClaimsIdentity NewClaimsIdentity(ValidateUserResponse response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            return
                new ClaimsIdentity(
                    new[]
                        {
                            new Claim(ClaimTypes.Email, response.User.EmailAddress), 
                            new Claim(ClaimTypes.Surname, response.User.LastName), 
                            new Claim(ClaimTypes.GivenName, response.User.FirstName), 
                            new Claim(ClaimTypes.NameIdentifier, response.User.Id.ToString()), 
                            new Claim(ClaimTypes.Name, response.User.FirstName)
                        }, 
                    "ApplicationCookie");
        }

        /// <summary>
        ///     Assembles an instance of the <see cref="RegisterUserRequest" /> class based on the given
        ///     <see cref="RegisterViewModel" />.
        /// </summary>
        /// <param name="model">The register model.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        public RegisterUserRequest NewRegisterUserRequest(RegisterViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new RegisterUserRequest
                       {
                           EmailAddress = model.EmailAddress, 
                           Password = model.Password, 
                           DateOfBirth = model.DateOfBirth, 
                           FirstName = model.FirstName, 
                           LastName = model.LastName
                       };
        }

        /// <summary>
        ///     Assembles an instance of the <see cref="ValidateUserRequest" /> class based on the given
        ///     <see cref="LoginViewModel" />.
        /// </summary>
        /// <param name="model">The login model.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        public ValidateUserRequest NewValidateUserRequest(LoginViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new ValidateUserRequest { EmailAddress = model.EmailAddress, Password = model.Password };
        }

        #endregion
    }
}