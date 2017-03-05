namespace MyMoney.API.Plumbing
{
    #region Usings

    using System;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Dispatcher;

    using Castle.Windsor;

    #endregion

    /// <summary>
    /// The <see cref="WindsorWebApiControllerActivator"/> class installs dependencies for controllers used in the API.
    /// </summary>
    /// <seealso cref="System.Web.Http.Dispatcher.IHttpControllerActivator" />
    public class WindsorWebApiControllerActivator : IHttpControllerActivator
    {
        #region Fields        
        /// <summary>
        /// The container
        /// </summary>
        private readonly IWindsorContainer _container;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="WindsorWebApiControllerActivator"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public WindsorWebApiControllerActivator(IWindsorContainer container)
        {
            _container = container;
        }

        #endregion

        #region  Public Methods

        /// <summary>
        /// Creates an <see cref="T:System.Web.Http.Controllers.IHttpController" /> object.
        /// </summary>
        /// <param name="request">The message request.</param>
        /// <param name="controllerDescriptor">The HTTP controller descriptor.</param>
        /// <param name="controllerType">The type of the controller.</param>
        /// <returns>
        /// An <see cref="T:System.Web.Http.Controllers.IHttpController" /> object.
        /// </returns>
        public IHttpController Create(
            HttpRequestMessage request, 
            HttpControllerDescriptor controllerDescriptor, 
            Type controllerType)
        {
            var controller = (IHttpController)_container.Resolve(controllerType);

            request.RegisterForDispose(new Release(() => _container.Release(controller)));

            return controller;
        }

        #endregion

        /// <summary>
        /// The <see cref="Release"/> class releases controllers.
        /// </summary>
        /// <seealso cref="System.IDisposable" />
        private class Release : IDisposable
        {
            #region Fields

            /// <summary>
            /// The release
            /// </summary>
            private readonly Action _release;

            #endregion

            #region Constructor

            /// <summary>
            /// Initializes a new instance of the <see cref="Release"/> class.
            /// </summary>
            /// <param name="release">The release.</param>
            public Release(Action release)
            {
                _release = release;
            }

            #endregion

            #region  Public Methods

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                _release();
            }

            #endregion
        }
    }
}