using MediatR;

namespace AccountingForPersonalFinances.Application.Transactions.Queries.GetBiggestExpenses
{
    public class GetBiggestExpensesQuery : IRequest<BiggestExpensesListVm>
    {
        public Guid WalletID { get; set; }
        public int MonthNumber { get; set; }
    }
}