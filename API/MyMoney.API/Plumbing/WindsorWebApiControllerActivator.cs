namespace MyMoney.API.Plumbing
{
    #region Usings

    using System;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Dispatcher;

    using Castle.Windsor;

    #endregion

    public class WindsorWebApiControllerActivator : IHttpControllerActivator
    {
        #region Fields

        private readonly IWindsorContainer _container;

        #endregion

        #region Constructor

        public WindsorWebApiControllerActivator(IWindsorContainer container)
        {
            _container = container;
        }

        #endregion

        #region  Public Methods

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

        private class Release : IDisposable
        {
            #region Fields

            private readonly Action _release;

            #endregion

            #region Constructor

            public Release(Action release)
            {
                _release = release;
            }

            #endregion

            #region  Public Methods

            public void Dispose()
            {
                _release();
            }

            #endregion
        }
    }
}