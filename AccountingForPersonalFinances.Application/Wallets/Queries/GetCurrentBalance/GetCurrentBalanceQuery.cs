using MediatR;

namespace AccountingForPersonalFinances.Application.Wallets.Queries.GetCurrentBalance
{
    public class GetCurrentBalanceQuery : IRequest<CurrentBalanceVm>
    {
        public Guid ID { get; set; }
    }
}