using AccountingForPersonalFinances.Application.Common.Exceptions;
using AccountingForPersonalFinances.Application.Transactions.Command.CreateTransaction;
using AccountingForPersonalFinances.Application.Wallets.Queries.GetCurrentBalance;
using AccountingForPersonalFinances.Presentation.Controllers.Interfaces;
using AccountingForPersonalFinances.Presentation.Views.Intrefaces;
using MediatR;

namespace AccountingForPersonalFinances.Presentation.Presenters
{
    public class MakeTransactionPresenter : BasePresenter<IMakeTransactionView, Guid>
    {
        private readonly IMakeTransactionView _view;
        private readonly IMediator _mediator;
        private Guid _currentWalletID;

        public MakeTransactionPresenter(
            IApplicationController controller,
            IMakeTransactionView view,
            IMediator mediator)
            : base(controller, view)
        {
            _view = view;
            _mediator = mediator;

            _view.SaveTransaction += OnSaveTransaction;
            _view.CancelTransaction += OnCancelTransaction;
        }

        public override void Run(Guid walletID)
        {
            _currentWalletID = walletID;

            _view.Show();
        }

        private async void OnSaveTransaction()
        {
            try
            {
                var currentBalanceQuery = new GetCurrentBalanceQuery()
                {
                    ID = _currentWalletID
                };
                var currentBalanceVm = await _mediator.Send(currentBalanceQuery);

                var transactionCommand = new CreateTransactionCommand()
                {
                    WalletID = _currentWalletID,
                    Amount = _view.Amount,
                    Type = _view.Type,
                    Description = _view.Description,
                    CurrentWalletBalance = currentBalanceVm.CurrentBalance
                };
                await _mediator.Send(transactionCommand);

                _view.CloseForm();
            }
            catch (InsufficientFundsException ex)
            {
                _view.ShowError(ex.Message);
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

        private void OnCancelTransaction()
        {
            _view.Close();
        }
    }
}