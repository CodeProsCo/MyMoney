namespace MyMoney.API.Controllers
{
    #region Usings

    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Controllers;

    using Helpers.Benchmarking.Interfaces;

    #endregion

    /// <summary>
    ///     The <see cref="BaseController" /> is the base controller class for all controllers in the API.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class BaseController : ApiController
    {
        #region Fields

        /// <summary>
        ///     The benchmark helper
        /// </summary>
        private readonly IBenchmarkHelper benchmarkHelper;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseController" /> class.
        /// </summary>
        /// <param name="benchmarkHelper">The benchmark helper.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     benchmarkHelper
        ///     Exception thrown if the benchmark helper is null.
        /// </exception>
        public BaseController(IBenchmarkHelper benchmarkHelper)
        {
            if (benchmarkHelper == null)
            {
                throw new ArgumentNullException(nameof(benchmarkHelper));
            }

            this.benchmarkHelper = benchmarkHelper;
        }

        #endregion

        #region Methods

        /// <summary>Executes asynchronously a single HTTP operation.</summary>
        /// <returns>The newly started task.</returns>
        /// <param name="controllerContext">The controller context for a single HTTP operation.</param>
        /// <param name="cancellationToken">The cancellation token assigned for the HTTP operation.</param>
        public override Task<HttpResponseMessage> ExecuteAsync(
            HttpControllerContext controllerContext,
            CancellationToken cancellationToken)
        {
            using (benchmarkHelper.Create(controllerContext.Request.RequestUri))
            {
                return base.ExecuteAsync(controllerContext, cancellationToken);
            }
        }

        #endregion
    }
}