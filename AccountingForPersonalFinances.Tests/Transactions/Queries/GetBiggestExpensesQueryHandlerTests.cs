using AccountingForPersonalFinances.Application.Common.Exceptions;
using AccountingForPersonalFinances.Application.Transactions.Queries.GetBiggestExpenses;
using AccountingForPersonalFinances.Persistence;
using AccountingForPersonalFinances.Tests.Common;
using AutoMapper;
using Shouldly;

namespace AccountingForPersonalFinances.Tests.Transactions.Queries
{
    [Collection("QueryCollection")]
    public class GetBiggestExpensesQueryHandlerTests
    {
        private readonly AccountingForPersonalFinancesDbContext Context;
        private readonly IMapper Mapper;

        public GetBiggestExpensesQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetBiggestExpensesQueryHandler_Success()
        {
            // Arrange
            var handler = new GetBiggestExpensesQueryHandler(Context, Mapper);
            var transactionMonthNumber = 10;

            // Act
            var result = await handler.Handle(
                new GetBiggestExpensesQuery
                {
                    WalletID = AccountingForPersonalFinancesContextFactory.WalletAID,
                    MonthNumber = transactionMonthNumber
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<BiggestExpensesListVm>();
            result.Expenses.Count.ShouldBe(3);
            result.Expenses.FirstOrDefault(e => e.Amount == 2100.0m).ShouldNotBeNull();
            result.Expenses.FirstOrDefault(e => e.Amount == 1890.5m).ShouldNotBeNull();
            result.Expenses.FirstOrDefault(e => e.Amount == 1800.5m).ShouldNotBeNull();
        }

        [Fact]
        public async Task GetBiggestExpensesQueryHandler_FailOnWrongWalletID()
        {
            // Arrange
            var handler = new GetBiggestExpensesQueryHandler(Context, Mapper);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new GetBiggestExpensesQuery
                    {
                        WalletID = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}