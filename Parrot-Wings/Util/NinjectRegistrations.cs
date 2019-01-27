using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Configuration;
using Ninject.Modules;
using ParrotWings.Contexts;
using ParrotWings.Interfaces;
using ParrotWings.Repositories;

namespace Parrot_Wings.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            var a = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            Bind<IDbRepository>().To<MsSqlRepository>();
            Bind<DbContext>().To<PwContext>();
            Bind<IConfiguration>().ToConstant(a);
        }
    }
}