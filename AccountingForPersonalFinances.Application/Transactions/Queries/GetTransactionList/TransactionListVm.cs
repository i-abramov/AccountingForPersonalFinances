namespace AccountingForPersonalFinances.Application.Transactions.Queries.GetTransactionList
{
    public class TransactionListVm
    {
        public IList<TransactionLookupDto> Transactions { get; set; }
    }
}