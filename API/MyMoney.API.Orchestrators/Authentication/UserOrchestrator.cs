namespace MyMoney.API.Orchestrators.Authentication
{
    #region Usings

    using System;
    using System.Threading.Tasks;

    using Assemblers.Authentication.Interfaces;

    using DataAccess.Authentication.Interfaces;

    using DTO.Request.Authentication;
    using DTO.Response.Authentication;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     Handles actions regarding user authentication.
    /// </summary>
    /// <seealso cref="MyMoney.API.Orchestrators.Authentication.Interfaces.IUserOrchestrator" />
    [UsedImplicitly]
    public class UserOrchestrator : IUserOrchestrator
    {
        #region Fields

        /// <summary>
        ///     The assembler
        /// </summary>
        private readonly IUserAssembler assembler;

        /// <summary>
        ///     The repository
        /// </summary>
        private readonly IUserRepository repository;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserOrchestrator" /> class.
        /// </summary>
        /// <param name="assembler">The assembler.</param>
        /// <param name="repository">The repository.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     Exception thrown if the assembler or repository are null.
        /// </exception>
        public UserOrchestrator(IUserAssembler assembler, IUserRepository repository)
        {
            if (assembler == null)
            {
                throw new ArgumentNullException(nameof(assembler));
            }

            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            this.assembler = assembler;
            this.repository = repository;
        }

        #endregion

        #region  Public Methods

        /// <summary>
        ///     Gets the claim for the given user.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<GetClaimForUserResponse> GetClaimForUser(GetClaimForUserRequest request)
        {
            var response = new GetClaimForUserResponse();

            try
            {
                var userDataModel = await repository.GetUser(request.EmailAddress, request.Password);

                response = assembler.NewGetClaimForUserResponse(userDataModel, request.RequestReference);
            }
            catch (Exception ex)
            {
                response.AddError(ex);
            }

            return response;
        }

        public async Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request)
        {
            var response = new RegisterUserResponse();

            try
            {
                var dataModel = assembler.NewUserDataModel(request);
                var registerResult = await repository.RegisterUser(dataModel);

                response = assembler.NewRegisterUserResponse(registerResult, request.RequestReference);
            }
            catch (Exception ex)
            {
                response.AddError(ex);
            }

            return response;
        }

        #endregion
    }
}