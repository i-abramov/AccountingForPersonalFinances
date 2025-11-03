using AccountingForPersonalFinances.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountingForPersonalFinances.Persistence.EntityTypeConfiguration
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.HasKey(wallet => wallet.ID);
            builder.HasIndex(wallet => wallet.ID).IsUnique();
        }
    }
}