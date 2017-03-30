namespace MyMoney.Web
{
    #region Usings

    using JetBrains.Annotations;

    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;

    using Owin;

    #endregion

    /// <summary>
    ///     The start up class for the web application.
    /// </summary>
    public class Startup
    {
        #region Methods

        /// <summary>
        ///     Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        [UsedImplicitly]
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions
                    {
                        AuthenticationType = "ApplicationCookie",
                        LoginPath = new PathString("/auth/user/login")
                    });
        }

        #endregion
    }
}