namespace MyMoney.Web
{
    #region Usings

    using System.Web.Mvc;

    #endregion

    /// <summary>
    ///     Contains filter information for web application controllers.
    /// </summary>
    public class FilterConfig
    {
        #region  Public Methods

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