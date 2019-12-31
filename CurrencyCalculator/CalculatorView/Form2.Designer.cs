namespace CalculatorView
{
    partial class Form2
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.IPEntryTextBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(58, 38);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(326, 66);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Try connecting to the Currency Exchange Rates (CER)\r\ndatabase using an IP address" +
    ":";
            // 
            // IPEntryTextBox
            // 
            this.IPEntryTextBox.AllowDrop = true;
            this.IPEntryTextBox.Location = new System.Drawing.Point(58, 110);
            this.IPEntryTextBox.Name = "IPEntryTextBox";
            this.IPEntryTextBox.Size = new System.Drawing.Size(183, 22);
            this.IPEntryTextBox.TabIndex = 1;
            this.IPEntryTextBox.TextChanged += new System.EventHandler(this.IPEntryTextBox_TextChanged);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(263, 110);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(121, 23);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 211);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.IPEntryTextBox);
            this.Controls.Add(this.textBox1);
            this.Name = "Form2";
            this.Text = "Manual Mode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox IPEntryTextBox;
        private System.Windows.Forms.Button connectButton;
    }
}