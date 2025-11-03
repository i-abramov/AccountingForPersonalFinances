namespace AccountingForPersonalFinances.Application.Common.Exceptions
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string walletName, decimal currentBalance, decimal attemptedAmount)
            : base($"Недостаточно средств на кошельке \"{walletName}\". " +
                   $"Текущий баланс: {currentBalance}, сумма операции: {attemptedAmount}.")
        { }
    }
}