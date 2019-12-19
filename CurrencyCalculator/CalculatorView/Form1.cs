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
        private CalcController controller;

        private Calculator calculator;
        private double averageExchangeRate;
        private CurrencyRates cRates;

        public Form1(CalcController c)
        {
            InitializeComponent();
            controller = c;
            calculator = new Calculator();
            cRates = new CurrencyRates();
            averageExchangeRate = 0;
            controller.selectionsBothValid += DisplayExchangeRates;

            // Only let the buttons appear when choices are selected
            RemoveButtons();
        }

        /// <summary>
        /// When the user has selected two valid currencies for exchange rates, this will display the exchange rates between the 
        /// two currencies according to their respective sources.
        /// </summary>
        private void DisplayExchangeRates()
        {
            //TODO: Try to move all this to the Controller
            // CurrencyRates cRates = new CurrencyRates();
            // List<double> rates = new List<double>();
            //string displayString = controller.SetDisplayString(sendCurrencyList.SelectedIndex);
            switch (sendCurrencyList.SelectedIndex)
            {
                case 0: // empty string/no choice
                    break;
                case 1: // USD
                    //currencyToConvert = "USD";
                    switch (ReceiveCurrBox.SelectedIndex)
                    {
                        case 0: // empty string/no choice
                            break;
                        case 1: // VEF: only has 2 options (google, BCV)
                            RemoveButtons();
                            GoogleRateButton.Enabled = true;
                            GoogleRateButton.Visible = true;
                            XEButton.Enabled = true;
                            XEButton.Visible = true;
                            GoogleRateButton.Text = "Google (Morningstar):";
                            GoogleRateButton.Text = calculator.SetFirstButtonText("VEF", cRates);

                            //Xe button will be the BCV
                            XEButton.Text = calculator.SetSecondButtonText("VEF", cRates);
                            //exchangeRatesText.Text = calculator.DisplayExchangeRates(cRates, 1, 1);
                            break;
                        case 2: // COP: has all options
                            RemoveButtons();
                            EnableAllRadioButtons();
                            //exchangeRatesText.Text = calculator.DisplayExchangeRates(cRates, 1, 2);
                            break;
                    }
                    break;
                default:
                    break;
            }
        }


        private void manualModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In Version 1.0, there is no manual input mode as of yet. Please wait for future versions" +
                " of CurrencyCalculator to take advantage of that feature", "Manual Mode", MessageBoxButtons.OK);
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
            controller.ReceivingCurrencyChosen(ReceiveCurrBox.Text);
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(inputNumberBox.Text, out double input))
                MessageBox.Show("Input is not valid. Try again", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                outputNumberBox.Text = "" + calculator.Calculate(input, cRates.AverageExchangeRate);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RemoveButtons()
        {
            GoogleRateButton.Visible = false;
            GoogleRateButton.Enabled = false;
            XEButton.Visible = false;
            XEButton.Enabled = false;
            WUButton.Visible = false;
            WUButton.Enabled = false;
            AverageRateButton.Visible = false;
            AverageRateButton.Enabled = false;
        }

        private void EnableAllRadioButtons()
        {
            GoogleRateButton.Visible = true;
            GoogleRateButton.Enabled = true;
            XEButton.Visible = true;
            XEButton.Enabled = true;
            WUButton.Visible = true;
            WUButton.Enabled = true;
            AverageRateButton.Visible = true;
            AverageRateButton.Enabled = true;
        }
    }
}
