using FluentValidation;

namespace AccountingForPersonalFinances.Application.Transactions.Queries.GetTotalAmouns
{
    public class GetTotalAmountsQueryValidator : AbstractValidator<GetTotalAmountsQuery>
    {
        public GetTotalAmountsQueryValidator()
        {
            RuleFor(totalAmounts => totalAmounts.WalletID).NotEqual(Guid.Empty);
            RuleFor(totalAmounts => totalAmounts.MonthNumber).Must(mn => mn >= 1 && mn <= 12);
        }
    }
}