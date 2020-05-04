using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SpringMVC2.Controllers
{
    public class SpringControllerFactory : DefaultControllerFactory
    {
        // GET: Spring
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            IController controller = null;
            string controllerClassName = string.Format("{0}Controller", controllerName);
            if (SpringApplication.Contains(controllerClassName))
            {
                controller = SpringApplication.Resolve<IController>(controllerClassName);
                //this.RequestController = requestContext;
            }
            else
            {
                controller = base.CreateController(requestContext, controllerName);
            }
            return controller;
        }
        /// <summary>
        /// Releases the controller.
        /// </summary>
        /// <param name="controller">Accepts an <see cref="IController"/></param>
        public override void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}