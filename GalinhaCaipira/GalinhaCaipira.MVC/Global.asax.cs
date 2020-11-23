using Castle.Windsor;
using Castle.Windsor.Installer;
using GalinhaCaipira.MVC.Infrastructure.ErrorHandlers;
using GalinhaCaipira.MVC.Plumbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GalinhaCaipira.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        private static void BootStrapContainer()
        {
            container = new WindsorContainer().Install(FromAssembly.This());
            
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalFilters.Filters.Add(new CustomErrorAttribute());
            BootStrapContainer();
        }

        protected void Application_End()
        {
            container.Dispose();
        }
    }
}
