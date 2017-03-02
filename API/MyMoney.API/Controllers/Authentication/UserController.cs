namespace MyMoney.API.Controllers.Authentication
{
    #region Usings

    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

    using DTO.Request.Authentication;

    using Orchestrators.Authentication.Interfaces;

    #endregion

    /// <summary>
    ///     Handles all API requests regarding user authentication.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("auth/user")]
    public class UserController : ApiController
    {
        #region Fields

        /// <summary>
        ///     The orchestrator
        /// </summary>
        private readonly IUserOrchestrator orchestrator;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserController" /> class.
        /// </summary>
        /// <param name="orchestrator">The orchestrator.</param>
        /// <exception cref="System.ArgumentNullException">Exception thrown if the orchestrator is null.</exception>
        public UserController(IUserOrchestrator orchestrator)
        {
            if (orchestrator == null)
            {
                throw new ArgumentNullException(nameof(orchestrator));
            }

            this.orchestrator = orchestrator;
        }

        #endregion

        #region  Public Methods

        /// <summary>
        ///     Gets a claim for the given user.
        /// </summary>
        /// <returns>The response object.</returns>
        [HttpGet]
        [Route("get/{emailAddress}/{password}/{requestRef:Guid}")]
        public async Task<IHttpActionResult> GetClaimForUser([FromUri] GetClaimForUserRequest request)
        {
            var response = await orchestrator.GetClaimForUser(request);

            return Ok(response);
        }

        /// <summary>
        /// Registers a user.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>The response object.</returns>
        [HttpPost]
        [Route("register")]
        public async Task<IHttpActionResult> RegisterUser([FromBody] RegisterUserRequest request)
        {
            var response = await orchestrator.RegisterUser(request);

            return Ok(response);
        }

        #endregion
    }
}