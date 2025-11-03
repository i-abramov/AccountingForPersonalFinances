using AccountingForPersonalFinances.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AccountingForPersonalFinances.Application.Controllers
{
    public class ApplicationController : IApplicationController
    {
        private readonly IServiceCollection _services;
        private IServiceProvider _provider;

        public ApplicationController(IServiceCollection services)
        {
            _services = services;
        }

        public IApplicationController Build()
        {
            _services.AddSingleton<IApplicationController>(this);

            _provider = _services.BuildServiceProvider();
            return this;
        }

        public IApplicationController RegisterView<TView, TImplementation>()
            where TImplementation : class, TView
            where TView : class
        {
            _services.AddTransient<TView, TImplementation>();
            return this;
        }

        public IApplicationController RegisterService<TService, TImplementation>()
            where TImplementation : class, TService
            where TService : class
        {
            _services.AddTransient<TService, TImplementation>();
            return this;
        }

        public IApplicationController RegisterInstance<TService>(TService instance)
            where TService : class
        {
            _services.AddSingleton(instance);
            return this;
        }

        public TService Resolve<TService>() where TService : class
        {
            return _provider.GetRequiredService<TService>();
        }

        public void Run<TPresenter>() where TPresenter : class, IPresenter
        {
            var presenter = Resolve<TPresenter>();
            presenter.Run();
        }

        public void Run<TPresenter, TArg>(TArg argument)
            where TPresenter : class, IPresenter<TArg>
        {
            var presenter = Resolve<TPresenter>();
            presenter.Run(argument);
        }
    }
}