namespace AccountingForPersonalFinances.Presentation
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            walletsComboBox = new ComboBox();
            transactionsDataGridView = new DataGridView();
            balanceLabel = new Label();
            historyLabel = new Label();
            monthsComboBox = new ComboBox();
            transactionsLabel = new Label();
            biggestExpensesLabel = new Label();
            biggestExpensesDataGridView = new DataGridView();
            walletsGroupBox = new GroupBox();
            label1 = new Label();
            transactionsGroupBox = new GroupBox();
            totalExpenseLabel = new Label();
            totalIncomeLabel = new Label();
            makeTransactionButton = new Button();
            ((System.ComponentModel.ISupportInitialize)transactionsDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)biggestExpensesDataGridView).BeginInit();
            walletsGroupBox.SuspendLayout();
            transactionsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // walletsComboBox
            // 
            walletsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            walletsComboBox.FormattingEnabled = true;
            walletsComboBox.Location = new Point(13, 22);
            walletsComboBox.Name = "walletsComboBox";
            walletsComboBox.Size = new Size(261, 23);
            walletsComboBox.TabIndex = 0;
            // 
            // transactionsDataGridView
            // 
            transactionsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            transactionsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            transactionsDataGridView.Location = new Point(13, 68);
            transactionsDataGridView.Name = "transactionsDataGridView";
            transactionsDataGridView.Size = new Size(626, 260);
            transactionsDataGridView.TabIndex = 1;
            // 
            // balanceLabel
            // 
            balanceLabel.AutoSize = true;
            balanceLabel.Location = new Point(13, 75);
            balanceLabel.Name = "balanceLabel";
            balanceLabel.Size = new Size(54, 15);
            balanceLabel.TabIndex = 2;
            balanceLabel.Text = "0.00 руб.";
            // 
            // historyLabel
            // 
            historyLabel.AutoSize = true;
            historyLabel.Location = new Point(13, 22);
            historyLabel.Name = "historyLabel";
            historyLabel.Size = new Size(134, 15);
            historyLabel.TabIndex = 4;
            historyLabel.Text = "История транзакций за";
            // 
            // monthsComboBox
            // 
            monthsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            monthsComboBox.FormattingEnabled = true;
            monthsComboBox.Items.AddRange(new object[] { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" });
            monthsComboBox.Location = new Point(153, 19);
            monthsComboBox.Name = "monthsComboBox";
            monthsComboBox.Size = new Size(121, 23);
            monthsComboBox.TabIndex = 5;
            monthsComboBox.SelectedIndex = 0;
            // 
            // transactionsLabel
            // 
            transactionsLabel.AutoSize = true;
            transactionsLabel.Location = new Point(13, 50);
            transactionsLabel.Name = "transactionsLabel";
            transactionsLabel.Size = new Size(75, 15);
            transactionsLabel.TabIndex = 6;
            transactionsLabel.Text = "Транзакции:";
            // 
            // biggestExpensesLabel
            // 
            biggestExpensesLabel.AutoSize = true;
            biggestExpensesLabel.Location = new Point(13, 374);
            biggestExpensesLabel.Name = "biggestExpensesLabel";
            biggestExpensesLabel.Size = new Size(137, 15);
            biggestExpensesLabel.TabIndex = 10;
            biggestExpensesLabel.Text = "Самые большие траты:";
            // 
            // biggestExpensesDataGridView
            // 
            biggestExpensesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            biggestExpensesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            biggestExpensesDataGridView.Location = new Point(13, 392);
            biggestExpensesDataGridView.Name = "biggestExpensesDataGridView";
            biggestExpensesDataGridView.Size = new Size(626, 140);
            biggestExpensesDataGridView.TabIndex = 9;
            // 
            // walletsGroupBox
            // 
            walletsGroupBox.Controls.Add(label1);
            walletsGroupBox.Controls.Add(walletsComboBox);
            walletsGroupBox.Controls.Add(balanceLabel);
            walletsGroupBox.Location = new Point(12, 12);
            walletsGroupBox.Name = "walletsGroupBox";
            walletsGroupBox.Size = new Size(287, 116);
            walletsGroupBox.TabIndex = 13;
            walletsGroupBox.TabStop = false;
            walletsGroupBox.Text = "Кошелёк";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 55);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 14;
            label1.Text = "Баланс:";
            // 
            // transactionsGroupBox
            // 
            transactionsGroupBox.Controls.Add(makeTransactionButton);
            transactionsGroupBox.Controls.Add(totalExpenseLabel);
            transactionsGroupBox.Controls.Add(totalIncomeLabel);
            transactionsGroupBox.Controls.Add(historyLabel);
            transactionsGroupBox.Controls.Add(transactionsDataGridView);
            transactionsGroupBox.Controls.Add(biggestExpensesLabel);
            transactionsGroupBox.Controls.Add(monthsComboBox);
            transactionsGroupBox.Controls.Add(biggestExpensesDataGridView);
            transactionsGroupBox.Controls.Add(transactionsLabel);
            transactionsGroupBox.Location = new Point(12, 134);
            transactionsGroupBox.Name = "transactionsGroupBox";
            transactionsGroupBox.Size = new Size(651, 549);
            transactionsGroupBox.TabIndex = 14;
            transactionsGroupBox.TabStop = false;
            transactionsGroupBox.Text = "Транзакции";
            // 
            // totalExpenseLabel
            // 
            totalExpenseLabel.AutoSize = true;
            totalExpenseLabel.Location = new Point(335, 346);
            totalExpenseLabel.Name = "totalExpenseLabel";
            totalExpenseLabel.Size = new Size(109, 15);
            totalExpenseLabel.TabIndex = 12;
            totalExpenseLabel.Text = "Месячный расход:";
            // 
            // totalIncomeLabel
            // 
            totalIncomeLabel.AutoSize = true;
            totalIncomeLabel.Location = new Point(13, 346);
            totalIncomeLabel.Name = "totalIncomeLabel";
            totalIncomeLabel.Size = new Size(103, 15);
            totalIncomeLabel.TabIndex = 11;
            totalIncomeLabel.Text = "Месячный доход:";
            // 
            // makeTransactionButton
            // 
            makeTransactionButton.Location = new Point(291, 19);
            makeTransactionButton.Name = "makeTransactionButton";
            makeTransactionButton.Size = new Size(165, 23);
            makeTransactionButton.TabIndex = 13;
            makeTransactionButton.Text = "Совершить транзакцию";
            makeTransactionButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(677, 695);
            Controls.Add(transactionsGroupBox);
            Controls.Add(walletsGroupBox);
            MaximizeBox = false;
            MaximumSize = new Size(693, 734);
            MinimumSize = new Size(693, 734);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Учёт личных финансов";
            ((System.ComponentModel.ISupportInitialize)transactionsDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)biggestExpensesDataGridView).EndInit();
            walletsGroupBox.ResumeLayout(false);
            walletsGroupBox.PerformLayout();
            transactionsGroupBox.ResumeLayout(false);
            transactionsGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox walletsComboBox;
        private DataGridView transactionsDataGridView;
        private Label balanceLabel;
        private Label historyLabel;
        private ComboBox monthsComboBox;
        private Label transactionsLabel;
        private Label biggestExpensesLabel;
        private DataGridView biggestExpensesDataGridView;
        private GroupBox walletsGroupBox;
        private Label label1;
        private GroupBox transactionsGroupBox;
        private Label totalExpenseLabel;
        private Label totalIncomeLabel;
        private Button makeTransactionButton;
    }
}
