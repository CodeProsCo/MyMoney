#region Usings

using MyMoney.API;

using WebActivatorEx;

#endregion

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace MyMoney.API
{
    #region Usings

    using System;
    using System.IO;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;

    using JetBrains.Annotations;

    using Swashbuckle.Application;

    #endregion

    /// <summary>
    ///     The configuration class for Swagger.
    /// </summary>
    public class SwaggerConfig
    {
        #region  Public Methods

        /// <summary>
        ///     Registers this instance.
        /// </summary>
        [UsedImplicitly]
        public static void Register()
        {
            GlobalConfiguration.Configuration.EnableSwagger(
                c =>
                    {
                        c.SingleApiVersion("v1", "MyMoney.API");

                        c.PrettyPrint();

                        c.RootUrl(req =>
                                req.RequestUri.GetLeftPart(UriPartial.Authority) +
                                req.GetRequestContext().VirtualPathRoot.TrimEnd('/'));

                        var doc = Path.Combine(HttpRuntime.AppDomainAppPath, "docs.xml");

                        c.IncludeXmlComments(doc);
                    }).EnableSwaggerUi();
        }

        #endregion
    }
}