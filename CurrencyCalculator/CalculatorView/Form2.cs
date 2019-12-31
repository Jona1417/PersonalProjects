using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorView
{
    public partial class Form2 : Form
    {
        Form1 mainForm;
        public Form2(Form1 f1)
        {
            InitializeComponent();
            mainForm = f1;
            connectButton.Enabled = false;
        }

        private void IPEntryTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(IPEntryTextBox.Text, "^[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}$"))
                connectButton.Enabled = false;
            else
                connectButton.Enabled = true;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            mainForm.ManualConnect(IPEntryTextBox.Text);
        }
    }
}
