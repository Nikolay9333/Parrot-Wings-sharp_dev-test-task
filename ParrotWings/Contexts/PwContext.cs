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

        public DbSet<Entities.User> Users { get; set; }
        public DbSet<Entities.MoneyTransfer> MoneyTransfers { get; set; }

        #endregion

        #region Constructors

        static PwContext()
        {
            ConnectionString = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build()
                .GetConnectionString("DbConnection");
        }

        public PwContext() : base(ConnectionString)
        {

        }

        #endregion
    }
}