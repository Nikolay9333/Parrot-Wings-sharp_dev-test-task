[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Parrot_Wings.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Parrot_Wings.App_Start.NinjectWebCommon), "Stop")]

namespace Parrot_Wings.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using ParrotWings.Contexts;
    using ParrotWings.Interfaces;
    using ParrotWings.Repositories;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            kernel.Bind<IDbRepository>().To<MsSqlRepository>();
            kernel.Bind<DbContext>().To<PwContext>();
            kernel.Bind<IConfiguration>().ToConstant(configuration);
        }
    }
}