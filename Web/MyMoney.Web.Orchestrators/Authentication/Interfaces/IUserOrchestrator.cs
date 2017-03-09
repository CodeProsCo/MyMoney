namespace MyMoney.Web.Orchestrators.Authentication.Interfaces
{
    #region Usings

    using System.Security.Claims;
    using System.Threading.Tasks;

    using ViewModels.Authentication.User;

    using Wrappers;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="UserOrchestrator" /> class.
    /// </summary>
    public interface IUserOrchestrator
    {
        #region  Public Methods

        /// <summary>
        ///     Registers a user.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The response object.</returns>
        Task<OrchestratorResponseWrapper<bool>> RegisterUser(RegisterViewModel model);

        /// <summary>
        ///     Gets the claim a user.
        /// </summary>
        /// <param name="model">The login model.</param>
        /// <returns>The user's claim.</returns>
        Task<OrchestratorResponseWrapper<ClaimsIdentity>> ValidateUser(LoginViewModel model);

        #endregion
    }
}