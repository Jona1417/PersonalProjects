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
using Control;

namespace CalculatorView
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// The controller for the CurrencyCalculator form
        /// </summary>
        private CalcController controller;

        /// <summary>
        /// Takes care of the calculations between currencies
        /// </summary>
        private Calculator calculator;

        /// <summary>
        /// Keeps track of the exchange rates
        /// </summary>
        private CurrencyRates cRates;

        /// <summary>
        /// Controls interaction with the Currency Exchange Rates (CER) database
        /// </summary>
        private DbController dbController;

        public Form1(CalcController c)
        {
            InitializeComponent();
            controller = c;
            calculator = new Calculator();
            cRates = new CurrencyRates();
            dbController = new DbController(cRates);

            // register to events in the controller
            controller.SelectionsBothValid += DisplayExchangeRates;
            dbController.ExchangeRatesUpdated += DisplaySuccessfulUpdate;
            dbController.FailedToUpdate += DisplayUpdateFailure;

            // Try to receive updates from the database
            dbController.UpdateAllRates();
            cRates.UpdateAverages();
            cRates.Save("ExchangeRateSettings.xml");

            // Only let the buttons appear when choices are selected
            RemoveButtons();

        }

        /// <summary>
        /// Displays to the user that there was an error while connecting to the Currency Exchange Rates (CER) database or while
        /// trying to retrieve information from that DB.
        /// </summary>
        private void DisplayUpdateFailure()
        {
            MessageBox.Show("Error occurred while trying to obtain updated currency exchange rates. Please check your " +
                "connection and try again by restarting the client.", "Unable to receive updates from Currency Exchange Rates" +
                " (CER) Database", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Updates the time the currency exchange rates were last updated (if the connection/retrieval process was successful)
        /// </summary>
        private void DisplaySuccessfulUpdate()
        {
            lastUpdatedText.Text = "Last Updated: " + dbController.GetTimeOfLastUpdate().ToString();
        }

        /// <summary>
        /// When the user has selected two valid currencies for exchange rates, this will display the exchange rates between the 
        /// two currencies according to their respective sources.
        /// </summary>
        private void DisplayExchangeRates()
        {
            switch (sendCurrencyList.SelectedIndex)
            {
                case 0: // empty string/no choice
                    break;
                case 1: // USD
                    //currencyToConvert = "USD";
                    switch (receiveCurrencyList.SelectedIndex)
                    {
                        case 0: // empty string/no choice
                            break;
                        case 1: // VEF 3 options
                            RemoveButtons();
                            GoogleRateButton.Enabled = true;
                            GoogleRateButton.Visible = true;
                            GoogleRateButton.Checked = false;
                            XEButton.Enabled = true;
                            XEButton.Visible = true;
                            XEButton.Checked = false;
                            WUButton.Visible = true;
                            WUButton.Enabled = true;
                            WUButton.Checked = false;

                            //set the exchange rates
                            controller.SetExchangeRates(cRates, 1, 1);
                            GoogleRateButton.Text = controller.SetFirstButtonText("VEF", cRates);

                            //Xe button will be the BCV
                            XEButton.Text = controller.SetSecondButtonText("VEF", cRates);

                            WUButton.Text = controller.SetThirdRadioButtonText("VEF", cRates);
                            break;
                        case 2: // COP: has all options
                            RemoveButtons();
                            EnableAllRadioButtons();

                            //set the exchange rates
                            controller.SetExchangeRates(cRates, 1, 2);

                            GoogleRateButton.Text = controller.SetFirstButtonText("COP", cRates);
                            XEButton.Text = controller.SetSecondButtonText("COP", cRates);
                            WUButton.Text = controller.SetThirdRadioButtonText("COP", cRates);
                            AverageRateButton.Text = controller.SetFourthRadioButtonText();
                            break;
                        case 3: //BRL
                            RemoveButtons();
                            EnableAllRadioButtons();

                            //set the exchange rates
                            controller.SetExchangeRates(cRates, 1, 3);

                            GoogleRateButton.Text = controller.SetFirstButtonText("BRL", cRates);
                            XEButton.Text = controller.SetSecondButtonText("BRL", cRates);
                            WUButton.Text = controller.SetThirdRadioButtonText("BRL", cRates);
                            AverageRateButton.Text = controller.SetFourthRadioButtonText();
                            break;
                        case 4: //CLP
                            RemoveButtons();
                            EnableAllRadioButtons();

                            //set the exchange rates
                            controller.SetExchangeRates(cRates, 1, 4);

                            GoogleRateButton.Text = controller.SetFirstButtonText("CLP", cRates);
                            XEButton.Text = controller.SetSecondButtonText("CLP", cRates);
                            WUButton.Text = controller.SetThirdRadioButtonText("CLP", cRates);
                            AverageRateButton.Text = controller.SetFourthRadioButtonText();
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// When the user clicks on the Manual Mode item in the help menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            fromCurrency.Text = sendCurrencyList.Text;
            controller.SendingCurrencyChosen(sendCurrencyList.Text);
        }

        /// <summary>
        /// When the user selects a non-empty value (currency) to which another currency will be converted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void receiveCurrBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            toCurrency.Text = receiveCurrencyList.Text;
            controller.ReceivingCurrencyChosen(receiveCurrencyList.Text);
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(inputNumberBox.Text, out double input))
                MessageBox.Show("Input is not valid. Try again", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                outputNumberBox.Text = "" + calculator.Calculate(input, calculator.CurrentExchangeRate);
            }
        }

        /// <summary>
        /// Temporarily removes and disables the radio buttons on the Form (allowing for resetting values)
        /// </summary>
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
            calculateButton.Enabled = false;
        }

        /// <summary>
        /// Re-enables all the radio buttons when a currency selection is changed and unchecks any that were previously checked
        /// </summary>
        private void EnableAllRadioButtons()
        {
            GoogleRateButton.Visible = true;
            GoogleRateButton.Enabled = true;
            GoogleRateButton.Checked = false;

            XEButton.Visible = true;
            XEButton.Enabled = true;
            XEButton.Checked = false;

            WUButton.Visible = true;
            WUButton.Enabled = true;
            WUButton.Checked = false;

            AverageRateButton.Visible = true;
            AverageRateButton.Enabled = true;
            AverageRateButton.Checked = false;
        }

        /// <summary>
        /// When the user clicks on the first radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoogleRateButton_CheckedChanged(object sender, EventArgs e)
        {
            controller.SetCurrentExchangeChoice(receiveCurrencyList.Text, calculator, cRates, 1);
            calculateButton.Enabled = true;
        }

        /// <summary>
        /// When the user clicks on the second radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XEButton_CheckedChanged(object sender, EventArgs e)
        {
            controller.SetCurrentExchangeChoice(receiveCurrencyList.Text, calculator, cRates, 2);
            calculateButton.Enabled = true;
        }

        /// <summary>
        /// When the user clicks on the third radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WUButton_CheckedChanged(object sender, EventArgs e)
        {
            controller.SetCurrentExchangeChoice(receiveCurrencyList.Text, calculator, cRates, 3);
            calculateButton.Enabled = true;
        }

        /// <summary>
        /// When the user clicks on the fourth radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AverageRateButton_CheckedChanged(object sender, EventArgs e)
        {
            controller.SetCurrentExchangeChoice(receiveCurrencyList.Text, calculator, cRates, 4);
            calculateButton.Enabled = true;
        }

        /// <summary>
        /// If the user presses enter while the focus is on the number input box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputNumberBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && calculateButton.Enabled)
                calculateButton_Click(sender, e);
        }


    }
}
