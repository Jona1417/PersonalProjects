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
        public double Calculate(double input, double exchangeRate)
        {
            return input * exchangeRate;
        }
    }
}
