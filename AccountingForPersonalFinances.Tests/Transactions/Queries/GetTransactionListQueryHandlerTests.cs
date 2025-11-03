using AccountingForPersonalFinances.Application.Common.Exceptions;
using AccountingForPersonalFinances.Application.Transactions.Queries.GetTransactionList;
using AccountingForPersonalFinances.Persistence;
using AccountingForPersonalFinances.Tests.Common;
using AutoMapper;
using Shouldly;

namespace AccountingForPersonalFinances.Tests.Transactions.Queries
{
    [Collection("QueryCollection")]
    public class GetTransactionListQueryHandlerTests
    {
        private readonly AccountingForPersonalFinancesDbContext Context;
        private readonly IMapper Mapper;

        public GetTransactionListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetTransactionListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetTransactionListQueryHandler(Context, Mapper);
            var transactionMonthNumber = 10;

            // Act
            var result = await handler.Handle(
                new GetTransactionListQuery
                {
                    WalletID = AccountingForPersonalFinancesContextFactory.WalletBID,
                    MonthNumber = transactionMonthNumber
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<TransactionListVm>();
            result.Transactions.Count.ShouldBe(9);
        }

        [Fact]
        public async Task GetTransactionListQueryHandler_FailOnWrongWalletID()
        {
            // Arrange
            var handler = new GetTransactionListQueryHandler(Context, Mapper);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new GetTransactionListQuery
                    {
                        WalletID = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}