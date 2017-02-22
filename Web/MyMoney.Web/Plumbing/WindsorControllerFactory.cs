namespace MyMoney.Web.Plumbing
{
    #region Usings

    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Castle.Windsor;

    #endregion

    public class WindsorControllerFactory : DefaultControllerFactory
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="WindsorControllerFactory" /> class.
        /// </summary>
        /// <param name="container">
        ///     The container.
        /// </param>
        /// The container used to resolve the MVC controllers.
        /// <exception cref="System.ArgumentNullException">
        ///     container
        /// </exception>
        public WindsorControllerFactory(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            Container = container;
        }

        #endregion

        #region  Properties

        /// <summary>
        ///     Gets or sets the container.
        /// </summary>
        private IWindsorContainer Container { get; }

        #endregion

        #region  Public Methods

        /// <summary>
        ///     Releases the specified controller.
        /// </summary>
        /// <param name="controller">The controller to release.</param>
        public override void ReleaseController(IController controller)
        {
            // If controller implements IDisposable, clean it up responsibly
            var disposableController = controller as IDisposable;

            disposableController?.Dispose();

            // Inform Castle that the controller is no longer required
            Container.Release(controller);
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Retrieves the controller instance for the specified request context and controller type.
        /// </summary>
        /// <param name="requestContext">The context of the HTTP request, which includes the HTTP context and route data.</param>
        /// <param name="controllerType">The type of controller</param>
        /// <returns>
        ///     The controller instance.
        /// </returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }

            // Retrieve the requested controller from Castle
            return Container.Resolve(controllerType) as IController;
        }

        #endregion
    }
}