using AccountingForPersonalFinances.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountingForPersonalFinances.Domain.Models
{
    public class Transaction
    {
        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public string Description { get; set; }

		public Guid WalletID { get; set; }
		[ForeignKey("WalletID")]
		public Wallet Wallet { get; set; }
	}
}