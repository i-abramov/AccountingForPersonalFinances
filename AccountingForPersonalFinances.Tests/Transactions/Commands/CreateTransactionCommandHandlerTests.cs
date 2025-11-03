using AccountingForPersonalFinances.Application.Common.Exceptions;
using AccountingForPersonalFinances.Application.Transactions.Command.CreateTransaction;
using AccountingForPersonalFinances.Domain.Models.Enums;
using AccountingForPersonalFinances.Tests.Common;
using Microsoft.EntityFrameworkCore;

namespace AccountingForPersonalFinances.Tests.Transactions.Commands
{
    public class CreateTransactionCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateTransactionCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateTransactionCommandHandler(Context);
            var transactionAmount = 1700.0m;
            var transactionType = TransactionType.Expense;
            var transactionDescription = "Продукты";
            var transactionCurrentWalletBalance = 10000.0m;

            // Act
            var transactionID = await handler.Handle(
                new CreateTransactionCommand
                {
                    WalletID = AccountingForPersonalFinancesContextFactory.WalletAID,
                    Amount = transactionAmount,
                    Type = transactionType,
                    Description = transactionDescription,
                    CurrentWalletBalance = transactionCurrentWalletBalance
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Transactions.SingleOrDefaultAsync(transaction =>
                    transaction.ID == transactionID &&
                    transaction.Amount == transactionAmount &&
                    transaction.Type == transactionType &&
                    transaction.Description == transactionDescription));
        }

        [Fact]
        public async Task CreateTransactionCommandHandler_FailOnWrongWalletID()
        {
            // Arrange
            var handler = new CreateTransactionCommandHandler(Context);
            var transactionAmount = 2476.0m;
            var transactionType = TransactionType.Income;
            var transactionDescription = "Техника";
            var transactionCurrentWalletBalance = 10000.0m;

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new CreateTransactionCommand
                    {
                        WalletID = Guid.NewGuid(),
                        Amount = transactionAmount,
                        Type = transactionType,
                        Description = transactionDescription,
                        CurrentWalletBalance = transactionCurrentWalletBalance
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task CreateTransactionCommandHandler_FailOnInsufficientFunds()
        {
            // Arrange
            var handler = new CreateTransactionCommandHandler(Context);
            var transactionAmount = 1000000.0m;
            var transactionType = TransactionType.Expense;
            var transactionDescription = "Прочие расходы";
            var transactionCurrentWalletBalance = 10000.0m;

            // Act
            // Assert
            await Assert.ThrowsAsync<InsufficientFundsException>(async () =>
                await handler.Handle(
                    new CreateTransactionCommand
                    {
                        WalletID = AccountingForPersonalFinancesContextFactory.WalletAID,
                        Amount = transactionAmount,
                        Type = transactionType,
                        Description = transactionDescription,
                        CurrentWalletBalance = transactionCurrentWalletBalance
                    },
                    CancellationToken.None));
        }
    }
}