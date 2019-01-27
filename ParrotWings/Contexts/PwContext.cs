using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Microsoft.Extensions.Configuration;
using ParrotWings.Entities;

namespace ParrotWings.Contexts
{
    public class PwContext : DbContext
    {
        #region Properties

        public DbSet<User> Users { get; set; }
        public DbSet<MoneyTransfer> MoneyTransfers { get; set; }

        #endregion

        #region Constructors

        public PwContext(IConfiguration config) : base(config?.GetConnectionString("DbConnection"))
        {
        }

        #endregion
    }
}