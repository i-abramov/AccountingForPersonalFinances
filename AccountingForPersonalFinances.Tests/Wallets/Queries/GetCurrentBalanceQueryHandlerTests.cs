using AccountingForPersonalFinances.Application.Common.Exceptions;
using AccountingForPersonalFinances.Application.Wallets.Queries.GetCurrentBalance;
using AccountingForPersonalFinances.Persistence;
using AccountingForPersonalFinances.Tests.Common;
using AutoMapper;
using Shouldly;

namespace AccountingForPersonalFinances.Tests.Wallets.Queries
{
    [Collection("QueryCollection")]
    public class GetCurrentBalanceQueryHandlerTests
    {
        private readonly AccountingForPersonalFinancesDbContext Context;
        private readonly IMapper Mapper;

        public GetCurrentBalanceQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetCurrentBalanceQueryHandler_Success()
        {
            // Arrange
            var handler = new GetCurrentBalanceQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetCurrentBalanceQuery
                {
                    ID = AccountingForPersonalFinancesContextFactory.WalletBID
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CurrentBalanceVm>();
            result.CurrentBalance.ShouldBe(103465.53m);
        }

        [Fact]
        public async Task GetCurrentBalanceQueryHandler_FailOnWrongWalletID()
        {
            // Arrange
            var handler = new GetCurrentBalanceQueryHandler(Context, Mapper);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new GetCurrentBalanceQuery
                    {
                        ID = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}