using MediatR;

namespace AccountingForPersonalFinances.Application.Transactions.Queries.GetTotalAmouns
{
    public class GetTotalAmountsQuery : IRequest<TotalAmountsVm>
    {
        public Guid WalletID { get; set; }
        public int MonthNumber { get; set; }
    }
}