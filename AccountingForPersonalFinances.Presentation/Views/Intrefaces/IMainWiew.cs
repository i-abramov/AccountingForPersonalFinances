using AccountingForPersonalFinances.Application.Transactions.Queries.GetBiggestExpenses;
using AccountingForPersonalFinances.Application.Transactions.Queries.GetTotalAmouns;
using AccountingForPersonalFinances.Application.Transactions.Queries.GetTransactionList;
using AccountingForPersonalFinances.Application.Wallets.Queries.GetWalletList;

namespace AccountingForPersonalFinances.Presentation.Views.Intrefaces
{
    public interface IMainView : IView
    {
        WalletLookupDto CurrentWallet { get; }
        int SelectedMonthNumber { get; }

        event Action MainFormLoad;
        event Action MakeTransaction;
        event Action SelectWallet;
        event Action SelectMonth;

        void ShowError(string errorMessage);
        void SetWallets(WalletListVm Wallets);
        void SetBalance(string balance);
        void SetMonth(int monthNumber);
        void SetTransactions(TransactionListVm transactionListVm);
        void SetBiggestExpenses(BiggestExpensesListVm biggestExpensesListVm);
        void SetTotalAmount(TotalAmountsVm totalAmountVm);
    }
}