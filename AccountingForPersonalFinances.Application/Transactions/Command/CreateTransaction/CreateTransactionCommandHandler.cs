using AccountingForPersonalFinances.Application.Common.Exceptions;
using AccountingForPersonalFinances.Application.Interfaces;
using AccountingForPersonalFinances.Domain.Models;
using AccountingForPersonalFinances.Domain.Models.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingForPersonalFinances.Application.Transactions.Command.CreateTransaction
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Guid>
    {
        private readonly IAccountingForPersonalFinancesDbContext _dbContext;

        public CreateTransactionCommandHandler(IAccountingForPersonalFinancesDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateTransactionCommand request,
            CancellationToken cancellationToken)
        {
            var wallet = await _dbContext.Wallets.FirstOrDefaultAsync(w => w.ID == request.WalletID, cancellationToken)
                ?? throw new NotFoundException(nameof(Wallet), request.WalletID);

            if (request.Type == TransactionType.Expense && request.CurrentWalletBalance < request.Amount)
            {
                throw new InsufficientFundsException(wallet.Name, request.CurrentWalletBalance, request.Amount);
            }

            var transaction = new Transaction()
            {
                ID = Guid.NewGuid(),
                WalletID = request.WalletID,
                Date = DateTime.Now,
                Amount = request.Amount,
                Type = request.Type,
                Description = request.Description
            };

            await _dbContext.Transactions.AddAsync(transaction, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return transaction.ID;
        }
    }
}