﻿namespace MyMoney.Helpers.Benchmarking
{
    #region Usings

    using System;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     The <see cref="BenchmarkHelper" /> class is used to create instances of the <see cref="Benchmark" /> class. These
    ///     are used to time events in-code. This should be wrapped around
    ///     the method you are using in a using statement.
    /// </summary>
    /// <example>
    ///     using (BenchmarkHelper.Create(uri))
    ///     {
    ///     httpResponse = await Client.DeleteAsync(uri);
    ///     }
    /// </example>
    [UsedImplicitly]
    public class BenchmarkHelper : IBenchmarkHelper
    {
        #region Methods

        /// <summary>
        ///     Creates an instance of the <see cref="Benchmark" /> class and starts its timer.
        /// </summary>
        /// <param name="uri">The request URI.</param>
        /// <returns>The benchmarking object. Once disposed, the metrics will be written to the log.</returns>
        public Benchmark Create(string uri)
        {
            return new Benchmark(uri);
        }

        /// <summary>
        ///     Creates an instance of the <see cref="Benchmark" /> class and starts its timer.
        /// </summary>
        /// <param name="uri">The request URI.</param>
        /// <returns>The benchmarking object. Once disposed, the metrics will be written to the log.</returns>
        public Benchmark Create(Uri uri)
        {
            return Create(uri.AbsoluteUri);
        }

        #endregion
    }
}