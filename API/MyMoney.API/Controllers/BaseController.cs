namespace MyMoney.API.Controllers
{
    #region Usings

    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Controllers;

    using MyMoney.Helpers.Benchmarking;

    #endregion

    /// <summary>
    ///     The <see cref="BaseController" /> is the base controller class for all controllers in the API.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class BaseController : ApiController
    {
        #region Methods

        /// <summary>Executes asynchronously a single HTTP operation.</summary>
        /// <returns>The newly started task.</returns>
        /// <param name="controllerContext">The controller context for a single HTTP operation.</param>
        /// <param name="cancellationToken">The cancellation token assigned for the HTTP operation.</param>
        public override Task<HttpResponseMessage> ExecuteAsync(
            HttpControllerContext controllerContext,
            CancellationToken cancellationToken)
        {
            using (BenchmarkHelper.Create(controllerContext.Request.RequestUri))
            {
                return base.ExecuteAsync(controllerContext, cancellationToken);
            }
        }

        #endregion
    }
}