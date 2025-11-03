using FluentValidation;

namespace AccountingForPersonalFinances.Application.Transactions.Queries.GetTransactionList
{
    public class GetTransactionListQueryValidator : AbstractValidator<GetTransactionListQuery>
    {
        public GetTransactionListQueryValidator()
        {
            RuleFor(transactionList => transactionList.WalletID).NotEqual(Guid.Empty);
            RuleFor(transactionList => transactionList.MonthNumber).Must(mn => mn >= 1 && mn <= 12);
        }
    }
}