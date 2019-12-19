using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    /// <summary>
    /// The Calculator handles the logic of performing currency conversions and calculations.
    /// </summary>
    public class Calculator
    {
        private string currencyToConvert;
        private string convertedCurrency;

        private double googleExchangeRate;
        private double XE_ExchangeRate;
        private double BCV_ExchangeRate;
        private double WU_ExchangeRate;
        private double averageExchangeRate;
        // private CurrencyRates cRates;

        public Calculator()
        {
            // cRates = new CurrencyRates();
            currencyToConvert = "";
            convertedCurrency = "";
            googleExchangeRate = 0;
            WU_ExchangeRate = 0;
            averageExchangeRate = 0;
        }
        public double Calculate(double input, double exchangeRate)
        {
            return input * exchangeRate;
        }

        /// <summary>
        /// Sets the exchange rates in the calculator according to the user's set of choices.
        /// </summary>
        /// <param name="cRates"></param>
        /// <param name="sendIndex"></param>
        /// <param name="receiveIndex"></param>
        public void SetExchangeRates(CurrencyRates cRates, int sendIndex, int receiveIndex)
        {
            //TODO: Try to move all this to the Controller
            List<double> rates = new List<double>();
            //string displayString = controller.SetDisplayString(sendCurrencyList.SelectedIndex);
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
                default:
                    break;
            }

            //if (currencyToConvert != "" && convertedCurrency != "") // the check may not be necessary
            //{
            //    if (convertedCurrency == "VEF")
            //        return "Google (Morningstar): 1 " + currencyToConvert + " = " +
            //            googleExchangeRate + " " + convertedCurrency + "\r\n" +
            //            "Banco Central de Venezuela: 1 " + currencyToConvert + " = " +
            //            BCV_ExchangeRate + " " + convertedCurrency + "\r\n" +
            //             "Average: 1 " + currencyToConvert + " = " + cRates.AverageExchangeRate + " " + convertedCurrency + "\r\n";
            //    else
            //        return "Google (Morningstar): 1 " + currencyToConvert + " = " +
            //           googleExchangeRate + " " + convertedCurrency + "\r\n" +
            //           "Western Union: 1 " + currencyToConvert + " = " +
            //           WU_ExchangeRate + " " + convertedCurrency + "\r\n" +
            //           "xe.com: 1 " + currencyToConvert + " = " +
            //           XE_ExchangeRate + " " + convertedCurrency + "\r\n" +
            //           "Average: 1 " + currencyToConvert + " = " + cRates.AverageExchangeRate + " " + convertedCurrency + "\r\n";
            //}
            //else
            //    return "INVALID CHOICES";
        }

        /// <summary>
        /// Modifies the Google radio button
        /// </summary>
        /// <returns></returns>
        public string SetFirstButtonText(string v, CurrencyRates cRates)
        {
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
        public string SetThirdRadioButtonText()
        {
            return "";
        }

        /// <summary>
        /// Modifies the AverageRate radio button
        /// </summary>
        /// <returns></returns>
        public string SetFourthRadioButtonText()
        {
            return "";
        }

    }
}
