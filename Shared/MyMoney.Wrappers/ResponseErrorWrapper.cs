namespace MyMoney.Wrappers
{
    #region Usings

    using System;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     The <see cref="ResponseErrorWrapper" /> class contains detailed error information.
    /// </summary>
    public class ResponseErrorWrapper
    {
        #region  Properties

        /// <summary>
        ///     Gets or sets the name of the class.
        /// </summary>
        /// <value>
        ///     The name of the class.
        /// </value>
        public string ClassName { [UsedImplicitly] get; set; }

        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        /// <value>
        ///     The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        ///     Gets or sets the name of the method.
        /// </summary>
        /// <value>
        ///     The name of the method.
        /// </value>
        public string MethodName { [UsedImplicitly] get; set; }

        /// <summary>
        ///     Gets or sets the occurred.
        /// </summary>
        /// <value>
        ///     The occurred.
        /// </value>
        public DateTime Occurred { [UsedImplicitly] get; set; }

        /// <summary>
        ///     Gets or sets the username.
        /// </summary>
        /// <value>
        ///     The username.
        /// </value>
        public string Username { [UsedImplicitly] get; set; }

        #endregion
    }
}