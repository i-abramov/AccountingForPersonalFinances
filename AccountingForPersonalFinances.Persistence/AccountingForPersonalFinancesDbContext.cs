using AccountingForPersonalFinances.Application.Interfaces;
using AccountingForPersonalFinances.Domain.Models;
using AccountingForPersonalFinances.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace AccountingForPersonalFinances.Persistence
{
    public class AccountingForPersonalFinancesDbContext : DbContext, IAccountingForPersonalFinancesDbContext
    {
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public AccountingForPersonalFinancesDbContext(DbContextOptions<AccountingForPersonalFinancesDbContext> options)
            : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new WalletConfiguration());
            builder.ApplyConfiguration(new TransactionConfiguration());
            base.OnModelCreating(builder);
        }
    }
}