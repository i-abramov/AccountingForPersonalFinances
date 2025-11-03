using MediatR;

namespace AccountingForPersonalFinances.Application.Transactions.Queries.GetTransactionList
{
    public class GetTransactionListQuery : IRequest<TransactionListVm>
    {
        public Guid WalletID { get; set; }
        public int MonthNumber { get; set; }
    }
}