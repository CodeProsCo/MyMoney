namespace MyMoney.Web.Orchestrators.Authentication
{
    #region Usings

    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Assemblers.Authentication.Interfaces;

    using DataAccess.Authentication.Interfaces;

    using Helpers.Error;

    using Interfaces;

    using ViewModels.Authentication.User;

    using Wrappers;

    #endregion

    /// <summary>
    ///     Handles actions regarding users.
    /// </summary>
    /// <seealso cref="IUserOrchestrator" />
    public class UserOrchestrator : IUserOrchestrator
    {
        #region Fields

        /// <summary>
        ///     The user assembler
        /// </summary>
        private readonly IUserAssembler assembler;

        /// <summary>
        ///     The user data access
        /// </summary>
        private readonly IUserDataAccess dataAccess;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserOrchestrator" /> class.
        /// </summary>
        /// <param name="assembler">
        ///     The assembler.
        /// </param>
        /// <param name="dataAccess">
        ///     The data Access.
        /// </param>
        public UserOrchestrator(IUserAssembler assembler, IUserDataAccess dataAccess)
        {
            if (assembler == null)
            {
                throw new ArgumentNullException(nameof(assembler));
            }

            if (dataAccess == null)
            {
                throw new ArgumentNullException(nameof(dataAccess));
            }

            this.assembler = assembler;
            this.dataAccess = dataAccess;
        }

        #endregion

        #region  Public Methods

        /// <summary>
        ///     Registers a user.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<OrchestratorResponseWrapper<bool>> RegisterUser(RegisterViewModel model)
        {
            var response = new OrchestratorResponseWrapper<bool>();

            try
            {
                var request = assembler.NewRegisterUserRequest(model);
                var apiResponse = await dataAccess.RegisterUser(request);

                if (!apiResponse.Success || !apiResponse.RegisterSuccess)
                {
                    response.AddErrors(apiResponse.Errors);
                }

                response.AddWarnings(apiResponse.Warnings);

                response.Model = apiResponse.RegisterSuccess;
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, model.EmailAddress, GetType(), "RegisterUser");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        ///     Gets the claim for the given user.
        /// </summary>
        /// <param name="model">The log in model.</param>
        /// <returns>If successful, the <see cref="ClaimsIdentity" /> for the user. If not, errors are returned.</returns>
        public async Task<OrchestratorResponseWrapper<ClaimsIdentity>> ValidateUser(LoginViewModel model)
        {
            var response = new OrchestratorResponseWrapper<ClaimsIdentity>();

            try
            {
                var request = assembler.NewValidateUserRequest(model);
                var apiResponse = await dataAccess.ValidateUser(request);

                if (!apiResponse.Success || !apiResponse.LoginSuccess)
                {
                    response.AddErrors(apiResponse.Errors);

                    return response;
                }

                response.AddWarnings(apiResponse.Warnings);

                response.Model = assembler.NewClaimsIdentity(apiResponse);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, model.EmailAddress, GetType(), "ValidateUser");
                response.AddError(err);
            }

            return response;
        }

        #endregion
    }
}