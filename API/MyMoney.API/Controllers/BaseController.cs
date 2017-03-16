using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMoney.API.Controllers
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Routing;

    using Helpers.Benchmarking;

    /// <summary>
    /// The <see cref="BaseController"/> is the base controller class for all controllers in the API.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class BaseController : ApiController
    {
        #region Overrides of ApiController

        /// <summary>Executes asynchronously a single HTTP operation.</summary>
        /// <returns>The newly started task.</returns>
        /// <param name="controllerContext">The controller context for a single HTTP operation.</param>
        /// <param name="cancellationToken">The cancellation token assigned for the HTTP operation.</param>
        public override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            using (BenchmarkHelper.Create(controllerContext.Request.RequestUri))
            {
                return base.ExecuteAsync(controllerContext, cancellationToken);
            }
        }

        #endregion
    }
}