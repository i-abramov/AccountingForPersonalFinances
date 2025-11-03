using AccountingForPersonalFinances.Domain.Models.Enums;

namespace AccountingForPersonalFinances.Presentation.Views
{
    partial class MakeTransactionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            typeComboBox = new ComboBox();
            amountLabel = new Label();
            createButton = new Button();
            amountNumericUpDown = new NumericUpDown();
            typeLabel = new Label();
            descriptionTextBox = new TextBox();
            descriptionLabel = new Label();
            cancelButton = new Button();
            ((System.ComponentModel.ISupportInitialize)amountNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // typeComboBox
            // 
            typeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            typeComboBox.FormattingEnabled = true;
            typeComboBox.Items.AddRange(new TransactionType[] { TransactionType.Income, TransactionType.Expense });
            typeComboBox.Location = new Point(132, 27);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Size = new Size(114, 23);
            typeComboBox.TabIndex = 0;
            typeComboBox.SelectedIndex = 0;
            // 
            // amountLabel
            // 
            amountLabel.AutoSize = true;
            amountLabel.Location = new Point(12, 9);
            amountLabel.Name = "amountLabel";
            amountLabel.Size = new Size(114, 15);
            amountLabel.TabIndex = 1;
            amountLabel.Text = "Сумма транзакции:";
            // 
            // createButton
            // 
            createButton.Location = new Point(252, 64);
            createButton.Name = "createButton";
            createButton.Size = new Size(75, 23);
            createButton.TabIndex = 3;
            createButton.Text = "Создать";
            createButton.UseVisualStyleBackColor = true;
            // 
            // amountNumericUpDown
            // 
            amountNumericUpDown.DecimalPlaces = 2;
            amountNumericUpDown.Location = new Point(12, 27);
            amountNumericUpDown.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            amountNumericUpDown.Name = "amountNumericUpDown";
            amountNumericUpDown.Size = new Size(114, 23);
            amountNumericUpDown.TabIndex = 4;
            // 
            // typeLabel
            // 
            typeLabel.AutoSize = true;
            typeLabel.Location = new Point(132, 9);
            typeLabel.Name = "typeLabel";
            typeLabel.Size = new Size(97, 15);
            typeLabel.TabIndex = 5;
            typeLabel.Text = "Тип транзакции:";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new Point(252, 27);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(399, 23);
            descriptionTextBox.TabIndex = 6;
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(252, 9);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(131, 15);
            descriptionLabel.TabIndex = 7;
            descriptionLabel.Text = "Описание транзакции:";
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(333, 64);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 8;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // MakeTransactionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(663, 104);
            Controls.Add(cancelButton);
            Controls.Add(descriptionLabel);
            Controls.Add(descriptionTextBox);
            Controls.Add(typeLabel);
            Controls.Add(amountNumericUpDown);
            Controls.Add(createButton);
            Controls.Add(amountLabel);
            Controls.Add(typeComboBox);
            MaximizeBox = false;
            MaximumSize = new Size(679, 143);
            MinimumSize = new Size(679, 143);
            Name = "MakeTransactionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Создание транзакции";
            ((System.ComponentModel.ISupportInitialize)amountNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox typeComboBox;
        private Label amountLabel;
        private TextBox textBox1;
        private Button createButton;
        private NumericUpDown amountNumericUpDown;
        private Label typeLabel;
        private TextBox descriptionTextBox;
        private Label descriptionLabel;
        private Button cancelButton;
    }
}