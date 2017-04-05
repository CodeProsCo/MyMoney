namespace MyMoney.DTO.Response.Saving.Goal
{
    #region Usings

    using System.Collections.Generic;
    using System.Linq;

    using Proxies.Saving;

    #endregion

    /// <summary>
    /// The <see cref="GetGoalsForUserResponse"/> class is the 
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class GetGoalsForUserResponse : BaseResponse
    {
        #region Properties

        /// <summary>
        /// Gets the goal count.
        /// </summary>
        /// <value>
        /// The goal count.
        /// </value>
        public int GoalCount => Goals?.Count ?? 0;

        /// <summary>
        /// Gets or sets the goals.
        /// </summary>
        /// <value>
        /// The goals.
        /// </value>
        public IList<GoalProxy> Goals { get; set; }

        /// <summary>
        /// Gets the goal total.
        /// </summary>
        /// <value>
        /// The goal total.
        /// </value>
        public double GoalTotal => Goals?.Sum(x => x.Amount) ?? 0;

        #endregion
    }
}