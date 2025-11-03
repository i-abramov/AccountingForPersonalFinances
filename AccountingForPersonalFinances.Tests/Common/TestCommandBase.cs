using AccountingForPersonalFinances.Persistence;

namespace AccountingForPersonalFinances.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly AccountingForPersonalFinancesDbContext Context;

        protected TestCommandBase()
        {
            Context = AccountingForPersonalFinancesContextFactory.Create();
        }

        public void Dispose()
        {
            AccountingForPersonalFinancesContextFactory.Destroy(Context);
        }
    }
}