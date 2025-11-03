namespace AccountingForPersonalFinances.Application.Transactions.Queries.GetBiggestExpenses
{
    public class BiggestExpensesListVm
    {
        public IList<ExpenseLookupDto> Expenses { get; set; }
    }
}