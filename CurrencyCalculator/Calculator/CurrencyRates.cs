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
        public readonly double G_USD_To_VEF = 0.100125;

        /// <summary>
        /// Conversion rate of 1 USD to Colombian Pesos according to Google
        /// </summary>
        public readonly double G_USD_To_COP;

        /// <summary>
        /// Conversion rate of 1 USD to Venezuelan Bolivares according to xe.com
        /// 
        /// NOTE: This rate only applies to exchange of "essential" goods, at a fixed rate (DIPRO).
        /// See the hyperlink, and look for a link to "More info", next to a notice saying that the Bolivar has two official rates.
        /// </summary>
        /// <see href="https://www.xe.com/currencyconverter/convert/?Amount=1&From=USD&To=VEF"/>
        public readonly double XE_USD_To_VEF = 9.9875;

        /// <summary>
        /// Conversion rate of 1 USD to Venezuelan Bolivares according to the Banco Central de Venezuela. (2019/12/17)
        /// This rate refers to exchange of "non-essential" goods, with a rate that varies (DICOM)
        /// </summary>
        /// <see href="http://www.bcv.org.ve/"/>
        public readonly double BCV_USD_To_VEF = 46366.58;

        /// <summary>
        /// Conversion rate of 1 USD to Colombian Pesos according to xe.com
        /// </summary>
        public readonly double XE_USD_To_COP = 3351.72;


        /* Conversion Rates from other currencies to USD */

        public readonly double XE_VEF_To_USD;

        public readonly double XE_COP_To_USD = 0.000298155;

        public readonly double G_VEF_To_USD;

        public readonly double G_COP_To_USD;
        public readonly double WU_USD_TO_COP;

        public CurrencyRates()
        {

        }

    }
}
