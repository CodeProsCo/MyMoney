namespace MyMoney.Helpers.Benchmarking.Interfaces
{
    #region Usings

    using System;

    #endregion

    /// <summary>
    /// The interface for the <see cref="BenchmarkHelper"/> class.
    /// </summary>
    public interface IBenchmarkHelper
    {
        #region Methods

        /// <summary>
        /// Creates an instance of the <see cref="Benchmark"/> class which when disposed determines how long an action has taken.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>The benchmark object.</returns>
        Benchmark Create(string uri);

        /// <summary>
        /// Creates an instance of the <see cref="Benchmark"/> class which when disposed determines how long an action has taken.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>The benchmark object.</returns>
        Benchmark Create(Uri uri);

        #endregion
    }
}