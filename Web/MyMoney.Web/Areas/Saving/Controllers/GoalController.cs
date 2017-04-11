namespace MyMoney.Web.Areas.Saving.Controllers
{
    #region Usings

    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Attributes;

    using Helpers.Views;

    using Orchestrators.Saving.Interfaces;

    using ViewModels.Saving.Goal;

    using Web.Controllers;

    #endregion

    /// <summary>
    /// The <see cref="GoalController"/> class handles HTTP requests regarding goals.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Controllers.BaseController" />
    [RouteArea("Saving", AreaPrefix = "savings")]
    [RoutePrefix("goals")]
    [Authorize]
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
        /// Handles an HTTP request to add a goal.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The response object.</returns>
        [HttpPost]
        [Route("add")]
        [AjaxOnly]
        public async Task<ActionResult> Add(GoalViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return InvalidModelState(ModelState);
            }

            model.UserId = UserId;

            var response = await orchestrator.AddGoal(model, UserEmail);

            return JsonResponse(response);
        }

        /// <summary>
        /// Handles an HTTP request to remove a goal.
        /// </summary>
        /// <param name="goalId">The goal identifier.</param>
        /// <returns>The response object.</returns>
        [HttpGet]
        [Route("delete/{goalId:Guid}")]
        [AjaxOnly]
        public async Task<ActionResult> Delete(Guid goalId)
        {
            var response = await orchestrator.DeleteGoal(goalId, UserEmail);

            return JsonResponse(response);
        }

        /// <summary>
        /// Handles an HTTP request to modify a goal.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The response object.</returns>
        [HttpPost]
        [Route("edit")]
        [AjaxOnly]
        public async Task<ActionResult> Edit(GoalViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return InvalidModelState(ModelState);
            }

            model.UserId = UserId;

            var response = await orchestrator.EditGoal(model, UserEmail);

            return JsonResponse(response);
        }

        /// <summary>
        /// Returns the "Manage Goals" view.
        /// </summary>
        /// <returns>The view.</returns>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult> Manage()
        {
            var response = await orchestrator.GetGoalsForUser(UserId, UserEmail);

            AddModelErrors(response.Errors);
            AddModelWarnings(response.Warnings);

            return View("Manage", response.Model);
        }

        [HttpGet]
        [AjaxOnly]
        [Route("get/{goalId:Guid}")]
        public async Task<ActionResult> Get(Guid goalId)
        {
            var response = await orchestrator.GetGoal(goalId, UserEmail);

            return JsonResponse(response);
        }

        [HttpGet]
        [AjaxOnly]
        [Route("progress/{goalId:Guid}")]
        public async Task<ActionResult> GetProgressView(Guid goalId)
        {
            var response = await orchestrator.GetGoal(goalId, UserEmail);

            var result = ViewHelper.RenderViewToString(
                "Components/_GoalProgressBar",
                response.Model,
                ControllerContext,
                ViewData,
                TempData);

            return ViewResponse(result);
        }

        #endregion
    }
}