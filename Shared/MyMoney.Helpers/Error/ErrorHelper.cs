namespace MyMoney.Helpers.Error
{
    #region Usings

    using System;

    using Wrappers;

    #endregion

    public static class ErrorHelper
    {
        #region  Public Methods

        public static ResponseErrorWrapper Create(Exception ex, string username, Type className, string methodName)
        {
            var message = string.Empty;

            while (ex != null)
            {
                message += $"{ex.Message} ";
                ex = ex.InnerException;
            }

            return new ResponseErrorWrapper
            {
                ClassName = className.FullName,
                Message = message,
                MethodName = methodName,
                Occurred = DateTime.Now,
                Username = username
            };
        }

        public static ResponseErrorWrapper Create(string message, string username, Type className, string methodName)
        {
            return new ResponseErrorWrapper
            {
                ClassName = className.FullName,
                Message = message,
                MethodName = methodName,
                Occurred = DateTime.Now,
                Username = username
            };
        }

        #endregion
    }
}