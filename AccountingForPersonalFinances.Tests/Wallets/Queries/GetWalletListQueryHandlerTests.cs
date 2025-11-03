using AccountingForPersonalFinances.Application.Wallets.Queries.GetWalletList;
using AccountingForPersonalFinances.Persistence;
using AccountingForPersonalFinances.Tests.Common;
using AutoMapper;
using Shouldly;

namespace AccountingForPersonalFinances.Tests.Wallets.Queries
{
    [Collection("QueryCollection")]
    public class GetWalletListQueryHandlerTests
    {
        private readonly AccountingForPersonalFinancesDbContext Context;
        private readonly IMapper Mapper;

        public GetWalletListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetWalletListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetWalletListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetWalletListQuery(),
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<WalletListVm>();
            result.Wallets.Count.ShouldBe(2);
        }
    }
}