using AccountingForPersonalFinances.Application;
using AccountingForPersonalFinances.Application.Common.Mappings;
using AccountingForPersonalFinances.Application.Controllers;
using AccountingForPersonalFinances.Application.Interfaces;
using AccountingForPersonalFinances.Application.Presenters;
using AccountingForPersonalFinances.Persistence;
using AccountingForPersonalFinances.Presentation.Views;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AccountingForPersonalFinances.Presentation
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                cfg.AddProfile(new AssemblyMappingProfile(typeof(IAccountingForPersonalFinancesDbContext).Assembly));
            });

            mapperConfig.AssertConfigurationIsValid();
            var mapper = mapperConfig.CreateMapper();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var services = new ServiceCollection()
                .AddApplication()
                .AddPersistence(connectionString)
                .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            var controller = new ApplicationController(services)
                .RegisterInstance(mapper)
                .RegisterView<IMainView, MainForm>()
                .RegisterView<IMakeTransactionView, MakeTransactionForm>()
                .RegisterService<MainPresenter, MainPresenter>()
                .RegisterService<MakeTransactionPresenter, MakeTransactionPresenter>()
                .Build();

            using (var scope = controller.Resolve<IServiceProvider>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AccountingForPersonalFinancesDbContext>();
                context.Database.Migrate();
                DbInitializer.Initialize(context);
            }

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            controller.Run<MainPresenter>();
        }
    }
}