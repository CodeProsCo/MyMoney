namespace MyMoney.DTO.Request.Saving.Goal
{
    #region Usings

    using System;

    using MyMoney.DTO.Request.Interfaces;

    #endregion

    /// <summary>
    ///     The <see cref="GetGoalRequest" /> class is used for obtaining a goal from the database.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Request.BaseRequest" />
    /// <seealso cref="MyMoney.DTO.Request.Interfaces.IGetRequest" />
    public class GetGoalRequest : BaseRequest, IGetRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetGoalRequest" /> class.
        /// </summary>
        public GetGoalRequest()
            : base("spending/goals/get/{0}/{1}/")
        {
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the goal identifier.
        /// </summary>
        /// <value>
        ///     The goal identifier.
        /// </value>
        public Guid GoalId { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Formats the request URI.
        /// </summary>
        /// <returns>
        ///     The formatted uri.
        /// </returns>
        public string FormatRequestUri()
        {
            return string.Format(GetAction(), GoalId, RequestReference);
        }

        #endregion
    }
}