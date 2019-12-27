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
        private bool sendingCurrencyIsValid;
        private bool receivingCurrencyIsValid;
        private CurrencyRates currency = new CurrencyRates();
        private Calculator calc;

        public delegate void CurrenciesValidHandler();

        public event CurrenciesValidHandler SelectionsBothValid;

        /// <summary>
        /// Controls how user input affects the display of the View's Currency rates.
        /// </summary>
        public CalcController()
        {
            sendingCurrencyIsValid = false;
            receivingCurrencyIsValid = false;
            calc = new Calculator();
        }

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
        /// 
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
    }
}
