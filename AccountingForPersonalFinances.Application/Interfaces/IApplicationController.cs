namespace AccountingForPersonalFinances.Application.Interfaces
{
    public interface IApplicationController
    {
        IApplicationController RegisterView<TView, TImplementation>()
            where TImplementation : class, TView
            where TView : class;

        IApplicationController RegisterService<TService, TImplementation>()
            where TImplementation : class, TService
            where TService : class;

        IApplicationController RegisterInstance<TService>(TService instance)
            where TService : class;

        IApplicationController Build();

        TService Resolve<TService>() where TService : class;

        void Run<TPresenter>() where TPresenter : class, IPresenter;
        void Run<TPresenter, TArg>(TArg argument) where TPresenter : class, IPresenter<TArg>;
    }

}