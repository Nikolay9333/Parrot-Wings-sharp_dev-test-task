using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.Configuration;
using ParrotWings.Entities;

namespace ParrotWings.Contexts
{
    public class PwContext : IdentityDbContext<User>
    {
        #region Properties

        public DbSet<MoneyTransfer> MoneyTransfers { get; set; }

        #endregion

        #region Constructors

        public PwContext(IConfiguration config) : base(config.GetConnectionString("DbConnection"))
        {
        }

        #endregion

        #region Public Static Methods

        public static PwContext Create()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            return new PwContext(configuration);
        }

        public static void GetMostPopularTransactions()
        {
            var sql = "SELECT * FROM moneyTransfer AS mt " +
                      "";
        }

        #endregion
    }
}