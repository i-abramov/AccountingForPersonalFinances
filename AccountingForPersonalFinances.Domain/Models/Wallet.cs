namespace AccountingForPersonalFinances.Domain.Models
{
    public class Wallet
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Сurrency { get; set; }
        public decimal InitialBalance { get; set; }

        public List<Transaction> Transactions { get; set; } = new();
    }
}