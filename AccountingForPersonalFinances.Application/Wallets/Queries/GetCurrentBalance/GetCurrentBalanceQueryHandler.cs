using AccountingForPersonalFinances.Application.Common.Exceptions;
using AccountingForPersonalFinances.Application.Interfaces;
using AccountingForPersonalFinances.Domain.Models;
using AccountingForPersonalFinances.Domain.Models.Enums;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingForPersonalFinances.Application.Wallets.Queries.GetCurrentBalance
{
    public class GetCurrentBalanceQueryHandler : IRequestHandler<GetCurrentBalanceQuery, CurrentBalanceVm>
    {
        private readonly IAccountingForPersonalFinancesDbContext _dbContext;

        public GetCurrentBalanceQueryHandler(IAccountingForPersonalFinancesDbContext dbContext, IMapper mapper) =>
            _dbContext = dbContext;

        public async Task<CurrentBalanceVm> Handle(GetCurrentBalanceQuery request, CancellationToken cancellationToken)
        {
            var wallet = await _dbContext.Wallets.FirstOrDefaultAsync(w => w.ID == request.ID, cancellationToken)
                ?? throw new NotFoundException(nameof(Wallet), request.ID);

            decimal currentBalance = await _dbContext.Transactions
                .Where(t => t.WalletID == request.ID)
                .SumAsync(t => t.Type == TransactionType.Income ? t.Amount : -t.Amount, cancellationToken);

            return new CurrentBalanceVm { CurrentBalance = currentBalance, WalletID = request.ID };
        }
    }
}