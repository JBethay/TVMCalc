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
        /// This method generates Factorial of the Number using recursion. 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Factorial_Recursion(this double x)
        {
            if (x == 1)
                return 1;
            else
                return x * Factorial_Recursion(x - 1);
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
