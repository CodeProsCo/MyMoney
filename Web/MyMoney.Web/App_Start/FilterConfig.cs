namespace MyMoney.Web
{
    #region Usings

    using System.Web.Mvc;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     Contains filter information for web application controllers.
    /// </summary>
    [UsedImplicitly]
    public class FilterConfig
    {
        #region Methods

        /// <summary>
        ///     Registers the global filters.
        /// </summary>
        /// <param name="filters">The filters.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthorizeAttribute());
        }

        #endregion
    }
}