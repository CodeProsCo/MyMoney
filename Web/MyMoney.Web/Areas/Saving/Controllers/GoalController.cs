namespace MyMoney.Web.Areas.Saving.Controllers
{
    #region Usings

    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Orchestrators.Saving.Interfaces;

    using Web.Controllers;

    #endregion

    [RouteArea("Saving", AreaPrefix = "savings")]
    [RoutePrefix("goals")]
    [Authorize]
    public class GoalController : BaseController
    {
        private IGoalOrchestrator orchestrator;

        public GoalController(IGoalOrchestrator orchestrator)
        {
            if (orchestrator == null)
            {
                throw new ArgumentNullException(nameof(orchestrator));
            }

            this.orchestrator = orchestrator;
        }

        #region Methods

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> Manage()
        {
            var response = await orchestrator.GetGoalsForUser(UserId, UserEmail);

            AddModelErrors(response.Errors);
            AddModelWarnings(response.Warnings);

            return View("Manage", response.Model);
        }

        #endregion
    }
}