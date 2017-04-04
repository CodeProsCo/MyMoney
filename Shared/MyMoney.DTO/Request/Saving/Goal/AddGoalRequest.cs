namespace MyMoney.DTO.Request.Saving.Goal
{
    #region Usings

    using MyMoney.Proxies.Saving;

    #endregion

    /// <summary>
    ///     The <see cref="AddGoalRequest" /> class is used when adding a goal to the database.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Request.BaseRequest" />
    public class AddGoalRequest : BaseRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="AddGoalRequest" /> class.
        /// </summary>
        public AddGoalRequest()
            : base("spending/goals/add")
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