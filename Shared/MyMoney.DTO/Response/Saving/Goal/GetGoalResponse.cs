namespace MyMoney.DTO.Response.Saving.Goal
{
    #region Usings

    using Proxies.Saving;

    using Request.Saving.Goal;

    #endregion

    /// <summary>
    ///     The <see cref="GetGoalResponse" /> class is the response object for a <see cref="GetGoalRequest" /> request.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class GetGoalResponse : BaseResponse
    {
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