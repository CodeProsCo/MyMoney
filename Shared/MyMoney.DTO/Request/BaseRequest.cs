namespace MyMoney.DTO.Request
{
    #region Usings

    using System;

    #endregion

    /// <summary>
    ///     The base class for all request objects.
    /// </summary>
    public class BaseRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseRequest" /> class.
        /// </summary>
        /// <param name="action">The action.</param>
        protected BaseRequest(string action)
        {
            Action = action;
            RequestReference = Guid.NewGuid();
        }

        #endregion

        #region  Properties

        /// <summary>
        ///     Gets the request reference.
        /// </summary>
        /// <value>
        ///     The request reference.
        /// </value>
        public Guid RequestReference { get; }

        /// <summary>
        ///     Gets or sets the username.
        /// </summary>
        /// <value>
        ///     The username.
        /// </value>
        public string Username { get; set; }

        /// <summary>
        ///     Gets the action.
        /// </summary>
        /// <value>
        ///     The action.
        /// </value>
        private string Action { get; }

        #endregion

        #region  Public Methods

        /// <summary>
        ///     Gets the action.
        /// </summary>
        /// <returns>The action.</returns>
        public string GetAction()
        {
            return Action;
        }

        #endregion
    }
}