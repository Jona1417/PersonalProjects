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
        /// <summary>
        /// Indicates the user's most current choice for calculating currency exchanges
        /// </summary>
        public double CurrentExchangeRate { get; set; }

        public double Calculate(double input, double currentExchangeRate)
        {
            return input * currentExchangeRate;
        }
    }
}
