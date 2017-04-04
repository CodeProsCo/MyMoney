namespace MyMoney.DTO.Request.Saving.Goal
{
    #region Usings

    using System;

    using MyMoney.DTO.Request.Interfaces;

    #endregion

    /// <summary>
    ///     The <see cref="DeleteGoalRequest" /> class is used for deleting a goal from the database.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Request.BaseRequest" />
    /// <seealso cref="MyMoney.DTO.Request.Interfaces.IDeleteRequest" />
    public class DeleteGoalRequest : BaseRequest, IDeleteRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="DeleteGoalRequest" /> class.
        /// </summary>
        public DeleteGoalRequest()
            : base("spending/goals/delete/{0}/{1}/")
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