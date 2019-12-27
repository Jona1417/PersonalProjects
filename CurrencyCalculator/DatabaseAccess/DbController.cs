using Calculate;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    /// <summary>
    /// This class will work with the SQL Server and access a database to update currency exchange rates.
    /// </summary>
    public class DbController
    {
        public delegate void UpdateSuccessfulHandler();
        public event UpdateSuccessfulHandler ExchangeRatesUpdated;

        public delegate void UpdateFailedHandler();
        public event UpdateFailedHandler FailedToUpdate;

        /// <summary>
        /// Indicates the last time the exchange rates were updated on the database
        /// </summary>
        private string timeOfLastUpdate;


        /// <summary>
        /// The connection string.
        /// Your uID login name serves as both your database name and your uid
        /// </summary>
        public const string connectionString = "server=192.168.21.173;" +
          "database=currency_exchange_rates;" +
          "uid=newuser;" +
          "password=test_password1";
        private CurrencyRates cRates;

        public DbController(CurrencyRates currencyRates)
        {
            cRates = currencyRates;
        }

        /// <summary>
        /// 
        /// </summary>
        public void UpdateAllRates()
        {
            UpdateVenezuelaRates();
            UpdateColombiaRates();
            //UpdateBrazilRates();
            //UpdateChileRates();
        }

        private void UpdateChileRates()
        {
            throw new NotImplementedException();
        }

        private void UpdateBrazilRates()
        {
            throw new NotImplementedException();
        }

        private void UpdateColombiaRates()
        {
            // Connect to the DB
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    // Open a connection
                    conn.Open();

                    // Create a command
                    MySqlCommand command = conn.CreateCommand();
                    command.CommandText = "select * from colombia_exchange_rates"; // TODO: Change

                    // Execute the command and cycle through the DataReader object
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            double toParse = 0.0;
                            switch (reader["Company"])
                            {
                                case "Google (Morningstar)":
                                    toParse = (double)reader["ExchangeRate"];
                                    Console.WriteLine("Colombia: " + toParse);
                                    cRates.UpdateRates("Google", "COP", toParse);
                                    break;
                                case "xe.com":
                                    toParse = (double)reader["ExchangeRate"];
                                    Console.WriteLine(toParse);
                                    cRates.UpdateRates("xe.com", "COP", toParse);
                                    break;
                                case "Western Union":
                                    toParse = (double)reader["ExchangeRate"];
                                    Console.WriteLine(toParse);
                                    cRates.UpdateRates("Western Union", "COP", toParse);
                                    break;
                            }
                        }
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


        public void UpdateVenezuelaRates()
        {
            // Connect to the DB
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    // Open a connection
                    conn.Open();

                    // Create a command
                    MySqlCommand command = conn.CreateCommand();
                    command.CommandText = "select * from venezuela_exchange_rates"; // TODO: Change

                    // Execute the command and cycle through the DataReader object
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            double toParse = 0.0;
                            switch (reader["Company"])
                            {
                                case "BCV":
                                    toParse = (double)reader["ExchangeRate"];
                                    Console.WriteLine(toParse);
                                    cRates.UpdateRates("BCV", "VEF", toParse);
                                    break;
                                case "xe.com":
                                    toParse = (double)reader["ExchangeRate"];
                                    Console.WriteLine(toParse);
                                    cRates.UpdateRates("xe.com", "VEF", toParse);
                                    break;
                                case "exchangerates.org.uk":
                                    toParse = (double)reader["ExchangeRate"];
                                    Console.WriteLine(toParse);
                                    cRates.UpdateRates("exchangerates.org.uk", "VEF", toParse);
                                    break;
                            }
                        }
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public string GetTimeOfLastUpdate()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    // Open a connection
                    conn.Open();

                    // Create a command
                    MySqlCommand command = conn.CreateCommand();
                    command.CommandText = "select * from venezuela_exchange_rates"; // TODO: Change

                    // Execute the command and cycle through the DataReader object
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            double toParse = 0.0;
                            switch (reader["Company"])
                            {
                                case "BCV":
                                    toParse = (double)reader["ExchangeRate"];
                                    Console.WriteLine(toParse);
                                    cRates.UpdateRates("BCV", "VEF", toParse);
                                    break;
                                case "xe.com":
                                    toParse = (double)reader["ExchangeRate"];
                                    Console.WriteLine(toParse);
                                    cRates.UpdateRates("xe.com", "VEF", toParse);
                                    break;
                                case "exchangerates.org.uk":
                                    toParse = (double)reader["ExchangeRate"];
                                    Console.WriteLine(toParse);
                                    cRates.UpdateRates("exchangerates.org.uk", "VEF", toParse);
                                    break;
                            }
                        }
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return "";
            }
        }
    }
}
