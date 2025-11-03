using AccountingForPersonalFinances.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountingForPersonalFinances.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AccountingForPersonalFinancesDbContext>(options =>
                options.UseSqlite(connectionString));

            services.AddScoped<IAccountingForPersonalFinancesDbContext>(provider =>
                provider.GetRequiredService<AccountingForPersonalFinancesDbContext>());

            return services;
        }
    }
}