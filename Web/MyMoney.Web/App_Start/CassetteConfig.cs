namespace MyMoney.Web
{
    #region Usings

    using Cassette;
    using Cassette.Scripts;
    using Cassette.Stylesheets;

    #endregion

    /// <summary>
    ///     Configures the Cassette asset bundles for the web application.
    /// </summary>
    public class CassetteConfig : IConfiguration<BundleCollection>
    {
        #region Methods

        /// <summary>
        ///     Configures the specified bundles.
        /// </summary>
        /// <param name="bundles">The bundles.</param>
        public void Configure(BundleCollection bundles)
        {
            bundles.AddPerIndividualFile<ScriptBundle>("Scripts");
            bundles.AddPerIndividualFile<ScriptBundle>("Areas");

            bundles.AddPerIndividualFile<StylesheetBundle>("Content");
            bundles.AddPerIndividualFile<StylesheetBundle>("Areas");
        }

        #endregion
    }
}