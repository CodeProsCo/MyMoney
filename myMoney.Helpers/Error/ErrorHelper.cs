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
            return new ResponseErrorWrapper
            {
                ClassName = className.FullName,
                Exception = ex,
                Message = ex.Message,
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
                Exception = null,
                Message = message,
                MethodName = methodName,
                Occurred = DateTime.Now,
                Username = username
            };
        }

        #endregion
    }
}