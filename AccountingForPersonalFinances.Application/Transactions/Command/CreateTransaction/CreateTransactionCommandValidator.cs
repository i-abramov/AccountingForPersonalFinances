using FluentValidation;

namespace AccountingForPersonalFinances.Application.Transactions.Command.CreateTransaction
{
    public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        public CreateTransactionCommandValidator()
        {
            RuleFor(createTransactionCommand => createTransactionCommand.WalletID).NotEqual(Guid.Empty);
            RuleFor(createTransactionCommand => createTransactionCommand.Amount).Must(a => a > 0);
            RuleFor(createTransactionCommand => createTransactionCommand.CurrentWalletBalance).Must(a => a > 0);
        }
    }
}