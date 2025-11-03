using AccountingForPersonalFinances.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountingForPersonalFinances.Application.Interfaces
{
    public interface IAccountingForPersonalFinancesDbContext
    {
        DbSet<Wallet> Wallets { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}