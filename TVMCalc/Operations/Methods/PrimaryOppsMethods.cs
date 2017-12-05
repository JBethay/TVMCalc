using System;
using System.Collections.Generic;
using System.Text;

namespace TVMCalc.Operations.Methods
{
    /// <summary>
    /// Basic Calculation Methods
    /// </summary>
    public static class PrimaryOppsMethods
    {
        /// <summary>
        /// Add
        /// </summary>
        public static double AddCompt (double x, double y) => x + y;
        /// <summary>
        /// Subtract
        /// </summary>
        public static double SubtractCompt (double x, double y) => x - y;
        /// <summary>
        /// Multiply
        /// </summary>
        public static double MultiplyCompt (double x, double y) => x * y;
        /// <summary>
        /// Divide
        /// </summary>
        public static double DevideCompt (double x, double y) => x / y;
        /// <summary>
        /// Raises a number to a specified power.
        /// </summary>
        public static double PowerCompt (double x, double y) => Math.Pow(x, y);

        /// <summary>
        /// Turns a single given value into a percentage
        /// </summary>
        public static double PercentCompt (double x) => x / 100;
        /// <summary>
        /// Takes a single value and returns the square root.
        /// </summary>
        public static double SqrtCompt (double x) => Math.Sqrt(x);
        /// <summary>
        /// Takes a single value and squares it.
        /// </summary>
        public static double SquareCompt (double x) => Math.Pow(x, 2);
        /// <summary>
        /// Sets a value under one. 
        /// </summary>
        public static double OneOverCompt (double x) => 1 / x;
        /// <summary>
        /// Takes a single value and returns the natural log of the value.
        /// </summary>
        public static double NaturalLogCompt (double x) => Math.Log(x);
    }
}
