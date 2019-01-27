using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Extensions.Configuration;
using Ninject;
using ParrotWings.Contexts;
using ParrotWings.Interfaces;
using ParrotWings.Repositories;

namespace Parrot_Wings.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            var a = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

                //kernel.Bind<IConfiguration>().ToConstant(a);
           // kernel.Bind<DbContext>().To<PwContext>();
            //kernel.Bind<IDbRepository>().To<MsSqlRepository>();
            kernel.Bind<IEnumerable<int>>().To<List<int>>();
        }
    }
}