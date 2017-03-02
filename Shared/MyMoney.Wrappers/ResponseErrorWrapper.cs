namespace MyMoney.Wrappers
{
    #region Usings

    using System;

    #endregion

    public class ResponseErrorWrapper
    {
        #region  Properties

        public string ClassName { get; set; }

        public Exception Exception { get; set; }

        public string Message { get; set; }

        public string MethodName { get; set; }

        public DateTime Occurred { get; set; }

        public string Username { get; set; }

        #endregion
    }
}