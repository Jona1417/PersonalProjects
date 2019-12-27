using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculate;

namespace Control
{
    public class CalcController
    {
        private string currencyToConvert;
        private string convertedCurrency;

        private double googleExchangeRate;
        private double XE_ExchangeRate;
        private double BCV_ExchangeRate;
        private double WU_ExchangeRate;
        private double averageExchangeRate;

        private bool sendingCurrencyIsValid;
        private bool receivingCurrencyIsValid;

        /// <summary>
        /// Event and delegate to handle when the user makes two valid choices for currency to be converted.
        /// </summary>
        public delegate void CurrenciesValidHandler();

        public event CurrenciesValidHandler SelectionsBothValid;

        /// <summary>
        /// Controls how user input affects the display of the View's Currency rates.
        /// </summary>
        public CalcController()
        {
            currencyToConvert = "";
            convertedCurrency = "";
            googleExchangeRate = 0;
            WU_ExchangeRate = 0;
            averageExchangeRate = 0;

            sendingCurrencyIsValid = false;
            receivingCurrencyIsValid = false;
        }

        /// <summary>
        /// When the user choose a currency to be converted.
        /// </summary>
        /// <param name="text"></param>
        public void SendingCurrencyChosen(string text)
        {
            switch (text)
            {
                case "":
                    sendingCurrencyIsValid = false;
                    break;
                default:
                    sendingCurrencyIsValid = true;
                    break;
            }

            if (sendingCurrencyIsValid && receivingCurrencyIsValid)
            {
                SelectionsBothValid();
            }
        }

        /// <summary>
        /// When the user chooses the desired currency after conversion
        /// </summary>
        /// <param name="text"></param>
        public void ReceivingCurrencyChosen(string text)
        {
            switch (text)
            {
                case "":
                    receivingCurrencyIsValid = false;
                    break;
                default:
                    receivingCurrencyIsValid = true;
                    break;
            }

            if (sendingCurrencyIsValid && receivingCurrencyIsValid)
            {
                SelectionsBothValid();
            }
        }

        /// <summary>
        /// Sets the user's current choice among possible conversion rates for the calculator's use.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="cRates"></param>
        /// <param name="buttonNumber">1,2,3,4 corresponding to the GoogleButton, XEButton, 
        /// WUButton, and Average button, respectively</param>
        public void SetCurrentExchangeChoice(string text, Calculator calculator, CurrencyRates cRates, int buttonNumber)
        {
            string currencyCode = GetCurrencyCode(text);
            switch (currencyCode)
            {
                case "VEF":
                    if (buttonNumber == 1) // the rate is from xe.com
                        calculator.CurrentExchangeRate = cRates.XE_USD_To_VEF;
                    else if (buttonNumber == 2) // the rate is from Banco Central
                        calculator.CurrentExchangeRate = cRates.BCV_USD_To_VEF;
                    else if (buttonNumber == 3) //exchangerates.org.uk
                        calculator.CurrentExchangeRate = cRates.exchangeRateUK_USD_To_VEF;
                    break;

                case "COP":
                    switch (buttonNumber)
                    {
                        case 1:
                            calculator.CurrentExchangeRate = cRates.G_USD_To_COP; // Google
                            break;
                        case 2:
                            calculator.CurrentExchangeRate = cRates.XE_USD_To_COP; // xe.com  
                            break;
                        case 3:
                            calculator.CurrentExchangeRate = cRates.WU_USD_To_COP; // Western Union
                            break;
                        case 4:
                            calculator.CurrentExchangeRate = cRates.AVG_USD_To_COP; // average
                            break;
                        default:
                            break;
                    }
                    break;

                case "BRL":
                    switch (buttonNumber)
                    {
                        case 1:
                            calculator.CurrentExchangeRate = cRates.G_USD_To_BRL; // Google
                            break;
                        case 2:
                            calculator.CurrentExchangeRate = cRates.XE_USD_To_BRL; // xe.com  
                            break;
                        case 3:
                            calculator.CurrentExchangeRate = cRates.WU_USD_To_BRL; // Western Union
                            break;
                        case 4:
                            calculator.CurrentExchangeRate = cRates.AVG_USD_To_BRL; // average
                            break;
                        default:
                            break;
                    }
                    break;

                case "CLP":
                    switch (buttonNumber)
                    {
                        case 1:
                            calculator.CurrentExchangeRate = cRates.G_USD_To_CLP; // Google
                            break;
                        case 2:
                            calculator.CurrentExchangeRate = cRates.XE_USD_To_CLP; // xe.com  
                            break;
                        case 3:
                            calculator.CurrentExchangeRate = cRates.WU_USD_To_CLP; // Western Union
                            break;
                        case 4:
                            calculator.CurrentExchangeRate = cRates.AVG_USD_To_CLP; // average
                            break;
                        default:
                            break;
                    }
                    break;
            }
        }

        private string GetCurrencyCode(string fullCurrencyName)
        {
            return fullCurrencyName.Substring(fullCurrencyName.Length - 4, 3);
        }

        /// <summary>
        /// Sets the exchange rates in the calculator according to the user's set of choices.
        /// </summary>
        /// <param name="cRates"></param>
        /// <param name="sendIndex"></param>
        /// <param name="receiveIndex"></param>
        public void SetExchangeRates(CurrencyRates cRates, int sendIndex, int receiveIndex)
        {
            List<double> rates = new List<double>();
            switch (sendIndex)
            {
                case 0: // empty string/no choice
                    break;
                case 1: // USD
                    currencyToConvert = "USD";
                    switch (receiveIndex)
                    {
                        case 0: // empty string/no choice
                            break;
                        case 1: // VEF
                            convertedCurrency = "VEF";
                            XE_ExchangeRate = cRates.XE_USD_To_VEF;
                            BCV_ExchangeRate = cRates.BCV_USD_To_VEF;
                            rates.Add(googleExchangeRate);
                            rates.Add(BCV_ExchangeRate);
                            cRates.setAverage(rates);
                            averageExchangeRate = cRates.AverageExchangeRate;
                            break;
                        case 2: // COP
                            convertedCurrency = "COP";
                            googleExchangeRate = cRates.G_USD_To_COP;
                            WU_ExchangeRate = cRates.WU_USD_To_COP;
                            XE_ExchangeRate = cRates.XE_USD_To_COP;
                            rates.Add(googleExchangeRate);
                            rates.Add(WU_ExchangeRate);
                            rates.Add(XE_ExchangeRate);
                            cRates.setAverage(rates);
                            averageExchangeRate = cRates.AverageExchangeRate;
                            break;
                        case 3: // BRL
                            convertedCurrency = "BRL";
                            googleExchangeRate = cRates.G_USD_To_BRL;
                            WU_ExchangeRate = cRates.WU_USD_To_BRL;
                            XE_ExchangeRate = cRates.XE_USD_To_BRL;
                            rates.Add(googleExchangeRate);
                            rates.Add(WU_ExchangeRate);
                            rates.Add(XE_ExchangeRate);
                            cRates.setAverage(rates);
                            averageExchangeRate = cRates.AverageExchangeRate;
                            break;
                        case 4: //CLP
                            convertedCurrency = "CLP";
                            googleExchangeRate = cRates.G_USD_To_CLP;
                            WU_ExchangeRate = cRates.WU_USD_To_CLP;
                            XE_ExchangeRate = cRates.XE_USD_To_CLP;
                            rates.Add(googleExchangeRate);
                            rates.Add(WU_ExchangeRate);
                            rates.Add(XE_ExchangeRate);
                            cRates.setAverage(rates);
                            averageExchangeRate = cRates.AverageExchangeRate;
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
        }


        /*
         * Below are methods that modify the text that corresponds with each button
         */

        /// <summary>
        /// Modifies the Google radio button
        /// </summary>
        /// <returns></returns>
        public string SetFirstButtonText(string v, CurrencyRates cRates)
        {
            if (v == "VEF")
                return "xe.com: 1 " + currencyToConvert + " = " +
                        XE_ExchangeRate + " " + convertedCurrency + "\r\n";
            else
                return "Google (Morningstar): 1 " + currencyToConvert + " = " +
                        googleExchangeRate + " " + convertedCurrency + "\r\n";
        }

        /// <summary>
        /// Modifies the xe.com radio button
        /// </summary>
        /// <returns></returns>
        public string SetSecondButtonText(string v, CurrencyRates cRates)
        {
            if (v == "VEF")
                return "Banco Central de Venezuela: 1 " + currencyToConvert + " = " +
                    BCV_ExchangeRate + " " + convertedCurrency + "\r\n";
            else
                return "xe.com: 1 " + currencyToConvert + " = " + XE_ExchangeRate + " " + convertedCurrency + "\r\n";
        }

        /// <summary>
        /// Modifies the Western Union radio button
        /// </summary>
        /// <returns></returns>
        public string SetThirdRadioButtonText(string text, CurrencyRates cRates)
        {
            if (text.Contains("VEF"))
                return "exchangerates.org.uk: 1 " + currencyToConvert + " = " + cRates.exchangeRateUK_USD_To_VEF
                    + " " + convertedCurrency + "\r\n";
            else
                return "Western Union: 1 " + currencyToConvert + " = " + WU_ExchangeRate + " " + convertedCurrency + "\r\n";
        }

        /// <summary>
        /// Modifies the AverageRate radio button
        /// </summary>
        /// <returns></returns>
        public string SetFourthRadioButtonText()
        {
            return "Average: 1 " + currencyToConvert + " = " + averageExchangeRate + " " + convertedCurrency + "\r\n";
        }

    }
}
