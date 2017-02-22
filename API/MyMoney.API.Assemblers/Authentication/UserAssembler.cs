namespace MyMoney.API.Assemblers.Authentication
{
    #region Usings

    using System;

    using DataModels.Authentication.User;

    using DTO.Request.Authentication;
    using DTO.Response.Authentication;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     Assembles objects regarding users.
    /// </summary>
    /// <seealso cref="MyMoney.API.Assemblers.Authentication.Interfaces.IUserAssembler" />
    [UsedImplicitly]
    public class UserAssembler : IUserAssembler
    {
        #region  Public Methods

        public GetClaimForUserResponse NewGetClaimForUserResponse(UserDataModel userDataModel, Guid reqReference)
        {
            var success = userDataModel != null;

            return new GetClaimForUserResponse
                       {
                           LoginSuccess = success, 
                           FirstName = userDataModel?.FirstName, 
                           LastName = userDataModel?.LastName, 
                           EmailAddress = userDataModel?.EmailAddress, 
                           DateOfBirth = userDataModel?.DateOfBirth, 
                           RequestReference = reqReference,
                           UserId = userDataModel?.Id
                       };
        }

        public RegisterUserResponse NewRegisterUserResponse(UserDataModel registerResult, Guid reqReference)
        {
            return new RegisterUserResponse
                       {
                           RegisterSuccess = registerResult != null, 
                           RequestReference = reqReference
                       };
        }

        public UserDataModel NewUserDataModel(RegisterUserRequest request)
        {
            return new UserDataModel
                       {
                           DateOfBirth = request.DateOfBirth, 
                           EmailAddress = request.EmailAddress, 
                           FirstName = request.FirstName, 
                           LastName = request.LastName, 
                           Password = request.Password
                       };
        }

        #endregion
    }
}