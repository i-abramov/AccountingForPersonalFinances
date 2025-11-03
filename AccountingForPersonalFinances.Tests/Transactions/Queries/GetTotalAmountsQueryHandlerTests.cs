using AccountingForPersonalFinances.Application.Common.Exceptions;
using AccountingForPersonalFinances.Application.Transactions.Queries.GetTotalAmouns;
using AccountingForPersonalFinances.Application.Transactions.Queries.GetTransactionList;
using AccountingForPersonalFinances.Persistence;
using AccountingForPersonalFinances.Tests.Common;
using AutoMapper;
using Shouldly;

namespace AccountingForPersonalFinances.Tests.Transactions.Queries
{
    [Collection("QueryCollection")]
    public class GetTotalAmountsQueryHandlerTests
    {
        private readonly AccountingForPersonalFinancesDbContext Context;
        private readonly IMapper Mapper;

        public GetTotalAmountsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetTotalAmountsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetTotalAmountsQueryHandler(Context, Mapper);
            var transactionMonthNumber = 11;

            // Act
            var result = await handler.Handle(
                new GetTotalAmountsQuery
                {
                    WalletID = AccountingForPersonalFinancesContextFactory.WalletAID,
                    MonthNumber = transactionMonthNumber
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<TotalAmountsVm>();
            result.IncomeAmount.ShouldBe(127650.0m);
            result.ExpenseAmount.ShouldBe(2980.0m);
        }

        [Fact]
        public async Task GetTotalAmountsQueryHandler_FailOnWrongWalletID()
        {
            // Arrange
            var handler = new GetTotalAmountsQueryHandler(Context, Mapper);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new GetTotalAmountsQuery
                    {
                        WalletID = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}