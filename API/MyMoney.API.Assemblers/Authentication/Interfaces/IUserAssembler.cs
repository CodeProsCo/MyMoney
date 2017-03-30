namespace MyMoney.API.Assemblers.Authentication.Interfaces
{
    #region Usings

    using System;

    using MyMoney.DataModels.Authentication;
    using MyMoney.DTO.Request.Authentication;
    using MyMoney.DTO.Response.Authentication;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="UserAssembler" /> class.
    /// </summary>
    public interface IUserAssembler
    {
        #region Methods

        /// <summary>
        ///     Creates a new instance of the <see cref="ValidateUserResponse" /> class.
        /// </summary>
        /// <param name="userDataModel">The user data model.</param>
        /// <param name="reqReference">The request reference.</param>
        /// <returns>The response object.</returns>
        ValidateUserResponse NewGetClaimForUserResponse(UserDataModel userDataModel, Guid reqReference);

        /// <summary>
        ///     Creates a new instance of the <see cref="RegisterUserResponse" /> class.
        /// </summary>
        /// <param name="registerResult">The register result.</param>
        /// <param name="reqReference">The request reference.</param>
        /// <returns>The response object.</returns>
        RegisterUserResponse NewRegisterUserResponse(UserDataModel registerResult, Guid reqReference);

        /// <summary>
        ///     Creates a new instance of the <see cref="UserDataModel" /> class.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The user data model.</returns>
        UserDataModel NewUserDataModel(RegisterUserRequest request);

        #endregion
    }
}