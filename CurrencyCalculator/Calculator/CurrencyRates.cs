using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Calculate
{
    /// <summary>
    /// Contains the conversion rates between different currencies. Each rate is a 1-unit to 1-unit conversion.
    /// 
    /// FOR EXAMPLE: 1 USD (United Stated Dollar) = 1,168.95 South Korean Won (KRW), and 1 KRW = 0.00086 USD
    /// </summary>
    public class CurrencyRates
    {
        /// <summary>
        /// Contains the abbreviated names of currencies currently used in the program
        /// </summary>
        private List<string> currencyCodes = new List<string>();

        /*
         * Conversion from USD to other currencies 
         */

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
            //Add the currency codes in use
            currencyCodes.Add("BRL");
            currencyCodes.Add("CLP");
            currencyCodes.Add("COP");
            currencyCodes.Add("VEF");

            /*
             * NOTE: the numbers in here are outdated, but used for initialization.
             * These values were obtained in 2019, mid-December.
             */

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

        /// <summary>
        /// Updates the average exchange rates of each currency according to information received from the database or
        /// from the ExchangeRateSettings XML file.
        /// </summary>
        public void UpdateAverages()
        {
            AVG_USD_To_COP = (G_USD_To_COP + WU_USD_To_COP + XE_USD_To_COP) / 3;
            AVG_USD_To_BRL = (G_USD_To_BRL + WU_USD_To_BRL + XE_USD_To_BRL) / 3;
            AVG_USD_To_CLP = (G_USD_To_CLP + WU_USD_To_CLP + XE_USD_To_CLP) / 3;
        }

        /// <summary>
        /// Will save the most recent currency exchange rate settings to an xml file.
        /// </summary>
        /// <param name="filename"></param>
        public void Save(string filename)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "  ";

            try
            {
                using (XmlWriter wr = XmlWriter.Create(filename, settings))
                {
                    wr.WriteStartDocument();
                    wr.WriteStartElement("CurrencyRateSettings");
                    wr.WriteAttributeString("version", "2.2");

                    foreach (string code in currencyCodes)
                    {
                        wr.WriteStartElement(code);
                        switch (code)
                        {
                            case "BRL":
                                wr.WriteElementString("Google", "" + G_USD_To_BRL);
                                wr.WriteElementString("WesternUnion", "" + WU_USD_To_BRL);
                                wr.WriteElementString("xe.com", "" + XE_USD_To_BRL);
                                break;
                            case "CLP":
                                wr.WriteElementString("Google", "" + G_USD_To_CLP);
                                wr.WriteElementString("WesternUnion", "" + WU_USD_To_CLP);
                                wr.WriteElementString("xe.com", "" + XE_USD_To_CLP);
                                break;
                            case "COP":
                                wr.WriteElementString("Google", "" + G_USD_To_COP);
                                wr.WriteElementString("WesternUnion", "" + WU_USD_To_COP);
                                wr.WriteElementString("xe.com", "" + XE_USD_To_COP);
                                break;
                            case "VEF":
                                wr.WriteElementString("BCV", "" + BCV_USD_To_VEF);
                                wr.WriteElementString("exchangerates.org.uk", "" + exchangeRateUK_USD_To_VEF);
                                wr.WriteElementString("xe.com", "" + XE_USD_To_VEF);
                                break;
                            default:
                                break;
                        }
                        wr.WriteEndElement();
                    }
                    wr.WriteEndElement();
                    wr.WriteEndDocument();
                }
            }

            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("DNFException");
                //throw new SpreadsheetReadWriteException("Invalid File Path");
            }

            catch (IOException)
            {
                Console.WriteLine("IO");
                //throw new SpreadsheetReadWriteException("I/O Error");
            }

            catch (Exception)
            {

            }
        }

        public void LoadSettings(string filename)
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;
                using (XmlReader rd = XmlReader.Create(filename,settings))
                {
                    while (rd.Read())
                    {
                        if (rd.IsStartElement())
                        {
                            switch (rd.Name)
                            {
                                case "BRL":
                                    rd.Read(); // get to Google
                                    rd.Read(); // get to the numeric value
                                    G_USD_To_BRL = double.Parse(rd.Value);
                                    rd.Read(); // "/Google"

                                    rd.Read(); // get to xe.com
                                    rd.Read();
                                    WU_USD_To_BRL = double.Parse(rd.Value);
                                    rd.Read(); // "/WesternUnion"

                                    rd.Read(); // get to xe.com
                                    rd.Read();
                                    XE_USD_To_BRL = double.Parse(rd.Value); // don't need to read more than this
                                    break;
                                case "CLP":
                                    rd.Read(); // get to Google
                                    rd.Read(); // get to the numeric value
                                    G_USD_To_CLP = double.Parse(rd.Value);
                                    rd.Read(); // "/Google"

                                    rd.Read(); // get to xe.com
                                    rd.Read();
                                    WU_USD_To_CLP = double.Parse(rd.Value);
                                    rd.Read(); // "/WesternUnion"

                                    rd.Read(); // get to xe.com
                                    rd.Read();
                                    XE_USD_To_CLP = double.Parse(rd.Value); // don't need to read more than this
                                    break;
                                case "COP":
                                    rd.Read(); // get to Google
                                    rd.Read(); // get to the numeric value
                                    G_USD_To_COP = double.Parse(rd.Value);
                                    rd.Read(); // "/Google"

                                    rd.Read(); // get to xe.com
                                    rd.Read();
                                    WU_USD_To_COP = double.Parse(rd.Value);
                                    rd.Read(); // "/WesternUnion"

                                    rd.Read(); // get to xe.com
                                    rd.Read();
                                    XE_USD_To_COP = double.Parse(rd.Value); // don't need to read more than this
                                    break;
                                case "VEF":
                                    rd.Read(); // get to Google
                                    rd.Read(); // get to the numeric value
                                    BCV_USD_To_VEF = double.Parse(rd.Value);
                                    rd.Read(); // "/Google"

                                    rd.Read(); // get to xe.com
                                    rd.Read();
                                    exchangeRateUK_USD_To_VEF = double.Parse(rd.Value);
                                    rd.Read(); // "/WesternUnion"

                                    rd.Read(); // get to xe.com
                                    rd.Read();
                                    XE_USD_To_VEF = double.Parse(rd.Value); // don't need to read more than this
                                    break;
                                default:
                                    break;
                                    // throw new SpreadsheetReadWriteException("Unknown element found while reading file");
                            }
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {

            }

            catch (IOException)
            {

            }

            catch (Exception)
            {
                Console.WriteLine("Exception caught");
            }
        }
    }
}
