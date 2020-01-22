using System;

namespace GuguLib.Algorithms.Interest
{
    /// <summary>
    /// Contains methods to calculate interest
    /// </summary>
    class Interest
    {
        readonly double _principal;
        readonly double _rate;
        readonly double _time;

        /// <summary>
        /// Sets principal, rate and compound value
        /// </summary>
        /// <param name="p">Principal</param>
        /// <param name="r">Rate(in percantage)</param>
        /// <param name="t">Time</param>
        public Interest(double p, double r, double t)
        {
            _principal = p;
            _rate = r / 100;
            _time = t;
        }

        /// <summary>
        /// Calculates a simple interest
        /// </summary>
        /// <returns>The simple interest</returns>
        public double SimpleInterest()
            => _principal * (1 + (_rate * _time));

        /// <summary>
        /// Calculates a compound interest
        /// </summary>
        /// <returns>The compound interest</returns>
        public double CompoundInterest()
            => _principal * Math.Pow((1 + _rate), _time);
    }
}
