using Calculate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorView
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// The controller for the CurrencyCalculator form
        /// </summary>
        CalcController controller;

        Calculator calculator;

        public Form1(CalcController c)
        {
            InitializeComponent();
            controller = c;
            calculator = new Calculator();
            controller.selectionsBothValid += DisplayExchangeRates;
        }

        /// <summary>
        /// When the user has selected two valid currencies for exchange rates, this will display the exchange rates between the 
        /// two currencies according to their respective sources.
        /// </summary>
        private void DisplayExchangeRates()
        {
            throw new NotImplementedException();
        }

        //TODO: Remove
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void manualModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In Version 1.0, there is no manual input mode as of yet. Please wait for future versions" +
                " of CurrencyCalculator to take advantage of that feature", "Manual Mode", MessageBoxButtons.OK);
        }

        //TODO: REMOVE
        private void receiveCurrencyText_TextChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// When the user selects a non-empty value (currency) that is to be converted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendCurrencyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            sendCurrBox.Text = sendCurrencyList.Text;
            fromCurrency.Text = sendCurrencyList.Text;
            controller.SendingCurrencyChosen(sendCurrBox.Text);
        }

        /// <summary>
        /// When the user selects a non-empty value (currency) to which another currency will be converted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void receiveCurrBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToCurrBox.Text = ReceiveCurrBox.Text;
            toCurrency.Text = ReceiveCurrBox.Text;
            controller.SendingCurrencyChosen(ReceiveCurrBox.Text);
        }

        private void equalsText_TextChanged(object sender, EventArgs e)
        {
            // TODO: Remove

        }

        private void calculateButton_Click(object sender, EventArgs e)
        {

        }
    }
}
