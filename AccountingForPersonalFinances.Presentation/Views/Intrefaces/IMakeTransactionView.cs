using AccountingForPersonalFinances.Domain.Models.Enums;

namespace AccountingForPersonalFinances.Presentation.Views.Intrefaces
{
    public interface IMakeTransactionView : IView
    {
        decimal Amount { get; }
        TransactionType Type { get; }
        string Description { get; }

        event Action SaveTransaction;
        event Action TransactionCompleted;
        event Action CancelTransaction;

        void CloseForm();
        void ShowError(string errorMessage);
    }
}