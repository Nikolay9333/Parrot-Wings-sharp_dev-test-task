using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Microsoft.Extensions.Configuration;
using ParrotWings.Entities;

namespace ParrotWings.Contexts
{
    //добавить DI
    public class PwContext : DbContext
    {
        #region Fields

        private static readonly string ConnectionString;

        #endregion

        #region Properties

        public DbSet<User> Users { get; set; }
        public DbSet<MoneyTransfer> MoneyTransfers { get; set; }

        #endregion

        #region Constructors

        //static PwContext()
        //{
        //    ConnectionString = new ConfigurationBuilder()
        //        .AddJsonFile("appsettings.json").Build()
        //        .GetConnectionString("DbConnection");
        //}

        public PwContext(/*IConfiguration config = null*/) : base(/*config?.GetConnectionString*/("DbConnection"))
        {
            //var q = config.GetConnectionString("DbConnection");
        }

        #endregion
    }
}