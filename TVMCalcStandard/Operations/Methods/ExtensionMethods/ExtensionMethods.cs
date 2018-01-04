using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    /// <summary>
    /// The Extension Methods in this class are methods that will be used frequently in calculations. 
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// This method generates Factorial of the Number using recursion. Note this method does NOT use the Gamma function
        /// if a decimal place is added the method will simply round up or down to the nearest whole number.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Factorial_Recursion(this double x)
        {
            x = Math.Round(x, 0);
            if (x != 0 && x > 0 && x < 170)
            {
                if (x == 1)
                {
                    return 1;
                }
                else
                {
                    return x * Factorial_Recursion(x - 1);
                }
            }
            else return x;
        }
        /// <summary>
        /// This method provides the inverse of the parameter.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Plus_Minus(this double x)
        {
            x = x * -1;
            return x;
        }
    }
}
