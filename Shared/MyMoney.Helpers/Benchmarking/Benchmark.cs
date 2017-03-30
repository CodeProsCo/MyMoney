namespace MyMoney.Helpers.Benchmarking
{
    #region Usings

    using System;
    using System.Diagnostics;

    #endregion

    /// <summary>
    ///     The <see cref="Benchmark" /> class records how long something takes. This should be wrapped around
    ///     the method you are using in a using statement. It should also be created using the <see cref="BenchmarkHelper" />
    ///     class.
    /// </summary>
    /// <example>
    ///     using (BenchmarkHelper.Create(uri))
    ///     {
    ///     httpResponse = await Client.DeleteAsync(uri);
    ///     }
    /// </example>
    /// <seealso cref="System.IDisposable" />
    public class Benchmark : IDisposable
    {
        #region Constants

        /// <summary>
        ///     The trace format
        /// </summary>
        private const string TraceFormat =
            "Request Start:\t{0}\nUri:\t\t\t{1}\nTime Taken:\t\t{2}s\n===============================";

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="Benchmark" /> class.
        /// </summary>
        /// <param name="uri">The request URI.</param>
        public Benchmark(string uri)
        {
            RequestUri = uri;
            StartTime = DateTime.Now;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the end time.
        /// </summary>
        /// <value>
        ///     The end time.
        /// </value>
        private DateTime EndTime { get; set; }

        /// <summary>
        ///     Gets the request URI.
        /// </summary>
        /// <value>
        ///     The request URI.
        /// </value>
        private string RequestUri { get; }

        /// <summary>
        ///     Gets the start time.
        /// </summary>
        /// <value>
        ///     The start time.
        /// </value>
        private DateTime StartTime { get; }

        #endregion

        #region Methods

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            EndTime = DateTime.Now;

            var entry = string.Format(TraceFormat, StartTime, RequestUri, (EndTime - StartTime).TotalSeconds);

            if (Debugger.IsAttached)
            {
                Trace.WriteLine(entry);
            }
        }

        #endregion
    }
}