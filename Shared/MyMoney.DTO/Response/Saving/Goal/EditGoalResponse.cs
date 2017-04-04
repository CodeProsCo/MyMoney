﻿namespace MyMoney.DTO.Response.Saving.Goal
{
    #region Usings

    using MyMoney.DTO.Request.Saving.Goal;
    using MyMoney.Proxies.Saving;

    #endregion

    /// <summary>
    ///     The <see cref="EditGoalResponse" /> class is the response object for a <see cref="EditGoalRequest" /> request.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class EditGoalResponse : BaseResponse
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