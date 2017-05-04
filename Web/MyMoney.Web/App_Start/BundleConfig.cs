namespace MyMoney.Web
{
    #region Usings

    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Web.Routing;

    using Cassette;
    using Cassette.Scripts;
    using Cassette.Stylesheets;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     Configures the Cassette asset bundles for the web application.
    /// </summary>
    [UsedImplicitly]
    public class BundleConfig : IConfiguration<BundleCollection>
    {
        #region Methods

        /// <summary>
        ///     Configures the specified bundles.
        /// </summary>
        /// <param name="bundles">The bundles.</param>
        public void Configure(BundleCollection bundles) 
        {
            CreateAreaBundles(bundles);

            bundles.AddPerSubDirectory<ScriptBundle>("Scripts");
            bundles.AddPerSubDirectory<StylesheetBundle>("Content");
        }

        /// <summary>
        /// Creates a script and style sheet bundle for each area in the solution. The
        /// directory structure should follow ~/Areas/{Area}/{Scripts|Content}
        /// </summary>
        /// <param name="bundles">The bundle collection.</param>
        private static void CreateAreaBundles(BundleCollection bundles)
        {
            var areaNames = RouteTable.Routes.OfType<Route>()
                .Where(d => d.DataTokens != null && d.DataTokens.ContainsKey("area"))
                .Select(r => r.DataTokens["area"]).Distinct();

            foreach (var area in areaNames)
            {
                try
                {
                    bundles.AddPerSubDirectory<StylesheetBundle>($"~/Areas/{area}/Content");
                }
                catch (DirectoryNotFoundException ex)
                {
                    if (Debugger.IsAttached)
                    {
                        Trace.WriteLine($"Missing bundle asset folder: {ex.Message}");
                    }
                }

                try
                {
                    bundles.AddPerSubDirectory<ScriptBundle>($"~/Areas/{area}/Scripts");
                }
                catch (DirectoryNotFoundException ex)
                {
                    if (Debugger.IsAttached)
                    {
                        Trace.WriteLine($"Missing bundle asset folder: {ex.Message}");
                    }
                }
            }
        }


        #endregion
    }
}