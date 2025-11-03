using AccountingForPersonalFinances.Application.Common.Exceptions;
using AccountingForPersonalFinances.Application.Interfaces;
using AccountingForPersonalFinances.Domain.Models;
using AccountingForPersonalFinances.Domain.Models.Enums;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingForPersonalFinances.Application.Transactions.Queries.GetTotalAmouns
{
    public class GetTotalAmountsQueryHandler : IRequestHandler<GetTotalAmountsQuery, TotalAmountsVm>
    {
        private readonly IAccountingForPersonalFinancesDbContext _dbContext;

        public GetTotalAmountsQueryHandler(IAccountingForPersonalFinancesDbContext dbContext, IMapper mapper) =>
            _dbContext = dbContext;

        public async Task<TotalAmountsVm> Handle(GetTotalAmountsQuery request, CancellationToken cancellationToken)
        {
            var wallet = await _dbContext.Wallets.FirstOrDefaultAsync(w => w.ID == request.WalletID)
                ?? throw new NotFoundException(nameof(Wallet), request.WalletID);

            var incomeAmount = _dbContext.Transactions
                .Where(t => t.WalletID == request.WalletID &&
                       t.Type == TransactionType.Income &&
                       t.Date.Month == request.MonthNumber)
                .Sum(t => t.Amount);

            var expenseAmount = _dbContext.Transactions
                .Where(t => t.WalletID == request.WalletID &&
                       t.Type == TransactionType.Expense &&
                       t.Date.Month == request.MonthNumber)
                .Sum(t => t.Amount);

            return new TotalAmountsVm { IncomeAmount = incomeAmount, ExpenseAmount = expenseAmount };
        }
    }
}