namespace MyMoney.DTO.Request.Saving.Goal
{
    #region Usings

    using System;

    using Interfaces;

    #endregion

    /// <summary>
    ///     The<see cref="GetGoalsForUserRequest" /> class is used for obtaining the list of goals for a user.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Request.BaseRequest" />
    /// <seealso cref="MyMoney.DTO.Request.Interfaces.IGetRequest" />
    public class GetGoalsForUserRequest : BaseRequest, IGetRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetGoalsForUserRequest" /> class.
        /// </summary>
        public GetGoalsForUserRequest()
            : base("spending/goals/user/{0}/{1}/")
        {
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the user identifier.
        /// </summary>
        /// <value>
        ///     The user identifier.
        /// </value>
        public Guid UserId { get; set; }

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
            return string.Format(GetAction(), UserId, RequestReference);
        }

        #endregion
    }
}