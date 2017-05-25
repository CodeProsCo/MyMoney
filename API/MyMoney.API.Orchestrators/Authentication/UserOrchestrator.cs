namespace MyMoney.API.Orchestrators.Authentication
{
    #region Usings

    using System;
    using System.Threading.Tasks;

    using Assemblers.Authentication.Interfaces;

    using DataAccess.Authentication.Interfaces;

    using DTO.Request.Authentication;
    using DTO.Response.Authentication;

    using Helpers.Error.Interfaces;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     Handles actions regarding user authentication.
    /// </summary>
    /// <seealso cref="MyMoney.API.Orchestrators.Authentication.Interfaces.IUserOrchestrator" />
    [UsedImplicitly]
    public class UserOrchestrator : BaseOrchestrator, IUserOrchestrator
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
        /// <param name="assembler">
        ///     The assembler.
        /// </param>
        /// <param name="repository">
        ///     The repository.
        /// </param>
        /// <param name="errorHelper">
        ///     The error helper.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///     Exception thrown if the assembler or repository are null.
        /// </exception>
        public UserOrchestrator(IUserAssembler assembler, IUserRepository repository, IErrorHelper errorHelper) : base(errorHelper)
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

        #region Methods

        /// <summary>
        ///     Registers a user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request)
        {
            return await Orchestrate(async delegate{
                var dataModel = assembler.NewUserDataModel(request);
                var registerResult = await repository.RegisterUser(dataModel);

                return assembler.NewRegisterUserResponse(registerResult, request.RequestReference);
            }, request);
        }

        /// <summary>
        ///     Obtains a claim for the given user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<ValidateUserResponse> ValidateUser(ValidateUserRequest request)
        {
            return await Orchestrate(async delegate{
                var userDataModel = await repository.GetUser(request.EmailAddress, request.Password);

                return assembler.NewValidateUserResponse(userDataModel, request.RequestReference);
            }, request);
        }

        #endregion
    }
}