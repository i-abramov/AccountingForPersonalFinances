using AccountingForPersonalFinances.Application.Common.Mappings;
using AccountingForPersonalFinances.Application.Interfaces;
using AccountingForPersonalFinances.Persistence;
using AutoMapper;

namespace AccountingForPersonalFinances.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public AccountingForPersonalFinancesDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = AccountingForPersonalFinancesContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IAccountingForPersonalFinancesDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            AccountingForPersonalFinancesContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}