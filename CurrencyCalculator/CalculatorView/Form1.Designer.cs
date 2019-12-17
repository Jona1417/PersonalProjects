namespace CalculatorView
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendCurrencyText = new System.Windows.Forms.TextBox();
            this.sendCurrencyList = new System.Windows.Forms.ComboBox();
            this.receiveCurrencyText = new System.Windows.Forms.TextBox();
            this.ReceiveCurrBox = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.sendCurrBox = new System.Windows.Forms.TextBox();
            this.ToCurrBox = new System.Windows.Forms.TextBox();
            this.exchangeRatesText = new System.Windows.Forms.TextBox();
            this.exchangeRatesTitle = new System.Windows.Forms.TextBox();
            this.inputNumberBox = new System.Windows.Forms.TextBox();
            this.equalsText = new System.Windows.Forms.TextBox();
            this.fromCurrency = new System.Windows.Forms.TextBox();
            this.outputNumberBox = new System.Windows.Forms.TextBox();
            this.toCurrency = new System.Windows.Forms.TextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualModeToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // manualModeToolStripMenuItem
            // 
            this.manualModeToolStripMenuItem.Name = "manualModeToolStripMenuItem";
            this.manualModeToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.manualModeToolStripMenuItem.Text = "Manual Mode";
            this.manualModeToolStripMenuItem.Click += new System.EventHandler(this.manualModeToolStripMenuItem_Click);
            // 
            // sendCurrencyText
            // 
            this.sendCurrencyText.BackColor = System.Drawing.SystemColors.Menu;
            this.sendCurrencyText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sendCurrencyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sendCurrencyText.Location = new System.Drawing.Point(31, 51);
            this.sendCurrencyText.Name = "sendCurrencyText";
            this.sendCurrencyText.ReadOnly = true;
            this.sendCurrencyText.Size = new System.Drawing.Size(151, 19);
            this.sendCurrencyText.TabIndex = 1;
            this.sendCurrencyText.Text = "Sender Currency:";
            // 
            // sendCurrencyList
            // 
            this.sendCurrencyList.FormattingEnabled = true;
            this.sendCurrencyList.Items.AddRange(new object[] {
            "",
            "United States Dollar (USD)"});
            this.sendCurrencyList.Location = new System.Drawing.Point(188, 51);
            this.sendCurrencyList.Name = "sendCurrencyList";
            this.sendCurrencyList.Size = new System.Drawing.Size(199, 24);
            this.sendCurrencyList.TabIndex = 2;
            this.sendCurrencyList.SelectedIndexChanged += new System.EventHandler(this.sendCurrencyList_SelectedIndexChanged);
            // 
            // receiveCurrencyText
            // 
            this.receiveCurrencyText.BackColor = System.Drawing.SystemColors.Menu;
            this.receiveCurrencyText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.receiveCurrencyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.receiveCurrencyText.Location = new System.Drawing.Point(404, 51);
            this.receiveCurrencyText.Name = "receiveCurrencyText";
            this.receiveCurrencyText.ReadOnly = true;
            this.receiveCurrencyText.Size = new System.Drawing.Size(165, 19);
            this.receiveCurrencyText.TabIndex = 3;
            this.receiveCurrencyText.Text = "Receiver Currency:";
            this.receiveCurrencyText.TextChanged += new System.EventHandler(this.receiveCurrencyText_TextChanged);
            // 
            // ReceiveCurrBox
            // 
            this.ReceiveCurrBox.FormattingEnabled = true;
            this.ReceiveCurrBox.Items.AddRange(new object[] {
            "",
            "Venezuelan Bolivar (VEF)",
            "Colombian Peso (COP)"});
            this.ReceiveCurrBox.Location = new System.Drawing.Point(575, 51);
            this.ReceiveCurrBox.Name = "ReceiveCurrBox";
            this.ReceiveCurrBox.Size = new System.Drawing.Size(200, 24);
            this.ReceiveCurrBox.TabIndex = 4;
            this.ReceiveCurrBox.SelectedIndexChanged += new System.EventHandler(this.receiveCurrBox_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(404, 128);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(42, 30);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "TO";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sendCurrBox
            // 
            this.sendCurrBox.Location = new System.Drawing.Point(72, 128);
            this.sendCurrBox.Name = "sendCurrBox";
            this.sendCurrBox.ReadOnly = true;
            this.sendCurrBox.Size = new System.Drawing.Size(306, 22);
            this.sendCurrBox.TabIndex = 6;
            // 
            // ToCurrBox
            // 
            this.ToCurrBox.Location = new System.Drawing.Point(471, 128);
            this.ToCurrBox.Name = "ToCurrBox";
            this.ToCurrBox.ReadOnly = true;
            this.ToCurrBox.Size = new System.Drawing.Size(306, 22);
            this.ToCurrBox.TabIndex = 7;
            // 
            // exchangeRatesText
            // 
            this.exchangeRatesText.Location = new System.Drawing.Point(31, 215);
            this.exchangeRatesText.Multiline = true;
            this.exchangeRatesText.Name = "exchangeRatesText";
            this.exchangeRatesText.Size = new System.Drawing.Size(370, 182);
            this.exchangeRatesText.TabIndex = 8;
            // 
            // exchangeRatesTitle
            // 
            this.exchangeRatesTitle.BackColor = System.Drawing.SystemColors.Menu;
            this.exchangeRatesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.exchangeRatesTitle.Location = new System.Drawing.Point(153, 182);
            this.exchangeRatesTitle.Name = "exchangeRatesTitle";
            this.exchangeRatesTitle.ReadOnly = true;
            this.exchangeRatesTitle.Size = new System.Drawing.Size(131, 24);
            this.exchangeRatesTitle.TabIndex = 9;
            this.exchangeRatesTitle.Text = "Exchange Rates:";
            // 
            // inputNumberBox
            // 
            this.inputNumberBox.Location = new System.Drawing.Point(471, 212);
            this.inputNumberBox.Name = "inputNumberBox";
            this.inputNumberBox.Size = new System.Drawing.Size(108, 22);
            this.inputNumberBox.TabIndex = 11;
            // 
            // equalsText
            // 
            this.equalsText.BackColor = System.Drawing.SystemColors.Menu;
            this.equalsText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.equalsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equalsText.Location = new System.Drawing.Point(575, 254);
            this.equalsText.Name = "equalsText";
            this.equalsText.ReadOnly = true;
            this.equalsText.Size = new System.Drawing.Size(33, 23);
            this.equalsText.TabIndex = 12;
            this.equalsText.Text = "=";
            this.equalsText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.equalsText.TextChanged += new System.EventHandler(this.equalsText_TextChanged);
            // 
            // fromCurrency
            // 
            this.fromCurrency.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fromCurrency.Location = new System.Drawing.Point(596, 215);
            this.fromCurrency.Name = "fromCurrency";
            this.fromCurrency.ReadOnly = true;
            this.fromCurrency.Size = new System.Drawing.Size(181, 15);
            this.fromCurrency.TabIndex = 13;
            // 
            // outputNumberBox
            // 
            this.outputNumberBox.Location = new System.Drawing.Point(471, 303);
            this.outputNumberBox.Name = "outputNumberBox";
            this.outputNumberBox.Size = new System.Drawing.Size(108, 22);
            this.outputNumberBox.TabIndex = 14;
            // 
            // toCurrency
            // 
            this.toCurrency.BackColor = System.Drawing.SystemColors.Menu;
            this.toCurrency.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toCurrency.Location = new System.Drawing.Point(596, 306);
            this.toCurrency.Name = "toCurrency";
            this.toCurrency.ReadOnly = true;
            this.toCurrency.Size = new System.Drawing.Size(181, 15);
            this.toCurrency.TabIndex = 15;
            // 
            // calculateButton
            // 
            this.calculateButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.calculateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.calculateButton.Location = new System.Drawing.Point(560, 356);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(120, 38);
            this.calculateButton.TabIndex = 16;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = false;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.toCurrency);
            this.Controls.Add(this.outputNumberBox);
            this.Controls.Add(this.fromCurrency);
            this.Controls.Add(this.equalsText);
            this.Controls.Add(this.inputNumberBox);
            this.Controls.Add(this.exchangeRatesTitle);
            this.Controls.Add(this.exchangeRatesText);
            this.Controls.Add(this.ToCurrBox);
            this.Controls.Add(this.sendCurrBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ReceiveCurrBox);
            this.Controls.Add(this.receiveCurrencyText);
            this.Controls.Add(this.sendCurrencyList);
            this.Controls.Add(this.sendCurrencyText);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "CurrencyCalculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualModeToolStripMenuItem;
        private System.Windows.Forms.TextBox sendCurrencyText;
        private System.Windows.Forms.ComboBox sendCurrencyList;
        private System.Windows.Forms.TextBox receiveCurrencyText;
        private System.Windows.Forms.ComboBox ReceiveCurrBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox sendCurrBox;
        private System.Windows.Forms.TextBox ToCurrBox;
        private System.Windows.Forms.TextBox exchangeRatesText;
        private System.Windows.Forms.TextBox exchangeRatesTitle;
        private System.Windows.Forms.TextBox inputNumberBox;
        private System.Windows.Forms.TextBox equalsText;
        private System.Windows.Forms.TextBox fromCurrency;
        private System.Windows.Forms.TextBox outputNumberBox;
        private System.Windows.Forms.TextBox toCurrency;
        private System.Windows.Forms.Button calculateButton;
    }
}

