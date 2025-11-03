using AccountingForPersonalFinances.Application.Common.Exceptions;
using AccountingForPersonalFinances.Application.Interfaces;
using AccountingForPersonalFinances.Domain.Models;
using AccountingForPersonalFinances.Domain.Models.Enums;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingForPersonalFinances.Application.Transactions.Queries.GetBiggestExpenses
{
    public class GetBiggestExpensesQueryHandler : IRequestHandler<GetBiggestExpensesQuery, BiggestExpensesListVm>
    {
        private readonly IAccountingForPersonalFinancesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBiggestExpensesQueryHandler(IAccountingForPersonalFinancesDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<BiggestExpensesListVm> Handle(GetBiggestExpensesQuery request, CancellationToken cancellationToken)
        {
            var wallet = await _dbContext.Wallets.FirstOrDefaultAsync(w => w.ID == request.WalletID)
                ?? throw new NotFoundException(nameof(Wallet), request.WalletID);

            var expensesQuery = await _dbContext.Transactions
                .Where(t => t.WalletID == request.WalletID &&
                       t.Type == TransactionType.Expense &&
                       t.Date.Month == request.MonthNumber)
                .OrderByDescending(t => (double)t.Amount)
                .Take(3)
                .ProjectTo<ExpenseLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new BiggestExpensesListVm { Expenses = expensesQuery };
        }
    }
}