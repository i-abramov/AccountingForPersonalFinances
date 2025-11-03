namespace AccountingForPersonalFinances.Application.Wallets.Queries.GetCurrentBalance
{
    public class CurrentBalanceVm
    {
        public Guid WalletID { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}