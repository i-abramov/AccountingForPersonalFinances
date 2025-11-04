using AccountingForPersonalFinances.Domain.Models.Enums;
using AccountingForPersonalFinances.Presentation.Views.Intrefaces;

namespace AccountingForPersonalFinances.Presentation.Views
{
    public partial class MakeTransactionForm : Form, IMakeTransactionView
    {
        public decimal Amount { get { return amountNumericUpDown.Value; } }
        public TransactionType Type { get { return (TransactionType)typeComboBox.SelectedValue; } }
        public string Description { get { return descriptionTextBox.Text; } }

        public event Action SaveTransaction;
        public event Action CancelTransaction;
        public event Action TransactionCompleted;

        public MakeTransactionForm()
        {
            InitializeComponent();
            LoadTransactionTypes();

            createButton.Click += (sender, args) => Invoke(SaveTransaction);
            cancelButton.Click += (sender, args) => Invoke(CancelTransaction);
        }

        private void LoadTransactionTypes()
        {
            var types = Enum.GetValues(typeof(TransactionType))
                            .Cast<TransactionType>()
                            .Select(x => new { Text = x.ToString(), Value = x })
                            .ToList();

            typeComboBox.DisplayMember = "Text";
            typeComboBox.ValueMember = "Value";
            typeComboBox.DataSource = types;
        }

        private void Invoke(Action action)
        {
            if (action != null)
            {
                action();
            }
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void CloseForm()
        {
            Close();
            TransactionCompleted?.Invoke();
        }
    }
}
