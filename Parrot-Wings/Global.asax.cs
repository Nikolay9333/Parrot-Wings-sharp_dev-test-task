using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;
using Parrot_Wings.Util;
using NinjectDependencyResolver = Parrot_Wings.Util.NinjectDependencyResolver;

namespace Parrot_Wings
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // RegisterServices(new StandardKernel());
            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

        //private static void RegisterServices(IKernel kernel)
        //{
        //   DependencyResolver.SetResolver(new
        //        NinjectDependencyResolver(kernel));
        //}
    }
}