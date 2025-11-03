using AccountingForPersonalFinances.Application.Common.Exceptions;
using AccountingForPersonalFinances.Application.Interfaces;
using AccountingForPersonalFinances.Application.Transactions.Queries.GetBiggestExpenses;
using AccountingForPersonalFinances.Application.Transactions.Queries.GetTotalAmouns;
using AccountingForPersonalFinances.Application.Transactions.Queries.GetTransactionList;
using AccountingForPersonalFinances.Application.Wallets.Queries.GetCurrentBalance;
using AccountingForPersonalFinances.Application.Wallets.Queries.GetWalletList;
using AccountingForPersonalFinances.Domain.Models.Dictionaries;
using MediatR;

namespace AccountingForPersonalFinances.Application.Presenters
{
    public class MainPresenter : BasePresenter<IMainView>
    {
        private readonly IMainView _view;
        private readonly IMediator _mediator;

        public MainPresenter(IApplicationController controller,
                             IMainView view,
                             IMediator mediator)
            : base(controller, view)
        {
            _view = view;
            _mediator = mediator;

            _view.MainFormLoad += FillFormData;
            _view.MakeTransaction += MakeTransaction;
            _view.SelectWallet += SelectWallet;
            _view.SelectMonth += SelectMonth;
        }

        public void Run()
        {
            _view.Show();
        }

        public async void FillFormData()
        {
            try
            {
                var query = new GetWalletListQuery();
                var vm = await _mediator.Send(query);
                _view.SetWallets(vm);

                _view.SetMonth(DateTime.Now.Month);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Непредвиденная ошибка: {ex.Message}");
            }
        }

        public void MakeTransaction()
        {
            if (_view.CurrentWallet == null)
                return;

            var makeTransactionPresenter = Controller.Resolve<MakeTransactionPresenter>();

            makeTransactionPresenter.ViewInstance.TransactionCompleted += () =>
            {
                UpdateCurrentBalance();
                SetTransactions();
            };

            makeTransactionPresenter.Run(_view.CurrentWallet.ID);
        }

        public void SelectWallet()
        {
            UpdateCurrentBalance();
            SetTransactions();
        }

        public void SelectMonth()
        {
            SetTransactions();
        }

        private async void UpdateCurrentBalance()
        {
            try
            {
                var currentBalanceQuery = new GetCurrentBalanceQuery()
                {
                    ID = _view.CurrentWallet.ID
                };
                var currentBalanceVm = await _mediator.Send(currentBalanceQuery);
                _view.SetBalance($"{currentBalanceVm.CurrentBalance} {CurrencyDictionary.All[_view.CurrentWallet.Сurrency]}");
            }
            catch (NotFoundException ex)
            {
                _view.ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Непредвиденная ошибка: {ex.Message}");
            }
        }

        private async void SetTransactions()
        {
            try
            {
                var transactionQuery = new GetTransactionListQuery()
                {
                    WalletID = _view.CurrentWallet.ID,
                    MonthNumber = _view.SelectedMonthNumber
                };
                var transactionVm = await _mediator.Send(transactionQuery);
                _view.SetTransactions(transactionVm);

                var expensesQuery = new GetBiggestExpensesQuery()
                {
                    WalletID = _view.CurrentWallet.ID,
                    MonthNumber = _view.SelectedMonthNumber
                };
                var expensesVm = await _mediator.Send(expensesQuery);
                _view.SetBiggestExpenses(expensesVm);

                var totalAmountQuery = new GetTotalAmountsQuery()
                {
                    WalletID = _view.CurrentWallet.ID,
                    MonthNumber = _view.SelectedMonthNumber
                };
                var totalAmountVm = await _mediator.Send(totalAmountQuery);
                _view.SetTotalAmount(totalAmountVm);
            }
            catch (NotFoundException ex)
            {
                _view.ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Непредвиденная ошибка: {ex.Message}");
            }
        }
    }
}