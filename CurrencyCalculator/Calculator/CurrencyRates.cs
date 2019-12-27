using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    /// <summary>
    /// Contains the conversion rates between different currencies. Each rate is a 1-unit to 1-unit conversion.
    /// 
    /// FOR EXAMPLE: 1 USD (United Stated Dollar) = 1,168.95 South Korean Won (KRW), and 1 KRW = 0.00086 USD
    /// </summary>
    public class CurrencyRates
    {
        /*
         * Conversion from USD to other currencies 
         */

        /// <summary>
        /// Conversion rate of 1 USD to Venezuelan Bolivares according to Google
        /// </summary>
        public double G_USD_To_VEF { get; private set; } // TODO: Remove this option from the form

        /* This is actually converted the wrong way */

        /// <summary> 
        /// Conversion rate of 1 USD to Venezuelan Bolivares according to xe.com
        /// 
        /// NOTE: This rate only applies to exchange of "essential" goods, at a fixed rate (DIPRO). See the link below
        /// and look for a link to "More info", next to a notice saying that the Bolivar has two official rates.
        /// <see href="https://www.xe.com/currencyconverter/convert/?Amount=1&From=USD&To=VEF"/>
        /// </summary>
        public double XE_USD_To_VEF { get; private set; }

        /// <summary>
        /// Conversion rate of 1 USD to Venezuelan Bolivares according to the Banco Central de Venezuela. (2019/12/17)
        /// This rate refers to exchange of "non-essential" goods, with a rate that varies (DICOM). Refer to 
        /// <see href="http://www.bcv.org.ve/"/> for more information.
        /// </summary>
        public double BCV_USD_To_VEF { get; private set; }

        /// <summary>
        /// <see href="https://www.exchangerates.org.uk/Dollars-to-Venezuelan-bolivar-currency-conversion-page.html"/>
        /// </summary>
        public double exchangeRateUK_USD_To_VEF { get; private set; }

        /// <summary>
        /// Conversion rate of 1 USD to Colombian Pesos according to Google
        /// </summary>
        public double G_USD_To_COP { get; private set; }

        /// <summary>
        /// Conversion rate of 1 USD to Colombian Pesos according to xe.com
        /// </summary>
        public double XE_USD_To_COP { get; private set; }

        /// <summary>
        /// Conversion rate of 1 USD to Colombian Pesos according to Western Union
        /// </summary>
        public double WU_USD_To_COP { get; private set; }

        public double AVG_USD_To_COP { get; private set; }

        /// <summary>
        /// Exchange rate of 1 USD to Brazilian Reales according to Google (Morningstar)
        /// </summary>
        public double G_USD_To_BRL { get; private set; }

        /// <summary>
        /// Exchange rate of 1 USD to Brazilian Reales according to xe.com. See
        /// <see href="https://www.xe.com/currencyconverter/convert/?Amount=1&From=USD&To=BRL"/>
        /// for updated rates.
        /// </summary>
        public double XE_USD_To_BRL { get; private set; }

        /// <summary>
        /// Estimated exchange rate of 1 USD to Brazilan Reales according to Western Union. See
        /// <see href="https://www.westernunion.com/us/en/web/send-money/start"/>
        /// for updated rates.
        /// </summary>
        public double WU_USD_To_BRL { get; private set; }

        public double AVG_USD_To_BRL { get; private set; }

        public double G_USD_To_CLP { get; private set; }
        public double XE_USD_To_CLP { get; private set; }
        public double WU_USD_To_CLP { get; private set; }
        public double AVG_USD_To_CLP { get; private set; }

        public double AverageExchangeRate { get; private set; }


        public CurrencyRates()
        {
            // initialize the properties
            BCV_USD_To_VEF = 47167.49; // Venezuela
            exchangeRateUK_USD_To_VEF = 248488.5076;
            XE_USD_To_VEF = 9.9875;

            G_USD_To_COP = 3315.50; // Colombia
            XE_USD_To_COP = 3313.76;
            WU_USD_To_COP = 3272.9018;

            G_USD_To_BRL = 4.07; // Brazil
            XE_USD_To_BRL = 4.06520;
            WU_USD_To_BRL = 3.7644;

            G_USD_To_CLP = 752.20; // Chile
            XE_USD_To_CLP = 751.813;
            WU_USD_To_CLP = 685.4551;

            AVG_USD_To_COP = (G_USD_To_COP + WU_USD_To_COP + XE_USD_To_COP) / 3;
            AVG_USD_To_BRL = (G_USD_To_BRL + WU_USD_To_BRL + XE_USD_To_BRL) / 3;
            AVG_USD_To_CLP = (G_USD_To_CLP + WU_USD_To_CLP + XE_USD_To_CLP) / 3;
            AverageExchangeRate = 0;
        }

        public void setAverage(List<double> rates)
        {
            double sum = 0;
            foreach (double d in rates)
            {
                sum += d;
            }

            AverageExchangeRate = sum / rates.Count;
        }

        /// <summary>
        /// Updates the exchanges rates (as received from the database) according to company and national currency.
        /// </summary>
        /// <param name="company"></param>
        /// <param name="currency"></param>
        /// <param name="rateToChange"> The new exchange rate received from the database</param>
        public void UpdateRates(string company, string currency, double rateToChange)
        {
            switch (company)
            {
                case "BCV": // Only VEF
                    BCV_USD_To_VEF = rateToChange;
                    break;
                case "exchangerates.org.uk": // Only VEF
                    exchangeRateUK_USD_To_VEF = rateToChange;
                    break;

                case "Google": // COP, BRL, CLP (Morningstar)
                    switch (currency) // set the Morningstar rate based on the country
                    {
                        case "COP":
                            G_USD_To_COP = rateToChange;
                            break;
                        case "BRL":
                            G_USD_To_BRL = rateToChange;
                            break;
                        case "CLP":
                            G_USD_To_CLP = rateToChange;
                            break;
                    }
                    break;
                case "Western Union": // COP, BRL, CLP
                    switch (currency)
                    {
                        case "COP":
                            WU_USD_To_COP = rateToChange;
                            break;
                        case "BRL":
                            WU_USD_To_BRL = rateToChange;
                            break;
                        case "CLP":
                            WU_USD_To_CLP = rateToChange;
                            break;
                    }
                    break;
                case "xe.com": // COP, BRL, CLP (and maybe VEF)
                    switch (currency)
                    {
                        case "COP":
                            XE_USD_To_COP = rateToChange;
                            break;
                        case "BRL":
                            XE_USD_To_BRL = rateToChange;
                            break;
                        case "CLP":
                            XE_USD_To_CLP = rateToChange;
                            break;
                        case "VEF":
                            XE_USD_To_VEF = rateToChange;
                            break;
                    }
                    break;
            }
        }
    }
}
