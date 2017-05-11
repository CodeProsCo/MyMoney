namespace MyMoney.Helpers.Error
{
    #region Usings

    using System;
    using System.Diagnostics;

    using Interfaces;

    using JetBrains.Annotations;

    using Wrappers;

    #endregion

    /// <summary>
    /// The <see cref="ErrorHelper"/> class creates instances of the <see cref="ResponseErrorWrapper"/> class for use when components throw exceptions or fail to perform an action.
    /// </summary>
    [UsedImplicitly]
    public class ErrorHelper : IErrorHelper
    {
        #region Constants

        /// <summary>
        /// The trace format
        /// </summary>
        private const string TraceFormat =
            "Error Time:\t\t{0}\nMessage:\t\t{1}\nClass Name:\t\t{2}\nMethod Name:\t{3}\n===============================";

        #endregion

        #region Methods

        /// <summary>
        /// Creates the error wrapper using the given exception.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="username">The username.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns>The error wrapper.</returns>
        public ResponseErrorWrapper Create(Exception ex, string username, Type className, string methodName)
        {
            var message = string.Empty;

            while (ex != null)
            {
                message += $"{ex.Message} ";
                ex = ex.InnerException;
            }

            return Create(message, username, className, methodName);
        }

        /// <summary>
        /// Creates the specified error wrapper using the given message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="username">The username.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns>The error wrapper.</returns>
        public ResponseErrorWrapper Create(string message, string username, Type className, string methodName)
        {
            var retVal = new ResponseErrorWrapper
                             {
                                 ClassName = className.FullName,
                                 Message = message,
                                 MethodName = methodName,
                                 Occurred = DateTime.Now,
                                 Username = username
                             };

            WriteTrace(retVal);

            return retVal;
        }

        /// <summary>
        /// Writes the trace.
        /// </summary>
        /// <param name="error">The error.</param>
        private void WriteTrace(ResponseErrorWrapper error)
        {
            var logFormat = string.Format(TraceFormat, error.Occurred, error.Message, error.ClassName, error.MethodName);

            if (Debugger.IsAttached)
            {
                Trace.WriteLine(logFormat);
            }
        }

        #endregion
    }
}