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

        private string currencyToConvert;
        private string convertedCurrency;

        private double googleExchangeRate;
        private double XE_ExchangeRate;
        private double BCV_ExchangeRate;
        private double WU_ExchangeRate;
        private double averageExchangeRate;
        private CurrencyRates cRates;

        public Form1(CalcController c)
        {
            InitializeComponent();
            controller = c;
            calculator = new Calculator();
            cRates = new CurrencyRates();
            currencyToConvert = "";
            convertedCurrency = "";
            googleExchangeRate = 0;
            WU_ExchangeRate = 0;
            averageExchangeRate = 0;
            controller.selectionsBothValid += DisplayExchangeRates;
        }

        /// <summary>
        /// When the user has selected two valid currencies for exchange rates, this will display the exchange rates between the 
        /// two currencies according to their respective sources.
        /// </summary>
        private void DisplayExchangeRates()
        {
            //TODO: Try to move all this to the Controller
            CurrencyRates cRates = new CurrencyRates();
            List<double> rates = new List<double>();
            //string displayString = controller.SetDisplayString(sendCurrencyList.SelectedIndex);
            switch (sendCurrencyList.SelectedIndex)
            {
                case 0: // empty string/no choice
                    break;
                case 1: // USD
                    currencyToConvert = "USD";
                    switch (ReceiveCurrBox.SelectedIndex)
                    {
                        case 0: // empty string/no choice
                            break;
                        case 1: // VEF
                            convertedCurrency = "VEF";
                            googleExchangeRate = cRates.G_USD_To_VEF;
                            BCV_ExchangeRate = cRates.BCV_USD_To_VEF;
                            rates.Add(googleExchangeRate);
                            rates.Add(BCV_ExchangeRate);
                            cRates.setAverage(rates);
                            averageExchangeRate = cRates.AverageExchangeRate;
                            break;
                        case 2: // COP
                            convertedCurrency = "COP";
                            googleExchangeRate = cRates.G_USD_To_COP;
                            WU_ExchangeRate = cRates.WU_USD_TO_COP;
                            XE_ExchangeRate = cRates.XE_USD_To_COP;
                            rates.Add(googleExchangeRate);
                            rates.Add(WU_ExchangeRate);
                            rates.Add(XE_ExchangeRate);
                            cRates.setAverage(rates);
                            averageExchangeRate = cRates.AverageExchangeRate;
                            break;
                    }
                    break;
            }


            if (currencyToConvert != "" && convertedCurrency != "") // the check may not be necessary
            {
                if (convertedCurrency == "VEF")
                    exchangeRatesText.Text = "Google (Morningstar): 1 " + currencyToConvert + " = " +
                        googleExchangeRate + " " + convertedCurrency + "\r\n" +
                        "Banco Central de Venezuela: 1 " + currencyToConvert + " = " +
                        BCV_ExchangeRate + " " + convertedCurrency + "\r\n" +
                         "Average: 1 " + currencyToConvert + " = " + cRates.AverageExchangeRate + " " + convertedCurrency + "\r\n";
                else
                    exchangeRatesText.Text = "Google (Morningstar): 1 " + currencyToConvert + " = " +
                       googleExchangeRate + " " + convertedCurrency + "\r\n" +
                       "Western Union: 1 " + currencyToConvert + " = " +
                       WU_ExchangeRate + " " + convertedCurrency + "\r\n" +
                       "xe.com: 1 " + currencyToConvert + " = " +
                       XE_ExchangeRate + " " + convertedCurrency + "\r\n" +
                       "Average: 1 " + currencyToConvert + " = " + cRates.AverageExchangeRate + " " + convertedCurrency + "\r\n";
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
                outputNumberBox.Text = "" + calculator.Calculate(input, averageExchangeRate);
            }
        }
    }
}
