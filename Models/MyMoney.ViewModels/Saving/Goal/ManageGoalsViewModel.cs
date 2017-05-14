namespace MyMoney.ViewModels.Saving.Goal
{
    #region Usings

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The <see cref="ManageGoalsViewModel"/> class contains all the view information for the manage goals page.
    /// </summary>
    public class ManageGoalsViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the add goal model.
        /// </summary>
        /// <value>
        /// The add goal model.
        /// </value>
        public AddGoalViewModel AddGoal { get; set; }

        /// <summary>
        /// Gets or sets the edit goal model.
        /// </summary>
        /// <value>
        /// The edit goal model.
        /// </value>
        public EditGoalViewModel EditGoal { get; set; }

        /// <summary>
        /// Gets or sets the goals.
        /// </summary>
        /// <value>
        /// The goals.
        /// </value>
        public IList<GoalViewModel> Goals { get; set; }

        #endregion
    }
}