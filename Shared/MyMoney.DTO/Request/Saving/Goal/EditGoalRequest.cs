namespace MyMoney.DTO.Request.Saving.Goal
{
    #region Usings

    using MyMoney.Proxies.Saving;

    #endregion

    /// <summary>
    ///     The <see cref="EditGoalRequest" /> class is used for editing a goal in the database.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Request.BaseRequest" />
    public class EditGoalRequest : BaseRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="EditGoalRequest" /> class.
        /// </summary>
        public EditGoalRequest()
            : base("spending/goals/edit")
        {
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the goal.
        /// </summary>
        /// <value>
        ///     The goal.
        /// </value>
        public GoalProxy Goal { get; set; }

        #endregion
    }
}