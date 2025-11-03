using AccountingForPersonalFinances.Application.Common.Exceptions;
using AccountingForPersonalFinances.Application.Interfaces;
using AccountingForPersonalFinances.Domain.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingForPersonalFinances.Application.Transactions.Queries.GetTransactionList
{
    public class GetTransactionListQueryHandler : IRequestHandler<GetTransactionListQuery, TransactionListVm>
    {
        private readonly IAccountingForPersonalFinancesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTransactionListQueryHandler(IAccountingForPersonalFinancesDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TransactionListVm> Handle(GetTransactionListQuery request, CancellationToken cancellationToken)
        {
            var wallet = await _dbContext.Wallets.FirstOrDefaultAsync(w => w.ID == request.WalletID, cancellationToken)
                ?? throw new NotFoundException(nameof(Wallet), request.WalletID);

            var transactions = await _dbContext.Transactions
                .Where(t => t.Date.Month == request.MonthNumber && t.WalletID == request.WalletID)
                .ProjectTo<TransactionLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (transactions.Count == 0)
            {
                return new TransactionListVm { Transactions = new List<TransactionLookupDto>() };
            }   

            var orderedTransactions = transactions
                .GroupBy(t => t.Type)
                .Select(g => new
                {
                    Type = g.Key,
                    Total = g.Sum(t => t.Amount),
                    Transactions = g.OrderBy(t => t.Date).ToList()
                })
                .OrderByDescending(g => g.Total)
                .SelectMany(g => g.Transactions)
                .ToList();

            return new TransactionListVm { Transactions = orderedTransactions };
        }
    }
}