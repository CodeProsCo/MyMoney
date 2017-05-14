namespace MyMoney.Helpers.Error.Interfaces
{
    #region Usings

    using System;

    using Wrappers;

    #endregion

    /// <summary>
    /// The interface for the <see cref="ErrorHelper"/> class.
    /// </summary>
    public interface IErrorHelper
    {
        #region Methods

        /// <summary>
        /// Creates an instance of the <see cref="ResponseErrorWrapper"/> class.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="username">The username.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns>The error wrapper.</returns>
        ResponseErrorWrapper Create(Exception ex, string username, Type className, string methodName);

        /// <summary>
        /// Creates an instance of the <see cref="ResponseErrorWrapper"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="username">The username.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns>The error wrapper</returns>
        ResponseErrorWrapper Create(string message, string username, Type className, string methodName);

        #endregion
    }
}