using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace TVMCalc.Operations.OppsDelegates
{
    /// <summary>
    /// Note that the delegates below act like methods and are used to create a more dynamic "Calculate" method
    /// Where the type of calculation is demerited by the delegate that is passed into the method overload. 
    /// </summary>
    public static class BasicOppsDels
    {
        public delegate double OppsTwoDelegate(double x, double y);
        public delegate double OppsOneDelegate(double x);

        /// <summary>
        /// Add
        /// </summary>
        public static OppsTwoDelegate addDel = (x, y) => x + y;
        /// <summary>
        /// Subtract
        /// </summary>
        public static OppsTwoDelegate subtractDel = (x, y) => x - y;
        /// <summary>
        /// Multiply
        /// </summary>
        public static OppsTwoDelegate multiplyDel = (x, y) => x * y;
        /// <summary>
        /// Divide
        /// </summary>
        public static OppsTwoDelegate devideDel = (x, y) => x / y;
        /// <summary>
        /// Raises a number to a specified power.
        /// </summary>
        public static OppsTwoDelegate powerDel = (x, y) => Math.Pow(x, y);

        /// <summary>
        /// Turns a single given value into a percentage
        /// </summary>
        public static OppsOneDelegate percentDel = (x) => x / 100;
        /// <summary>
        /// Takes a single value and returns the square root.
        /// </summary>
        public static OppsOneDelegate sqrtDel = (x) => Math.Sqrt(x);
        /// <summary>
        /// Takes a single value and squares it.
        /// </summary>
        public static OppsOneDelegate squareDel = (x) => Math.Pow(x, 2);
        /// <summary>
        /// Sets a value under one. 
        /// </summary>
        public static OppsOneDelegate oneOverDel = (x) => 1 / x;
        /// <summary>
        /// Takes a single value and returns the natural log of the value.
        /// </summary>
        public static OppsOneDelegate naturalLogDel = (x) => Math.Log(x);
    }
}


