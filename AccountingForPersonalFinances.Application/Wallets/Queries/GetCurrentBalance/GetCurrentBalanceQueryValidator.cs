using FluentValidation;

namespace AccountingForPersonalFinances.Application.Wallets.Queries.GetCurrentBalance
{
    public class GetCurrentBalanceQueryValidator : AbstractValidator<GetCurrentBalanceQuery>
    {
        public GetCurrentBalanceQueryValidator()
        {
            RuleFor(transactionList => transactionList.ID).NotEqual(Guid.Empty);
        }
    }
}