namespace MyMoney.Helpers.Error
{
    #region Usings

    using System;
    using System.Diagnostics;

    using LLibrary;

    using Wrappers;

    #endregion

    public static class ErrorHelper
    {
        #region Constants

        private const string TraceFormat =
            "Error Time:\t\t{0}\nMessage:\t\t{1}\nClass Name:\t\t{2}\nMethod Name:\t{3}\n===============================";

        #endregion

        #region  Public Methods

        public static ResponseErrorWrapper Create(Exception ex, string username, Type className, string methodName)
        {
            L.Log("Exception", ex);

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

        #endregion

        #region Private Methods

        private static void WriteTrace(ResponseErrorWrapper error)
        {
            var logFormat = string.Format(TraceFormat, error.Occurred, error.Message, error.ClassName, error.MethodName);

            if (Debugger.IsAttached)
            {
                Trace.WriteLine(logFormat);
            }

            L.Log("Error", logFormat);
        }

        #endregion
    }
}