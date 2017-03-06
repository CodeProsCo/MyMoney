namespace MyMoney.Web
{
    #region Usings

    using Cassette;
    using Cassette.Scripts;
    using Cassette.Stylesheets;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     Configures the Cassette asset bundles for the web application.
    /// </summary>
    [UsedImplicitly]
    public class CassetteBundleConfiguration : IConfiguration<BundleCollection>
    {
        #region  Public Methods

        /// <summary>
        ///     Configures the specified bundles.
        /// </summary>
        /// <param name="bundles">The bundles.</param>
        public void Configure(BundleCollection bundles)
        {
            bundles.AddPerIndividualFile<StylesheetBundle>("Content");
            bundles.AddPerIndividualFile<ScriptBundle>("Scripts");
        }

        #endregion
    }
}