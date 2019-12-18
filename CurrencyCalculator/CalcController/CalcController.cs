using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    public class CalcController
    {
        private bool sendingCurrencyIsValid;
        private bool receivingCurrencyIsValid;

        public delegate void CurrenciesValidHandler();

        public event CurrenciesValidHandler selectionsBothValid;

        /// <summary>
        /// Controls how user input affects the display of the View's Currency rates.
        /// </summary>
        public CalcController()
        {
            sendingCurrencyIsValid = false;
            receivingCurrencyIsValid = false;
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
                selectionsBothValid();
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
                selectionsBothValid();
            }
        }       
    }
}
