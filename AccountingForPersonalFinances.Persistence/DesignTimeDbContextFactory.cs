using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AccountingForPersonalFinances.Persistence
{
    public class DesignTimeDbContextFactory
        : IDesignTimeDbContextFactory<AccountingForPersonalFinancesDbContext>
    {
        public AccountingForPersonalFinancesDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AccountingForPersonalFinancesDbContext>();
            optionsBuilder.UseSqlite(connectionString);

            return new AccountingForPersonalFinancesDbContext(optionsBuilder.Options);
        }
    }
}