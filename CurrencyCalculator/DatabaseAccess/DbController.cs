﻿using Calculate;
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
        /// The connection string.
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
        /// Retreives currency exchange rate information from each table in the database and lets the user know 
        /// the time that the rates were last updated.
        /// </summary>
        public void UpdateAllRates()
        {
            UpdateVenezuelaRates();
            UpdateColombiaRates();
            UpdateBrazilRates();
            UpdateChileRates();
            ExchangeRatesUpdated();
        }

        private void UpdateBrazilRates()
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
                    command.CommandText = "select * from brazil_exchange_rates";

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
                                    cRates.UpdateRates("Google", "BRL", toParse);
                                    break;
                                case "xe.com":
                                    toParse = (double)reader["ExchangeRate"];
                                    cRates.UpdateRates("xe.com", "BRL", toParse);
                                    break;
                                case "Western Union":
                                    toParse = (double)reader["ExchangeRate"];
                                    cRates.UpdateRates("Western Union", "BRL", toParse);
                                    break;
                            }
                        }
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    FailedToUpdate();
                }
            }
        }


        private void UpdateChileRates()
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
                    command.CommandText = "select * from chile_exchange_rates";

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
                                    cRates.UpdateRates("Google", "CLP", toParse);
                                    break;
                                case "xe.com":
                                    toParse = (double)reader["ExchangeRate"];
                                    cRates.UpdateRates("xe.com", "CLP", toParse);
                                    break;
                                case "Western Union":
                                    toParse = (double)reader["ExchangeRate"];
                                    cRates.UpdateRates("Western Union", "CLP", toParse);
                                    break;
                            }
                        }
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    FailedToUpdate();
                }
            }
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
                    command.CommandText = "select * from colombia_exchange_rates"; 

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
                                    cRates.UpdateRates("Google", "COP", toParse);
                                    break;
                                case "xe.com":
                                    toParse = (double)reader["ExchangeRate"];
                                    cRates.UpdateRates("xe.com", "COP", toParse);
                                    break;
                                case "Western Union":
                                    toParse = (double)reader["ExchangeRate"];
                                    cRates.UpdateRates("Western Union", "COP", toParse);
                                    break;
                            }
                        }
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    FailedToUpdate();
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
                    command.CommandText = "select * from venezuela_exchange_rates"; 

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
                                    cRates.UpdateRates("BCV", "VEF", toParse);
                                    break;
                                case "xe.com":
                                    toParse = (double)reader["ExchangeRate"];
                                    cRates.UpdateRates("xe.com", "VEF", toParse);
                                    break;
                                case "exchangerates.org.uk":
                                    toParse = (double)reader["ExchangeRate"];
                                    cRates.UpdateRates("exchangerates.org.uk", "VEF", toParse);
                                    break;
                            }
                        }
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    FailedToUpdate();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime GetTimeOfLastUpdate()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    // Open a connection
                    conn.Open();

                    // Create a command
                    MySqlCommand command = conn.CreateCommand();
                    command.CommandText = "select LastUpdated from chile_exchange_rates"; 

                    // Execute the command and cycle through the DataReader object
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return (DateTime)reader["LastUpdated"];
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    FailedToUpdate();
                    return DateTime.MinValue; // indicates that something went wrong with the update
                }

                return DateTime.MinValue;
            }
        }
    }
}
