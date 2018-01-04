using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using static TVMCalc.Operations.Methods.SecondaryOppsMethods;

namespace TVMCalcDroid.Helper
{
    public static  class HelperCalc
    {

        /// <summary>
        /// Rounds String for formating purposes. Note that a second variable will need to keep track of physical values....
        /// </summary>
        /// <param name="num"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string NumToStringFormated(double num, int format)
        {
            RoundCompute(num, format);
            return num.ToString($"F{format}");
        }

        /// <summary>
        /// Rounds String, not formated
        /// </summary>
        /// <param name="num"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string NumToString(double num, int format)
        {
            RoundCompute(num, format);
            return num.ToString();
        }

        /// <summary>
        /// Converts a String to a double
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double StringToNum(string s)
        {
            double result =0;

            if (double.TryParse(s, out double r) == true)
            {
                result = double.Parse(s);

                if (s == "∞" || s == "-∞" || s == "Infinity" || s == "-Infinity" || s == "NaN" || s == "NAN")
                    return 0;
                else return result;
            }
            else return 0;
        }
    }
}