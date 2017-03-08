namespace MyMoney.Helpers.Network
{
    #region Usings

    using System;
    using System.Diagnostics;

    #endregion

    public class RequestBenchmark : IDisposable
    {
        #region Constants

        private const string TraceFormat = "Request Start:\t{0}\nUri:\t\t\t{1}\nTime Taken:\t\t{2}s\n===============================";

        #endregion

        #region Constructor

        public RequestBenchmark(string uri)
        {
            RequestUri = uri;
            StartTime = DateTime.Now;
        }

        #endregion

        #region  Properties

        public DateTime EndTime { get; set; }

        public string RequestUri { get; set; }

        public DateTime StartTime { get; set; }

        #endregion

        #region  Public Methods

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            EndTime = DateTime.Now;

            if (Debugger.IsAttached)
            {
                Trace.WriteLine(string.Format(TraceFormat, StartTime, RequestUri, (EndTime - StartTime).TotalSeconds));
            }
        }

        #endregion
    }
}