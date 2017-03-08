namespace MyMoney.Helpers.Error
{
    #region Usings

    using System;
    using System.Diagnostics;

    using Wrappers;

    #endregion

    public static class ErrorHelper
    {
        #region  Public Methods

        private const string TraceFormat = "Error Time:\t\t{0}\nMessage:\t\t{1}\nClass Name:\t\t{2}\nMethod Name:\t{3}\n===============================";

        public static ResponseErrorWrapper Create(Exception ex, string username, Type className, string methodName)
        {
            var message = string.Empty;

            while (ex != null)
            {
                message += $"{ex.Message} ";
                ex = ex.InnerException;
            }

            return Create(message, username, className, methodName);
        }

        public static ResponseErrorWrapper Create(string message, string username, Type className, string methodName)
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

        private static void WriteTrace(ResponseErrorWrapper error)
        {
            if (Debugger.IsAttached)
            {
                Trace.WriteLine(
                    string.Format(TraceFormat, error.Occurred, error.Message, error.ClassName, error.MethodName));
            }
        }

        #endregion
    }
}