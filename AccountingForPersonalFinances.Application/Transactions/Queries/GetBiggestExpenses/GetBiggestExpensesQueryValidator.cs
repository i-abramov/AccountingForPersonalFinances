using FluentValidation;

namespace AccountingForPersonalFinances.Application.Transactions.Queries.GetBiggestExpenses
{
    public class GetBiggestExpensesQueryValidator : AbstractValidator<GetBiggestExpensesQuery>
    {
        public GetBiggestExpensesQueryValidator()
        {
            RuleFor(transactionList => transactionList.WalletID).NotEqual(Guid.Empty);
            RuleFor(transactionList => transactionList.MonthNumber).Must(mn => mn >= 1 &&  mn <= 12);
        }
    }
}