namespace MyMoney.API.Controllers.Saving
{
    #region Usings

    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

    using MyMoney.API.Orchestrators.Saving.Interfaces;
    using MyMoney.DTO.Request.Saving.Goal;

    #endregion

    /// <summary>
    /// The <see cref="GoalController"/> class handles HTTP requests for the "spending/goals" route.
    /// </summary>
    [RoutePrefix("spending/goals")]
    public class GoalController : BaseController
    {
        #region Fields

        /// <summary>
        /// The orchestrator
        /// </summary>
        private readonly IGoalOrchestrator orchestrator;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GoalController"/> class.
        /// </summary>
        /// <param name="orchestrator">The orchestrator.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Exception thrown if the orchestrator is null.
        /// </exception>
        public GoalController(IGoalOrchestrator orchestrator)
        {
            if (orchestrator == null)
            {
                throw new ArgumentNullException(nameof(orchestrator));
            }

            this.orchestrator = orchestrator;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Handles an HTTP POST request to add a goal to the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object. Wrapped in a 200 response.</returns>
        [HttpPost]
        [Route("add")]
        public async Task<IHttpActionResult> AddGoal([FromBody] AddGoalRequest request)
        {
            var response = await orchestrator.AddGoal(request, request.Username);

            return Ok(response);
        }

        /// <summary>
        ///     Handles an HTTP DELETE request to remove a goal from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object. Wrapped in a 200 response.</returns>
        [HttpDelete]
        [Route("delete/{goalId:Guid}/{requestReference:Guid}")]
        public async Task<IHttpActionResult> DeleteGoal([FromUri] DeleteGoalRequest request)
        {
            var response = await orchestrator.DeleteGoal(request);

            return Ok(response);
        }

        /// <summary>
        ///     Handles an HTTP POST request to edit a goal in the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object. Wrapped in a 200 response.</returns>
        [HttpPost]
        [Route("edit")]
        public async Task<IHttpActionResult> EditGoal([FromBody] EditGoalRequest request)
        {
            var response = await orchestrator.EditGoal(request);

            return Ok(response);
        }

        /// <summary>
        ///     Handles an HTTP GET request to obtain a goal from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object. Wrapped in a 200 response.</returns>
        [HttpGet]
        [Route("get/{goalId:Guid}/{requestReference:Guid}")]
        public async Task<IHttpActionResult> GetGoal([FromUri] GetGoalRequest request)
        {
            var response = await orchestrator.GetGoal(request);

            return Ok(response);
        }

        /// <summary>
        ///     Handles an HTTP GET request for obtaining the goals for a given user from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object. Wrapped in a 200 response.</returns>
        [HttpGet]
        [Route("user/{userId:Guid}/{requestReference:Guid}/")]
        public async Task<IHttpActionResult> GetGoalsForUser([FromUri] GetGoalsForUserRequest request)
        {
            var response = await orchestrator.GetGoalsForUser(request);

            return Ok(response);
        }

        #endregion
    }
}