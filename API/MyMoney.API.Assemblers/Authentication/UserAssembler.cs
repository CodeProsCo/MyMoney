namespace MyMoney.API.Assemblers.Authentication
{
    #region Usings

    using System;

    using DataModels.Authentication;

    using DTO.Request.Authentication;
    using DTO.Response.Authentication;

    using Interfaces;

    using JetBrains.Annotations;

    using Proxies.Authentication;

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
                           User =
                               new UserProxy
                                   {
                                       FirstName = userDataModel?.FirstName, 
                                       LastName = userDataModel?.LastName, 
                                       EmailAddress = userDataModel?.EmailAddress, 
                                       DateOfBirth =
                                           userDataModel?.DateOfBirth ?? DateTime.MinValue, 
                                       Id = userDataModel?.Id ?? Guid.Empty
                                   }, 
                           RequestReference = reqReference
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