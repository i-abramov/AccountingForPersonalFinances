using AccountingForPersonalFinances.Domain.Models.Enums;
using MediatR;

namespace AccountingForPersonalFinances.Application.Transactions.Command.CreateTransaction
{
    public class CreateTransactionCommand : IRequest<Guid>
    {
        public Guid WalletID { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public string Description { get; set; }
        public decimal CurrentWalletBalance { get; set; }
    }
}