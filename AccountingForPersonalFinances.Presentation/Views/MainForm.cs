using AccountingForPersonalFinances.Application.Transactions.Queries.GetBiggestExpenses;
using AccountingForPersonalFinances.Application.Transactions.Queries.GetTotalAmouns;
using AccountingForPersonalFinances.Application.Transactions.Queries.GetTransactionList;
using AccountingForPersonalFinances.Application.Wallets.Queries.GetWalletList;
using AccountingForPersonalFinances.Domain.Models.Dictionaries;
using AccountingForPersonalFinances.Presentation.Views.Intrefaces;

namespace AccountingForPersonalFinances.Presentation
{
    public partial class MainForm : Form, IMainView
    {
        public WalletLookupDto CurrentWallet { get { return (WalletLookupDto)walletsComboBox.SelectedItem; } }
        public int SelectedMonthNumber { get { return monthsComboBox.SelectedIndex + 1; } }

        public event Action MainFormLoad;
        public event Action MakeTransaction;
        public event Action SelectWallet;
        public event Action SelectMonth;

        public MainForm()
        {
            InitializeComponent();

            this.Load += (sender, args) => Invoke(MainFormLoad);
            makeTransactionButton.Click += (sender, args) => Invoke(MakeTransaction);
            walletsComboBox.SelectedIndexChanged += (sender, args) => Invoke(SelectWallet);
            monthsComboBox.SelectedIndexChanged += (sender, args) => Invoke(SelectMonth);
        }

        public new void Show()
        {
            System.Windows.Forms.Application.Run(this);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Invoke(Action action)
        {
            if (action != null)
            {
                action();
            }
        }

        public void SetWallets(WalletListVm walletsVm)
        {
            if (walletsComboBox.Items.Count > 0)
            {
                walletsComboBox.Items.Clear();
            }

            walletsComboBox.DataSource = walletsVm.Wallets;
            walletsComboBox.DisplayMember = "Name";

            walletsComboBox.SelectedIndex = 0;
        }

        public void SetBalance(string balance)
        {
            balanceLabel.Text = balance;
        }

        public void SetMonth(int monthNumber)
        {
            monthsComboBox.SelectedIndex = monthNumber - 1;
        }

        public void SetTransactions(TransactionListVm transactionListVm)
        {
            transactionsDataGridView.DataSource = transactionListVm.Transactions;
            transactionsDataGridView.Columns["ID"].Visible = false;
        }

        public void SetBiggestExpenses(BiggestExpensesListVm biggestExpensesListVm)
        {
            biggestExpensesDataGridView.DataSource = biggestExpensesListVm.Expenses;
            biggestExpensesDataGridView.Columns["ID"].Visible = false;
        }

        public void SetTotalAmount(TotalAmountsVm totalAmountVm)
        {
            totalIncomeLabel.Text = $"Месячный доход: {totalAmountVm.IncomeAmount} {CurrencyDictionary.All[CurrentWallet.Сurrency]}";
            totalExpenseLabel.Text = $"Месячный расход: {totalAmountVm.ExpenseAmount} {CurrencyDictionary.All[CurrentWallet.Сurrency]}";
        }
    }
}